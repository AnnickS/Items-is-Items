using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class QuestState : MonoBehaviour
{
    private bool isDone = false;

    public abstract void Initialize();
    public abstract void OnQuestGiverClicked();

    protected void done()
    {
        isDone = true;
    }

    public bool IsDone()
    {
        return isDone;
    }
}
