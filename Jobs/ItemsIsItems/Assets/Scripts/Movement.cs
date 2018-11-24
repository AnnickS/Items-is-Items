using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Collider))]
public class Movement : MonoBehaviour
{
    //public bool canMove = true;
    private bool isMoving = false;
    public float speed = 10;
    //public double offset = 2;

    public Vector3 targetPosition;

    Rigidbody rb;

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    private void LateUpdate()
    {

    }

    void FixedUpdate()
    {
        //Option:
        //Non
        //Go-To
        //Go-To w/ Offset
        //Follow

        if (isMoving)
        {
            float distance = Vector3.Distance(transform.position, targetPosition);
            /*/
            if (Vector3.Distance(transform.position, targetPosition) > offset)
            {
                rb.MovePosition(rb.position + (targetPosition - transform.position).normalized * speed * Time.deltaTime);
            }
            /*/
            if (distance < 0.05)
            {
                //rb.MovePosition(targetPosition);
                //rb.velocity = Vector3.zero;
                CancelMove();
            }
            else
            {
                rb.velocity = (targetPosition - transform.position).normalized * speed;
            }
            /**/
        }
    }

    //public void SetOffset(double newOffset)
    //{
    //    offset = newOffset;
    //}

    public void SetTargetPosition(Vector3 newTarget)
    {
        targetPosition = newTarget;
        isMoving = true;
    }

    public void CancelMove()
    {
        isMoving = false;
        rb.velocity = Vector3.zero;
    }
}
