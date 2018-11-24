using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movement))]
public class Item : MonoBehaviour
{
    public GameObject graphicalObj;
    public bool isPickupable = true;

    Movement movement;

    void Start()
    {
        movement = GetComponent<Movement>();
        
        if(transform.Find("Mesh") != null)
        {
            graphicalObj = transform.Find("Mesh").gameObject;
        }
        else
        {
            graphicalObj = gameObject;
        }
    }

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

}
