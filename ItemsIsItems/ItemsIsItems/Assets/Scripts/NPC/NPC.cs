using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Item {
    public List<string> AttractedTo;
    public List<string> ScaredOf;
    public List<string> HostileTo;
    public Vector2 Target;
    public Vector2 Base;

    Collider2D[] WithinCircle;
    public LayerMask ObstacleMask;
    public List<Item> WithinView;
    public List<Item> WithinSmell;
    public bool Rotate = false;
    public float ViewRadius = 5;
    public float ViewAngle = 135;
    public float RotationSpeed = 10F;
    public float Wait = 100;


	// Use this for initialization
	void Start () {
        Base = Target = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (Rotate)
        {
            transform.Rotate(new Vector3(0, 0, 1.5F));
        }
        InView();

        //Moves NPC back to base if movement has stopped and timer is finished
        if(Wait == 0)
        {
            Target = SelectTarget();
        } else
        {
            Wait--;
        }
        gameObject.GetComponent<MoveTowardPosition>().moveToPosition(Target);
	}

    //Gets a direction for the npc to go towards
    private Vector2 SelectTarget()
    {
        Rotate = false;
        Vector2 CurrentPosition = new Vector2(transform.position.x, transform.position.y);
        Item current;
        Transform cTransform;
        

        for(int i = 0; i < WithinView.Count; i++)
        {
            current = WithinView[i];
            cTransform = current.GetComponent<Transform>();
            string name = current.gameObject.name;
            
            //NOTE: Needs to change to accept Tags instead of Strings
            //Items that the npc is scared of has first priority
            if (ScaredOf.Find(x => name.Contains(x)) != null)
            {
                Wait = 100;
                Vector2 ItemPosition = new Vector2(cTransform.position.x, cTransform.position.y);
                ItemPosition -= CurrentPosition;
                ItemPosition.Normalize();
                ItemPosition = new Vector2(-ItemPosition.x*5, -ItemPosition.y*5);
                ItemPosition += CurrentPosition;

                return ItemPosition;
            }//Items that the npc is hostile to has next priority
            else if (HostileTo.Find(x => name.Contains(x)) != null)
            {
                Wait = 100;
                return new Vector2(cTransform.position.x, cTransform.position.y);
            }//Items that the npc is attracted to have last priority
            else if (AttractedTo.Find(x => name.Contains(x)) != null)
            {
                Wait = 100;
                return new Vector2(cTransform.position.x, cTransform.position.y);
            }
        }

        for (int i = 0; i < WithinSmell.Count; i++)
        {
            current = WithinSmell[i];
            cTransform = current.GetComponent<Transform>();
            string name = current.gameObject.name;

            if (ScaredOf.Find(x => name.Contains(x)) != null)
            {
                //Items that the npc is scared of has first priority
                if (name.Contains("Smellable"))
                {
                    Rotate = true;
                    return CurrentPosition;
                }
            }//Items that the npc is hostile to has next priority
            else if (HostileTo.Find(x => name.Contains(x)) != null)
            {
                //Items that the npc is scared of has first priority
                if (name.Contains("Smellable"))
                {
                    Rotate = true;
                    return CurrentPosition;
                }
            }//Items that the npc is attracted to have last priority
            else if (AttractedTo.Find(x => name.Contains(x)) != null)
            {
                //Items that the npc is scared of has first priority
                if (name.Contains("Smellable"))
                {
                    Rotate = true;
                    return CurrentPosition;
                }
            }
        }

        return Base;
    }

    //Detects game objects within FoV and adds them to WithinView list
    private void InView()
    {
        WithinCircle = Physics2D.OverlapCircleAll(transform.position, ViewRadius);
        WithinView.Clear();
        WithinSmell.Clear();

        for(int i = 0; i < WithinCircle.Length; i++)
        {
            Transform ItemTransform = WithinCircle[i].transform;
            
            //Checks to see if object is an item
            if((ItemTransform.GetComponent<Item>() != null) && (ItemTransform.GetComponent<Item>().isPickupable))
            {
                Vector2 DirItem = new Vector2(ItemTransform.position.x - transform.position.x, ItemTransform.position.y - transform.position.y);

                //Checks if object is within viewing distance
                if (Vector2.Angle(DirItem, -transform.up) < ViewAngle / 2)
                {
                    float Distance = Vector2.Distance(transform.position, ItemTransform.position);

                    //obstacles will be below the layer the object is in
                    if (!Physics2D.Raycast(transform.position, DirItem, Distance, ObstacleMask))
                    {
                        WithinView.Add(WithinCircle[i].GetComponent<Item>());
                    }
                }//If object isn't viewable, it's smellable
                else
                {
                    WithinSmell.Add(WithinCircle[i].GetComponent<Item>());
                }
            } else { continue;  }
        }
    }

}
