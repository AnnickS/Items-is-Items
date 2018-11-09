using System;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangeInteraction :  MonoBehaviour, Interactable
{
    public void Interact(Item otherObj)
    {
        otherObj.ChangeColor(Color.blue);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Item other = collision.collider.gameObject.GetComponent<Item>();
        if (other != null)
        {
            Interact(other);
        }
    }
}
