using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionRange : MonoBehaviour {
    [SerializeField]
    private LayerMask TargetMask;
    [SerializeField]
    private LayerMask ObstacleMask;
    public Collider2D[] WithinCircle;
    public List<Item> WithinView;
    public List<Item> WithinSmell;
    public float ViewRadius = 5;
    public float ViewAngle = 135;
    
    //Detects game objects within FoV and adds them to WithinView list
    //Items in range but not in view get added to WithinSmell
    public void InRange()
    {
        WithinView.Clear();
        WithinSmell.Clear();

        WithinCircle = Physics2D.OverlapCircleAll(transform.position, ViewRadius, TargetMask);

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
}
