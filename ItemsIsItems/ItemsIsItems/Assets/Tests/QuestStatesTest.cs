using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;

public class QuestStatesTest
{
    [Test]
    public void ExampleQuestIsNotNull()
    {
        GameObject quest = MonoBehaviour.Instantiate(Resources.Load<GameObject>("ExampleQuest"));
        Assert.NotNull(quest);
        MonoBehaviour.Destroy(quest);
    }

    [Test]
    public void ExampleQuestQuestComponentIsNotNull()
    {

        GameObject quest = MonoBehaviour.Instantiate(Resources.Load<GameObject>("ExampleQuest"));
        Quest questComponent = quest.GetComponent<Quest>();
        Assert.NotNull(questComponent);
        MonoBehaviour.Destroy(quest);
    }

    [Test]
    public void ExampleQuestDialogIsNotNull()
    {

        GameObject quest = MonoBehaviour.Instantiate(Resources.Load<GameObject>("ExampleQuest"));
        Dialog dialog = quest.GetComponentInChildren<Dialog>();
        Assert.NotNull(dialog);
        MonoBehaviour.Destroy(quest);
    }

}
