using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleItem : CollidableItem
{

    public new void Start()
    {
        base.Start();

        isPickupable = false;
        inWorld = true;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
    }
}

