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
        GameObject quest = MonoBehaviour.Instantiate(Resources.Load<GameObject>("ExampleQuest"));
        Assert.NotNull(quest);
        MonoBehaviour.Destroy(quest);
    }

    [Test]
    public void ExampleQuestQuestComponentIsNotNull()
    {

        GameObject quest = MonoBehaviour.Instantiate(Resources.Load<GameObject>("ExampleQuest"));
        QuestGiver questComponent = quest.GetComponent<QuestGiver>();
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

    [Test]
    public void test()
    {
        GameObject questGiver = new GameObject();
        GameObject dialog = new GameObject();
        GameObject textMesh = new GameObject();

        dialog.transform.parent = questGiver.transform;
        textMesh.transform.parent = dialog.transform;

        textMesh.AddComponent<TextMeshPro>();
        dialog.AddComponent<DialogPopup>();
        questGiver.AddComponent<QuestGiver>();

        MonoBehaviour.Destroy(questGiver);
    }

}
