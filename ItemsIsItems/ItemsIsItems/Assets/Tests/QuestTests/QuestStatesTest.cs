using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class QuestStatesTest
{

    [Test]
    public void ExampleQuestIsNotNull()
    {
        GameObject quest = MonoBehaviour.Instantiate(Resources.Load<GameObject>("PreFabs/ForTests/TestPrefabForQuestStatesTest"));
        Assert.NotNull(quest);
        MonoBehaviour.Destroy(quest);
    }

    [Test]
    public void ExampleQuestQuestComponentIsNotNull()
    {

        GameObject quest = MonoBehaviour.Instantiate(Resources.Load<GameObject>("PreFabs/ForTests/TestPrefabForQuestStatesTest"));
        QuestGiver questComponent = quest.GetComponent<QuestGiver>();
        Assert.NotNull(questComponent);
        MonoBehaviour.Destroy(quest);
    }

    [Test]
    public void ExampleQuestDialogIsNotNull()
    {

        GameObject quest = MonoBehaviour.Instantiate(Resources.Load<GameObject>("PreFabs/ForTests/TestPrefabForQuestStatesTest"));
        Dialog dialog = quest.GetComponentInChildren<Dialog>();
        Assert.NotNull(dialog);
        MonoBehaviour.Destroy(quest);
    }

    [Test]
    public void GoesToNextQuestState()
    {
        //Not Done
        GameObject quest = MonoBehaviour.Instantiate(Resources.Load<GameObject>("PreFabs/ForTests/TestPrefabForQuestStatesTest"));
        Dialog dialog = quest.GetComponentInChildren<Dialog>();

        Assert.NotNull(dialog);

        MonoBehaviour.Destroy(quest);
    }

}
