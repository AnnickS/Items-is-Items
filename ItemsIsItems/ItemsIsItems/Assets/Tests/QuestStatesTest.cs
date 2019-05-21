using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class QuestStatesTest
{

    [Test]
    public void PrefabQuestIsNotNull()
    {
        GameObject quest = MonoBehaviour.Instantiate(Resources.Load<GameObject>("PreFabs/ForTests/TestPrefabForQuestStatesTest"));
        Assert.NotNull(quest);
        MonoBehaviour.Destroy(quest);
    }

    [Test]
    public void PrefabQuestQuestGiverIsNotNull()
    {

        GameObject quest = MonoBehaviour.Instantiate(Resources.Load<GameObject>("PreFabs/ForTests/TestPrefabForQuestStatesTest"));
        QuestGiver questComponent = quest.GetComponent<QuestGiver>();
        Assert.NotNull(questComponent);
        MonoBehaviour.Destroy(quest);
    }

    [Test]
    public void PrefabQuestDialogIsNotNull()
    {

        GameObject quest = MonoBehaviour.Instantiate(Resources.Load<GameObject>("PreFabs/ForTests/TestPrefabForQuestStatesTest"));
        Dialog dialog = quest.GetComponentInChildren<Dialog>();
        Assert.NotNull(dialog);
        MonoBehaviour.Destroy(quest);
    }

    [Test]
    public void GoesToNextQuestState()
    {
        GameObject quest = MonoBehaviour.Instantiate(Resources.Load<GameObject>("PreFabs/ForTests/TestPrefabForQuestStatesTest"));
        Dialog dialog = quest.GetComponentInChildren<Dialog>();

        Assert.NotNull(dialog);

        MonoBehaviour.Destroy(quest);
    }

}
