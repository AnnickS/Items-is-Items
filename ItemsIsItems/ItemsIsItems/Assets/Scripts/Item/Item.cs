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

    protected void Start()
    {
        gameObject.layer = 8;
        
        if(transform.Find("Mesh") != null)
        {
            graphicalObj = transform.Find("Mesh").gameObject;
        }
        else
        {
            graphicalObj = gameObject;
        }

        BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();
        if(boxCollider == null)
        {
            Debug.Log("Item " + this.gameObject.name + " needs a BoxCollider.");
        }
        boxCollider.isTrigger = true;
    }

    public void Drop()
    {
        drag = false;
        isPickupable = true;
        GetComponent<MoveTowardPosition>().moveToPosition(transform.position);
        inventoryWithin = null;
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
            transform.position = objectPosition;
        }
    }

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
    }

    void OnMouseUp()
    {
        if(drag == true)
        {
            dragEnd();            

            if (GameManager.Instance != null && touching.Count >= 0)
            {
                if (multipleInteract)
                {
                    for (int i = touching.Count-1; i >= 0; i--)
                    {
                        Item item = touching[i];
                        GameManager.Instance.ExecuteInteraction(this, item);
                    }
                }
                else
                {
                    GameManager.Instance.ExecuteInteraction(this, touching[0]);
                }
            }
        }
    }

    private void dragStart()
    {
        drag = true;

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

    public bool HasDescriptor(Descriptor tag)
    {
        foreach(Descriptor d in Descriptors)
        {
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
}
