using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class MoveTowardPosition : MonoBehaviour
{
    public float speed = 1f;
    private Vector2 targetPosition;
    public bool moving = false;

    void Start()
    {
        targetPosition = this.transform.position;
        Rigidbody2D rigidBody = GetComponent<Rigidbody2D>();

        if(rigidBody == null)
        {
            Debug.LogError("MoveTowardsPosition in " + gameObject.name + " needs a Rigidbody2D.");
        }

        rigidBody.gravityScale = 0;
    }

    public void moveToPosition(Vector2 newGoalPosition)
    {
        targetPosition = newGoalPosition;
        moving = true;
    }

    public Vector2 getCurrentTargetPosition()
    {
        return targetPosition;
    }

    public bool isCurrentlyMoving()
    {
        return moving;
    }

    protected void FixedUpdate()
    {
        if (isAlreadyAtTarget())
        {
            moving = false;
        }
        else if (moving == true)
        {
            move();
        }
    }

    private bool isAlreadyAtTarget()
    {
        Vector2 currentPosition = getCurrentPositionXY();
        return targetPosition.Equals(currentPosition);
    }

    private void move()
    {
        Vector2 currentPosition = getCurrentPositionXY();
        Vector2 distanceBetween = targetPosition - currentPosition;

        if (distanceBetween.magnitude <= speed)
        {
            setPositionXY(targetPosition);
        }
        else
        {
            distanceBetween.Normalize();
            distanceBetween.Scale(new Vector2(speed, speed));
            Vector3 newPosition = currentPosition + distanceBetween;

            setPositionXY(newPosition);
        }
    }

    private Vector2 getCurrentPositionXY()
    {
        Vector2 currentPosition = new Vector2(this.transform.position.x, this.transform.position.y);
        return currentPosition;
    }

    private void setPositionXY(Vector2 newPosition)
    {
        Vector3 targetPos = new Vector3(newPosition.x, newPosition.y, this.transform.position.z);
        if (Vector3.Distance(transform.position, targetPos) < 0.001)
        {
            this.transform.position = targetPos;
        }
        else {
            this.transform.position = Vector3.Lerp(transform.position, new Vector3(newPosition.x, newPosition.y, this.transform.position.z), Time.deltaTime * 10f);
        }
    }
}
