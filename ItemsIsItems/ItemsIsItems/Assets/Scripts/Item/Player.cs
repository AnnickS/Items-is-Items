using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MoveTowardMouse))]
[RequireComponent(typeof(RotateTowardMovementTarget))]
[RequireComponent(typeof(TrailOffsetInventory))]
public class Player : CollidableItem
{
    new void Start()
    {
        base.Start();
        gameObject.layer = 10;
    }
}
