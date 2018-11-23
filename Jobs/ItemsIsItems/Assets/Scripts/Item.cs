using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movement))]
public class Item : MonoBehaviour
{
    //GameObject graphicalObj;
    public bool isPickupable = true;

    Movement movement;

    void Start()
    {
        movement = GetComponent<Movement>();

        //graphicalObj = transform.Find("Mesh").gameObject;
    }

    public void OnCollisionEnter(Collision collision)
    {
        Item other = collision.gameObject.GetComponent<Item>();
        if (other != null)
        {
            GameManager.gameManager.OnItemTouch(this, other);
        }        
    }

}
