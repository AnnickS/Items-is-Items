using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Pickup : MoveTowardPosition
{
    //inventory put into UI

    void OnMouseDown()
    {
        Selected.getInstance().Select(this);
    }

    //inventory Follow Player
    //*
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
        if(move)
        {
            base.moveToPosition(targetGameObject.transform.position);
        }
        base.FixedUpdate();
    }

    //*/
}
