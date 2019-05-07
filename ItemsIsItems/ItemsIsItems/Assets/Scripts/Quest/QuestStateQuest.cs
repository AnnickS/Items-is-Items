using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestStateQuest : QuestStateDialog
{
    public Combination combination;

    public override void Initialize(GameObject questGiver)
    {
        base.Initialize(questGiver);
        combination.Subscribe(OnItemsCombined);
    }

    public override bool IsDone()
    {
        return isDone;
    }

    public void OnItemsCombined()
    {
        //Debug.Log("OnItemsCombined on "+gameObject.name);
        isDone = true;
        combination.Unsubscribe(OnItemsCombined);
    }
}
