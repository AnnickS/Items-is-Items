using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Quest : MonoBehaviour
{

    public Dialog dialog;
    public string text = "Hi I'm flowey";
    public List<QuestState> states = new List<QuestState>();
    public int currentStateIndex = 0;

    void Start()
    {
        states.Add(new QuestStateAskFor(dialog, "By the power invested in me... Gimme a flower!"));
        states.Add(new QuestStateIdle(dialog, "I'm currently Idle, bugger off?!"));

        getCurrentQuestState().Initialize();
    }

    void FixedUpdate()
    {
        getCurrentQuestState().FixedUpdate();

        if(getCurrentQuestState().IsDone())
        {
            if(currentStateIndex + 1 < states.Count)
            {
                currentStateIndex++;
                getCurrentQuestState().Initialize();
            }
        }
    }

    public void OnMouseDown()
    {
        getCurrentQuestState().OnQuestGiverClicked();
    }

    public QuestState getCurrentQuestState()
    {
        return states[currentStateIndex];
    }
}
