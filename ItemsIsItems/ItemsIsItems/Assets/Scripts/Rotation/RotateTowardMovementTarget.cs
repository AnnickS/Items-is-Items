using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MoveTowardPosition))]
public class RotateTowardMovementTarget : RotateTowardPosition
{

    MoveTowardPosition moveTowardPositionScript;

    void Start()
    {
        moveTowardPositionScript = GetComponent<MoveTowardPosition>();
    }

    void FixedUpdate()
    {
        rotateTowardsTargetPosition();
    }

    public void rotateTowardsTargetPosition()
    {
        if(moveTowardPositionScript == null)
        {
            moveTowardPositionScript = GetComponent<MoveTowardPosition>();
        }

        Vector2 movementTargetPosition = moveTowardPositionScript.getCurrentTargetPosition();
        Vector2 rotationTargetPosition = getCurrentTargetPosition();
        if (!movementTargetPosition.Equals(rotationTargetPosition))
        {
            rotateToPosition(movementTargetPosition);
        }
    }
}
