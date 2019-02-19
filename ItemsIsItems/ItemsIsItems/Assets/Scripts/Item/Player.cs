using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Item {

    void Start()
    {
        base.Start();
        gameObject.layer = 10;
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

        if (GameManager.Instance != null && overObject != null)
        {
            GameManager.Instance.ExecuteInteraction(this, overObject.GetComponent<Item>());
        }
    }
}
