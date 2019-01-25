using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MoveTowardPosition))]
[Serializable]
public class Item : MonoBehaviour
{
    public GameObject graphicalObj;
    public bool isPickupable = true;
    public bool drag;
    public List<String> Tags;
    MoveTowardPosition movement;
    public Collider2D overObject;

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
