using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Item {

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
