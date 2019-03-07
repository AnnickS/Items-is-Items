using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(MoveTowardPosition))]
[RequireComponent(typeof(SpriteRenderer))]
[Serializable]
public class Item : MonoBehaviour
{
    public new String name;
    public GameObject graphicalObj;

    public int onDragZ = -5;
    public Vector3 onDragScaleSize = new Vector3(1.3f, 1.3f, 1);
    private Vector3 onDragPreviousScale;
    private float onDragPreviousZ;

    public Inventory inventoryWithin;
    
    public bool isPickupable = true;
    public bool drag;
    public bool multipleInteract = false;
    private List<Item> touching = new List<Item>();

    [SerializeField]
    public List<Descriptor> Descriptors = new List<Descriptor>();

    public GameObject jail;

    private BoxCollider2D boxCollider;
    private Rigidbody2D rb;

    protected void Start()
    {
        gameObject.layer = LayerMask.NameToLayer("Foreground");
        
        if(transform.Find("Mesh") != null)
        {
            graphicalObj = transform.Find("Mesh").gameObject;
        }
        else
        {
            graphicalObj = gameObject;
        }

        boxCollider = GetComponent<BoxCollider2D>();
        if(boxCollider == null)
        {
            Debug.Log("Item " + this.gameObject.name + " needs a BoxCollider.");
        }
        boxCollider.isTrigger = true;

        rb = GetComponent<Rigidbody2D>();
        rb.interpolation = RigidbodyInterpolation2D.Extrapolate;
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;

        //rb.constraints = RigidbodyConstraints2D.FreezeRotation | rb.constraints;
    }

    public void Drop()
    {
        drag = false;
        isPickupable = true;
        GetComponent<MoveTowardPosition>().moveToPosition(transform.position);
        inventoryWithin = null;
        gameObject.layer = LayerMask.NameToLayer("Foreground");
        rb.velocity = Vector2.zero;
        boxCollider.isTrigger = true;
    }

    private void OnMouseDrag()
    {
        if (inventoryWithin != null)
        {
            dragStart();
        }
        if (drag)
        {
            Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 objectPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            //transform.position = objectPosition;
            GetComponent<Rigidbody2D>().MovePosition(objectPosition);
        }
    }

    /*
    void OnTriggerEnter2D(Collider2D other)
    {
        Item item = other.GetComponent<Item>();
        if (item != null && touching.Contains(item) == false)
        {
            touching.Add(item);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        touching.Remove(other.GetComponent<Item>());
    }*/

    void OnMouseUp()
    {
        if(drag == true)
        {
            dragEnd();
        }
    }

    private void dragStart()
    {
        drag = true;
        gameObject.layer = LayerMask.NameToLayer("Dragged");
        boxCollider.isTrigger = false;
        //*
        onDragPreviousZ = this.transform.position.z;
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, onDragZ);

        onDragPreviousScale = this.transform.localScale;
        this.transform.localScale = this.transform.localScale + onDragScaleSize;
        //*/
        inventoryWithin.RemoveItem(this);
        inventoryWithin = null;
    }

    private void dragEnd()
    {
        Drop();
        this.transform.localScale = onDragPreviousScale;
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, onDragPreviousZ);

        List<Item> touching = GetTouching();
        if (GameManager.Instance != null && touching.Count > 0)
        {
            foreach (Item item in touching)
            {
                bool interacted = GameManager.Instance.ExecuteInteraction(this, item);
                if (interacted && multipleInteract == false)
                {
                    break;
                }
            }
        }
    }

    /*/
    public void OnCollisionEnter(Collision collision)
    {
        Item other = collision.gameObject.GetComponent<Item>();
        if (other != null)
        {
            if (GetHashCode() > other.GetHashCode())
            {
                ItemManager.Instance.ExecuteInteraction(this, other);
            }
        }        
    }
    /**/

    public List<Item> GetTouching()
    {
        Collider2D[] under = Physics2D.OverlapBoxAll(transform.position, (Vector2)GetComponent<Collider2D>().bounds.size / 2, transform.eulerAngles.z);
        List<Item> touching = new List<Item>();
        foreach (Collider2D coll in under)
        {
            Item item = coll.GetComponent<Item>();
            if (item != null)
            {
                touching.Add(item);
            }
        }
        return touching;
    }

    public bool HasDescriptor(Descriptor tag)
    {
        foreach(Descriptor d in Descriptors)
        {
            if(d == null)
            {
                continue;
            }
            if (d.Contains(tag))
            {
                return true;
            }
        }
        return false;
    }

    public GameObject GetJail()
    {
        return jail;
    }

    public bool NameEquals(Item other)
    {
        return other.name == this.name;
    }

    /*
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine((Vector2)transform.position, (Vector2)transform.position + (Vector2)GetComponent<Collider2D>().bounds.size/2);
    }*/
}
