using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Collider))]
public class Movement : MonoBehaviour
{
    public bool canMove = false;
    public float speed = 10;
    public double offset = 2;

    public Vector3 targetPosition;
    private Transform targetTransform;
    private Touch? targetTouch;

    Rigidbody rb;

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    private void LateUpdate()
    {
        if (targetTouch != null)
        {
            targetTouch = InputManager.instance.GetTouch(targetTouch.Value.fingerId);
            if (targetTouch != null)
            {
                switch (targetTouch.Value.phase)
                {
                    case TouchPhase.Began:
                    case TouchPhase.Moved:
                    case TouchPhase.Stationary:
                        canMove = true;
                        Ray ray = Camera.main.ScreenPointToRay(targetTouch.Value.position);
                        RaycastHit hit;
                        if (Physics.Raycast(ray, out hit, 10000f, 1 << LayerMask.NameToLayer("Ground")))
                        {
                            targetPosition = hit.point;
                        }
                        break;
                    case TouchPhase.Ended:
                    case TouchPhase.Canceled:
                        targetTouch = null;
                        targetPosition = transform.position;
                        canMove = false;
                        break;
                }
            }
            else
            {
                targetTouch = null;
            }
        }
        else if (targetTransform != null)
        {
            targetPosition = targetTransform.position;
        }
        else
        {
            targetPosition = transform.position;
        }
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

    public void OnTouchEnd()
    {
        targetTouch = null;
        canMove = false;
    }

    public void SetOffset(double newOffset)
    {
        offset = newOffset;
    }

    public void SetTargetPosition(Touch touch)
    {
        this.targetTouch = touch;
        InputManager.instance.OnTouchEnd(touch.fingerId, OnTouchEnd);
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
