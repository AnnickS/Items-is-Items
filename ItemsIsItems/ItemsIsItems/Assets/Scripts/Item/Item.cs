using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MoveTowardPosition))]
public class Item : MonoBehaviour
{
    public new String name;
    public GameObject graphicalObj;
    public Collider2D overObject;

    public Inventory inventory;
    MoveTowardPosition movement;
    
    public bool isPickupable = true;
    public bool drag;

    public List<ItemDescriptor> Descriptors;

    void Start()
    {
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
        drag = false;
        if(ItemManager.Manager != null && overObject != null)
        {
            ItemManager.Manager.UseItem(this.GetComponent<Collider2D>(), overObject);
        }
    }

    /*
    public void OnCollisionEnter(Collision collision)
    {
        Item other = collision.gameObject.GetComponent<Item>();
        if (other != null)
        {
            if (GetHashCode() > other.GetHashCode())
            {
                GameManager.gameManager.OnItemTouch(new ItemInteractionRequest(this, other));
            }
        }        
    }
    */

}
