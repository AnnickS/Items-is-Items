using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/*
 * Item is required
 * so that when something is given
 * that GameManager.ExecuteInteraction is called
 * Thereby triggering Combination Listener
 */
 
[RequireComponent(typeof(Item))]
[RequireComponent(typeof(BoxCollider2D))]
public class QuestGiver : MonoBehaviour
{
    private QuestState[] states;
    public int currentStateIndex = 0;

    void Start()
    {
       states = this.gameObject.GetComponentsInChildren<QuestState>();
        if (states == null)
        {
            Debug.LogError("QuestGiver Object could not find any QuestStateDialog children");
        }

        if (states.Length == 0)
        {
            Debug.LogError("QuestGiver Object could not find any QuestStateDialog children");
        }

        Item questGiverItem = GetComponent<Item>();
        if (questGiverItem == null)
        {
            Debug.LogError("QuestGiver Object could not find any Item Component");
        }
        

        getCurrentQuestState().Initialize(this.gameObject);
    }

    void FixedUpdate()
    {
        if (states.Length == 0)
        {
            return;
        }

        if(getCurrentQuestState().IsDone())
        {
            if(currentStateIndex + 1 < states.Length)
            {
                currentStateIndex++;
                getCurrentQuestState().Initialize(this.gameObject);
            }
        }
    }

    public void OnMouseDown()
    {
        if(states.Length == 0)
        {
            return;
        }

        getCurrentQuestState().ShowStory();
    }

    public QuestState getCurrentQuestState()
    {
        return states[currentStateIndex];
    }
}
