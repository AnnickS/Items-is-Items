﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DetectionRange))]
public class NPCTarget : MonoBehaviour {

    [Range(0, 10)]
    public float waitTime = 0;
    [SerializeField]
    private List<Descriptor> AttractedTo;
    [SerializeField]
    private List<Descriptor> ScaredOf;
    [SerializeField]
    private List<Descriptor> HostileTo;
    private DetectionRange Vision;
    private Vector2 Base;
    Descriptor smelly;
    public bool goesToBase = true;

    // Use this for initialization
    void Start () {
        Base = transform.position;
        Vision = gameObject.GetComponent<DetectionRange>();
        smelly = Resources.Load<Descriptor>("Descriptors/Smelly");
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

            //Items that the npc is scared of has first priority
            if (ScaredOf.Find(x => current.HasDescriptor(x)))
            {
                StartCoroutine(gameObject.GetComponent<NPC>().Wait(waitTime));
                Vector2 ItemPosition = new Vector2(cTransform.position.x, cTransform.position.y);
                ItemPosition -= CurrentPosition;
                ItemPosition.Normalize();
                ItemPosition = new Vector2(-ItemPosition.x * 5, -ItemPosition.y * 5);
                ItemPosition += CurrentPosition;

                return ItemPosition;
            }//Items that the npc is hostile to has next priority
            else if (HostileTo.Find(x => current.HasDescriptor(x)))
            {
                StartCoroutine(gameObject.GetComponent<NPC>().Wait(waitTime));
                return new Vector2(cTransform.position.x, cTransform.position.y);
            }//Items that the npc is attracted to have last priority
            else if (AttractedTo.Find(x => current.HasDescriptor(x)))
            {
                StartCoroutine(gameObject.GetComponent<NPC>().Wait(waitTime));
                return new Vector2(cTransform.position.x, cTransform.position.y);
            }
        }

        for (int i = 0; i < Vision.WithinSmell.Count; i++)
        {
            current = Vision.WithinSmell[i];
            string name = current.gameObject.name;

            if (ScaredOf.Find(x => current.HasDescriptor(x)) != null)
            {
                //Items that the npc is scared of has first priority
                if (current.HasDescriptor(smelly))
                {
                    gameObject.GetComponent<NPC>().Rotate = true;
                    return CurrentPosition;
                }
            }//Items that the npc is hostile to has next priority
            else if (HostileTo.Find(x => current.HasDescriptor(x)) != null)
            {
                //Items that the npc is scared of has first priority
                if (current.HasDescriptor(smelly))
                {
                    gameObject.GetComponent<NPC>().Rotate = true;
                    return CurrentPosition;
                }
            }//Items that the npc is attracted to have last priority
            else if (AttractedTo.Find(x => current.HasDescriptor(x)) != null)
            {
                //Items that the npc is scared of has first priority
                if (current.HasDescriptor(smelly))
                {
                    gameObject.GetComponent<NPC>().Rotate = true;
                    return CurrentPosition;
                }
            }
        }
        
        if (goesToBase)
        {
            return Base;
        } else
        {
            return new Vector2(this.transform.position.x, this.transform.position.y);
        }
    }
}
