using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MoveTowardPosition))]
[Serializable]
public class Item : MonoBehaviour
{
    public new String name;
    public String nickname;
    public GameObject graphicalObj;
    public Collider2D overObject;

    public Inventory inventory;
    MoveTowardPosition movement;
    
    public bool isPickupable = true;
    public bool drag;

    public List<Descriptor> Descriptors;

    protected void Start()
    {
        gameObject.layer = 8;
        movement = GetComponent<MoveTowardPosition>();
        
        if(transform.Find("Mesh") != null)
        {
            graphicalObj = transform.Find("Mesh").gameObject;
        }
        else
        {
            graphicalObj = gameObject;
        }
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

            if (ItemManager.Instance != null && overObject != null)
            {
                Item other = overObject.GetComponent<Item>();
                if (other != null)
                {
                    ItemManager.Instance.ExecuteInteraction(this, other);
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
