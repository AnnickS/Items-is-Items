using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class QuestState : MonoBehaviour
{
    public String story = "There once was a butterfly";

    public abstract void Initialize(GameObject questGiver);

    public abstract void ShowStory();

    public abstract bool IsDone();
}
