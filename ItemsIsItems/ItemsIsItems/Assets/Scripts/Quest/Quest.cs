using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Quest : MonoBehaviour
{
    public QuestState[] states;
    public int currentStateIndex = 0;

    void Start()
    {
       states = this.gameObject.GetComponentsInChildren<QuestState>();
        if (states == null)
        {
            Debug.LogError("Quest Object could not find any QuestStateDialog children");
        }

        if (states.Length == 0)
        {
            Debug.LogError("Quest Object could not find any QuestStateDialog children");
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
