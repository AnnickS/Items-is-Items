﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Item {
    public List<string> AttractedTo;
    public List<string> ScaredOf;
    public List<string> HostileTo;
    public Inventory NPCInventory;
    public Vector2 target;

    public Collider2D[] WithinCircle;
    public LayerMask obstacleMask;
    public List<Item> WithinView;
    public float viewRadius = 5;
    public float viewAngle = 135;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        InView();
        target = SelectTarget();
        gameObject.GetComponent<MoveTowardPosition>().moveToPosition(target);
	}

    //Gets a direction for the npc to go towards
    private Vector2 SelectTarget()
    {
        Vector2 CurrentPosition = new Vector2(transform.position.x, transform.position.y);
        Item current;
        Transform cTransform;
        

        for(int i = 0; i < WithinView.Count; i++)
        {
            current = WithinView[i];
            cTransform = current.GetComponent<Transform>();
            string name = current.gameObject.name;
            
            //Items that the npc is scared of has first priority
            if (ScaredOf.Find(x => name.Contains(x)) != null)
            {
                return new Vector2(-cTransform.position.x, -cTransform.position.y);
            }//Items that the npc is hostile to has next priority
            else if (HostileTo.Find(x => name.Contains(x)) != null)
            {
                return new Vector2(cTransform.position.x, cTransform.position.y);
            }//Items that the npc is attracted to have last priority
            else if (AttractedTo.Find(x => name.Contains(x)) != null)
            {
                return new Vector2(cTransform.position.x, cTransform.position.y);
            }
        }

        return CurrentPosition;
    }

    //Detects game objects within FoV and adds them to WithinView list
    private void InView()
    {
        WithinCircle = Physics2D.OverlapCircleAll(transform.position, viewRadius);
        WithinView.Clear();

        for(int i = 0; i < WithinCircle.Length; i++)
        {
            Transform ItemTransform = WithinCircle[i].transform;
            Vector2 DirItem = new Vector2(ItemTransform.position.x - transform.position.x, ItemTransform.position.y - transform.position.y);

            if(Vector2.Angle(DirItem, -transform.up) < viewAngle / 2)
            {
                float Distance = Vector2.Distance(transform.position, ItemTransform.position);

                //obstacles will be below the layer the object is in
                if(!Physics2D.Raycast(transform.position, DirItem, Distance, obstacleMask))
                {
                    WithinView.Add(WithinCircle[i].GetComponent<Item>());
                }
            }
        }
    }

}
