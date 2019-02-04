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
    public QuestState currentState;

    void Start()
    {
        dialog.setText(text);

        states.Add(new QuestStateAskFor());
        states.Add(new QuestStateIdle());

        goToNextState();
    }

    private void goToNextState()
    {
        int currentStateIndex = getCurrentStateIndex();

        if (currentStateIndex >= states.Count)
        {
            return;
        }
        else
        {
            currentState = states[currentStateIndex + 1];
        }
    }

    private int getCurrentStateIndex()
    {
        if (currentState == null)
        {
            return 0;
        }
        else
        {
            return states.IndexOf(currentState);
        }
    }

    public void OnMouseDown()
    {
        dialog.show();
    }
}
