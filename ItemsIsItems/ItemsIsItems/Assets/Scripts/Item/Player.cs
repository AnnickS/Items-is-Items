using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Item {
    public Inventory inventory;


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
        if (overObject == other && drag)
        {
            overObject = null;
        }
    }

    void OnMouseUp()
    {
        drag = false;
        if (ItemManager.Instance != null && overObject != null)
        {
            ItemManager.Instance.ExecuteInteraction(this, overObject.GetComponent<Item>());
        }
    }
}
