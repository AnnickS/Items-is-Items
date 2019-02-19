using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(NPCTarget))]
[RequireComponent(typeof(NPCInventory))]
[RequireComponent(typeof(Rotate))]
public class NPC : Item {
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
}
