using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(NPCTarget))]
[RequireComponent(typeof(Rotate))]
[RequireComponent(typeof(RotateTowardPosition))]
public class NPC : CollidableItem {
    private Item OverItem;
    private Rotate Rotation;
    private NPCTarget Target;

    public Vector2 CurrentTarget;
    public bool Rotate = false;
    public bool isWaiting = false;

    public bool resetRotationAtRest = true;

    public bool restWithStartingRotation = true;
    private Vector2 startingRotation;


    // Use this for initialization
    new void Start ()
    {
        base.Start();
        gameObject.layer = LayerMask.NameToLayer("NPC");
        Target = gameObject.GetComponent<NPCTarget>();
        Rotation = gameObject.GetComponent<Rotate>();
        CurrentTarget = transform.position;
        
        Vector3 forwardPosition = transform.position + transform.up*-1;
        startingRotation = new Vector2(forwardPosition.x, forwardPosition.y);
    }
	
	// Update is called once per frame
	void Update () {
        if (OverItem != null && OverItem.inWorld)
        {
            //Combination is called
            GameManager.Instance.ExecuteInteraction(this, OverItem);
        }

        if (Rotate)
        {
            Rotation.RotateInPlace();
        }

        //Moves NPC back to base if movement has stopped and timer is finished
        if(isWaiting == false)
        {
            CurrentTarget = Target.SelectTarget();
        } 

        if((CurrentTarget.x == this.transform.position.x) && (CurrentTarget.y == this.transform.position.y) && resetRotationAtRest)
        {
            Vector2 restingRotation = new Vector2(transform.position.x, transform.position.y - 1);
            if (restWithStartingRotation)
            {
                restingRotation = startingRotation;
            }
            gameObject.GetComponent<RotateTowardPosition>().rotateToPosition(restingRotation);
        } else
        {
            gameObject.GetComponent<MoveTowardPosition>().moveToPosition(CurrentTarget);
        }
	}

    public IEnumerator Wait(float time)
    {
        if(time >= 0)
        {
            isWaiting = true;
            yield return new WaitForSeconds(time);
            isWaiting = false;
        }
        else
        {
            Debug.LogWarning("NPC Wait time cannot be less than 0");
        }
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Item item = other.GetComponent<Item>();

        Debug.Log("In here for " + this.gameObject.name);
        //Checks if it is a pickubable item
        if (item != null && item.inWorld && GameManager.Instance != null)
        {
            GameManager.Instance.ExecuteInteraction(this, item);

        }
        else if (item != null && !item.inWorld)
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
