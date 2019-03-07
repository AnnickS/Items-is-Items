using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LoadScene))]
public class QuestStateGoToScene : QuestState
{
    public string SceneToLoad;

    public override void Initialize(GameObject questGiver)
    {
        GetComponent<LoadScene>().LoadSceneByName(SceneToLoad);
    }

    public override bool IsDone()
    {
        return false; //Will go to a different scene instead of loading
    }

    public override void ShowStory()
    {

    }
}
