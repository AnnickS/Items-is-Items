using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Collider))]
public class Movement : MonoBehaviour
{
    public bool canMove = false;
    public float speed = 10;
    public Vector3 targetPosition;
    Rigidbody rb;
    public double offset = 2;

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (canMove)
        {
            if (Vector3.Distance(transform.position, targetPosition) > offset)
            {
                rb.MovePosition(rb.position + (targetPosition - transform.position).normalized * speed * Time.deltaTime);
            }
        }
    }

    public void SetOffset(double newOffset)
    {
        offset = newOffset;
    }

    public void SetTargetPosition(Vector3 newTarget)
    {
        targetPosition = newTarget;
    }

    public void SetMoveable(bool state)
    {
        targetPosition = transform.position;
        canMove = state;
    }

    public bool IsMoveable()
    {
        return canMove;
    }
}
