using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestStateQuest : QuestStateDialog, CombinationListener
{
    public Validator validator;
    bool isDone = false;
    GameObject questGiver;

    public override void Initialize(GameObject questGiver)
    {
        base.Initialize(questGiver);
        this.questGiver = questGiver;
        GameManager.Instance.AddCombinationListener(this);
    }

    public override bool IsDone()
    {
        return isDone;
    }

    public void ItemsCombined(Item item1, Item item2)
    {
        if(isQuestGiverItem(item1))
        {
            if(validator.ItemMatch(item2))
            {
                isDone = true;
                GameManager.Instance.RemoveCombinationListener(this);
            }
        }
        else if (isQuestGiverItem(item2))
        {
            if (validator.ItemMatch(item1))
            {
                isDone = true;
                GameManager.Instance.RemoveCombinationListener(this);
            }
        }

    }

    private bool isQuestGiverItem(Item item)
    {
        if(questGiver.Equals(item.gameObject))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
