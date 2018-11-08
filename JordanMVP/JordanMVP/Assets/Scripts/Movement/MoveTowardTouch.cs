using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardTouch : MoveTowardPosition
{

    private GameObject targetGameObject;
    bool move = false;

    void OnTriggerEnter2D(Collider2D col)
    {
        targetGameObject = col.gameObject;
        move = false;

    }

    void OnTriggerExit2D(Collider2D col)
    {
        move = true;

    }

    void FixedUpdate()
    {
        if (move)
        {
            base.moveToPosition(targetGameObject.transform.position);
        }
        base.FixedUpdate();
    }
}
