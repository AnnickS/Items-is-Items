using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionRange : MonoBehaviour {
    [SerializeField]
    private LayerMask TargetMask;
    [SerializeField]
    private LayerMask ObstacleMask;
    private Collider2D[] WithinCircle;
    private List<Item> WithinView;
    private List<Item> WithinSmell;
    [SerializeField]
    private float ViewRadius = 5;
    [SerializeField]
    private float ViewAngle = 135;

    private void Start()
    {
        WithinView = new List<Item>();
        WithinSmell = new List<Item>();
    }

    //Detects game objects within FoV and adds them to WithinView list
    //Items in range but not in view get added to WithinSmell
    public void InRange()
    {
        WithinCircle = Physics2D.OverlapCircleAll(transform.position, ViewRadius, TargetMask);
        WithinView.Clear();
        WithinSmell.Clear();

        for (int i = 0; i < WithinCircle.Length; i++)
        {
            Transform ItemTransform = WithinCircle[i].transform;

            //Checks to see if object is an item that can be picked up
            if ((ItemTransform.GetComponent<Item>() != null) && (ItemTransform.GetComponent<Item>().isPickupable))
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
                    } else
                    {
                        WithinSmell.Add(WithinCircle[i].GetComponent<Item>());
                    }
                }//If object isn't viewable, it's smellable
                else
                {
                    if (WithinCircle[i].gameObject != this.gameObject)
                    {
                        WithinSmell.Add(WithinCircle[i].GetComponent<Item>());
                    }
                }
            }
            else { continue; }
        }
    }

    public List<Item> withinView()
    {
        return WithinView;
    }

    public List<Item> withinSmell()
    {
        return WithinSmell;
    }

    public Collider2D[] withinCircle()
    {
        return WithinCircle;
    }
}
