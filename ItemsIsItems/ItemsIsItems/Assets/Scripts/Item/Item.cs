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
    public Collider2D overObject;

    public Inventory inventory;
    
    public bool isPickupable = true;
    public bool drag;

    [SerializeField]
    public List<Descriptor> Descriptors = new List<Descriptor>();

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

    private void OnMouseDrag()
    {
        if (inventory != null)
        {
            drag = true;
            inventory.RemoveItem(this);
            inventory = null;
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
        if (drag)
        {
            overObject = other;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(overObject == other && drag)
        {
            overObject = null;
        }
    }

    void OnMouseUp()
    {
        if(drag == true)
        {
            drag = false;
            isPickupable = true;

            if (GameManager.Instance != null && overObject != null)
            {
                Item other = overObject.GetComponent<Item>();
                if (other != null)
                {
                    GameManager.Instance.ExecuteInteraction(this, other);
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

    public bool NameEquals(Item other)
    {
        return other.name == this.name;
    }
}
