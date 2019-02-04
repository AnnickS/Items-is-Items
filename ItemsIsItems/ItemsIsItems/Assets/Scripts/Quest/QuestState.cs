using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class QuestState
{
    private bool isDone = false;

    public abstract void Initialize();
    public abstract void OnQuestGiverClicked();
    public abstract void FixedUpdate();

    protected void done()
    {
        isDone = true;
    }

    public bool IsDone()
    {
        return isDone;
    }
}
