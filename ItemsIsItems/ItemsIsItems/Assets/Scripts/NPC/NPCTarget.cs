using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DetectionRange))]
public class NPCTarget : MonoBehaviour {
    [SerializeField]
    private List<string> AttractedTo;
    [SerializeField]
    private List<string> ScaredOf;
    [SerializeField]
    private List<string> HostileTo;
    private DetectionRange Vision;
    public Vector2 Target;
    private Vector2 Base;

    // Use this for initialization
    void Start () {
        Base = Target = transform.position;
        Vision = gameObject.GetComponent<DetectionRange>();
    }

    //Checks if the NPC wants the item in some way shape or form
    public bool isDesireable(Item item)
    {
        string name = item.name;

        if (ScaredOf.Find(x => name.Contains(x)) != null)
        {
            return true;
        }//Items that the npc is hostile to has next priority
        else if (HostileTo.Find(x => name.Contains(x)) != null)
        {
            return true;
        }//Items that the npc is attracted to have last priority
        else if (AttractedTo.Find(x => name.Contains(x)) != null)
        {
            return true;
        }

        return false;
    }

    //Gets a direction for the npc to go towards
    public Vector2 SelectTarget()
    {
        Vision.InRange();
        gameObject.GetComponent<NPC>().Rotate = false;
        Vector2 CurrentPosition = new Vector2(transform.position.x, transform.position.y);
        Item current;
        Transform cTransform;


        for (int i = 0; i < Vision.WithinView.Count; i++)
        {
            current = Vision.WithinView[i];
            cTransform = current.GetComponent<Transform>();
            string name = current.gameObject.name;

            //NOTE: Needs to change to accept Tags instead of Strings
            //Items that the npc is scared of has first priority
            if (ScaredOf.Find(x => name.Contains(x)) != null)
            {
                gameObject.GetComponent<NPC>().Wait = 100;
                Vector2 ItemPosition = new Vector2(cTransform.position.x, cTransform.position.y);
                ItemPosition -= CurrentPosition;
                ItemPosition.Normalize();
                ItemPosition = new Vector2(-ItemPosition.x * 5, -ItemPosition.y * 5);
                ItemPosition += CurrentPosition;

                return ItemPosition;
            }//Items that the npc is hostile to has next priority
            else if (HostileTo.Find(x => name.Contains(x)) != null)
            {
                gameObject.GetComponent<NPC>().Wait = 100;
                return new Vector2(cTransform.position.x, cTransform.position.y);
            }//Items that the npc is attracted to have last priority
            else if (AttractedTo.Find(x => name.Contains(x)) != null)
            {
                gameObject.GetComponent<NPC>().Wait = 100;
                return new Vector2(cTransform.position.x, cTransform.position.y);
            }
        }

        for (int i = 0; i < Vision.WithinSmell.Count; i++)
        {
            current = Vision.WithinSmell[i];
            cTransform = current.GetComponent<Transform>();
            string name = current.gameObject.name;

            if (ScaredOf.Find(x => name.Contains(x)) != null)
            {
                //Items that the npc is scared of has first priority
                if (name.Contains("Smellable"))
                {
                    gameObject.GetComponent<NPC>().Rotate = true;
                    return CurrentPosition;
                }
            }//Items that the npc is hostile to has next priority
            else if (HostileTo.Find(x => name.Contains(x)) != null)
            {
                //Items that the npc is scared of has first priority
                if (name.Contains("Smellable"))
                {
                    gameObject.GetComponent<NPC>().Rotate = true;
                    return CurrentPosition;
                }
            }//Items that the npc is attracted to have last priority
            else if (AttractedTo.Find(x => name.Contains(x)) != null)
            {
                //Items that the npc is scared of has first priority
                if (name.Contains("Smellable"))
                {
                    gameObject.GetComponent<NPC>().Rotate = true;
                    return CurrentPosition;
                }
            }
        }

        return Base;
    }
}
