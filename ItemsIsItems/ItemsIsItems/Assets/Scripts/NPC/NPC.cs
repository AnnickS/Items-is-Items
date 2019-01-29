using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Item {
    public List<string> AttractedTo;
    public List<string> ScaredOf;
    public List<string> HostileTo;
    public Inventory NPCInventory;
    public Vector2 target;
    public string targetName;
    public int count = 0;

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
	}

    //Gets a direction for the npc to go towards
    private Vector2 SelectTarget()
    {
        Vector2 CurrentPosition = new Vector2(transform.position.x, transform.position.y);
        Item current;
        Transform cTransform;
        count = WithinView.Count;

        if(WithinView.Count >= 1)
        {
            current = WithinView[0];
            cTransform = current.GetComponent<Transform>();
            CurrentPosition = new Vector2(cTransform.position.x, cTransform.position.y);
            targetName = current.gameObject.name;
        }

        /*for(int i = 0; i < WithinView.Count; i++)
        {
            Item current = WithinView[i];
            string name = current.GetComponent<GameObject>().name;

            //Items that the npc is scared of have priority
            if (ScaredOf.Find(delegate(string t) { return t.Contains(name); }) != null)
            {
                Vector2 runFrom = new Vector2(-current.GetComponent<Transform>().position.x, -current.GetComponent<Transform>().position.y);

                return new Vector2(current.GetComponent<Transform>().position.x, current.GetComponent<Transform>().position.y);
            }//Items that the npc is hostile to have the next priority
            else if (HostileTo.Find(delegate (string t) { return t.Contains(name); }) != null)
            {
                //t.GetComponent<GameObject>().name.Contains(name);
                return new Vector2(current.GetComponent<Transform>().position.x, current.GetComponent<Transform>().position.y);
            }//Items that the npc is attracted to have last priority
            else if (AttractedTo.Find(delegate (string t) { return t.Contains(name); }) != null)
            {
                return new Vector2(current.GetComponent<Transform>().position.x, current.GetComponent<Transform>().position.y);
            }
        }*/

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

            if(Vector2.Angle(DirItem, transform.right) < viewAngle / 2)
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
