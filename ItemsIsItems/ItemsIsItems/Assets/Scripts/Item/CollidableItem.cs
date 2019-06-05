using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollidableItem : Item
{
    public bool needsColliders = true;

    public new void Start()
    {
        base.Start();

        //Adding this second component (the first is from item)
        //the first collider does drag and drop
        //the second collider is for colliding into walls
        if (this.GetComponents<BoxCollider2D>().Length == 0 && needsColliders)
        {
            BoxCollider2D dragAndDropCollider = gameObject.AddComponent<BoxCollider2D>();
            dragAndDropCollider.isTrigger = true;
        }

        if (this.GetComponents<BoxCollider2D>().Length == 1 && needsColliders)
        {
            BoxCollider2D wallCollider = gameObject.AddComponent<BoxCollider2D>();
            wallCollider.isTrigger = false;
        }
    }
}
