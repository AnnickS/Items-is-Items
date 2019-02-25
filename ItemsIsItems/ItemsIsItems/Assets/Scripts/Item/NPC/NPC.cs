using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(NPCTarget))]
[RequireComponent(typeof(Rotate))]
public class NPC : CollidableItem {
    private Item OverItem;
    private Rotate Rotation;
    private NPCTarget Target;
    private Vector2 CurrentTarget;
    
    public bool Rotate = false;
    public float Wait = 0;


	// Use this for initialization
	void Start ()
    {
        base.Start();
        gameObject.layer = 9;
        Target = gameObject.GetComponent<NPCTarget>();
        Rotation = gameObject.GetComponent<Rotate>();
        CurrentTarget = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        if (OverItem != null && OverItem.isPickupable)
        {
            //Combination is called
            GameManager.Instance.ExecuteInteraction(this, OverItem);
        }

        if (Rotate)
        {
            Rotation.RotateInPlace();
        }

        //Moves NPC back to base if movement has stopped and timer is finished
        if(Wait == 0)
        {
            CurrentTarget = Target.SelectTarget();
        } else
        {
            Wait--;
        }

        gameObject.GetComponent<MoveTowardPosition>().moveToPosition(CurrentTarget);
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        Item item = other.GetComponent<Item>();

        //Checks if it is a pickubable item
        if (item != null && item.isPickupable)
        {
            GameManager.Instance.ExecuteInteraction(this, item);

        }
        else if (item != null && !item.isPickupable)
        {
            OverItem = item;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Item item = other.GetComponent<Item>();

        if (item != null && item.Equals(OverItem))
        {
            OverItem = null;
        }
    }
}
