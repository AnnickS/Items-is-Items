using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class QuestState : MonoBehaviour
{
    public String text = "Put what you want the quest giver to say here (Story/Hint/etc)";

    public abstract void Initialize(GameObject questGiver);

    public abstract void ShowStory();

    public abstract bool IsDone();
}
