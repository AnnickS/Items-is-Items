using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MoveTowardMouse))]
[RequireComponent(typeof(RotateTowardMovementTarget))]
[RequireComponent(typeof(TrailOffsetInventory))]
public class Player : CollidableItem
{

    Vector3 startPosition;

    new void Start()
    {
        base.Start();
        gameObject.layer = 10;
        startPosition = transform.position;
    }

    public void Respawn()
    {
        this.transform.position = startPosition;
        MoveTowardMouse movement = GetComponent<MoveTowardMouse>();
        movement.moveToPosition(new Vector2(startPosition.x, startPosition.y));
    }
}
