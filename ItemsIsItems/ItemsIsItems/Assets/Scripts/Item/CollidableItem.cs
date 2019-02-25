using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollidableItem : Item
{

    public new void Start()
    {
        base.Start();

        //Adding this second component (the first is from item)
        //the first collider does drag and drop
        //the second collider is for colliding into walls

        if (this.GetComponents<BoxCollider2D>().Length == 0)
        {
            BoxCollider2D triggerableCollider = gameObject.AddComponent<BoxCollider2D>();
            triggerableCollider.isTrigger = true;
        }

        if (this.GetComponents<BoxCollider2D>().Length == 1)
        {
            BoxCollider2D triggerableCollider = gameObject.AddComponent<BoxCollider2D>();
            triggerableCollider.isTrigger = false;
        }
    }
}
