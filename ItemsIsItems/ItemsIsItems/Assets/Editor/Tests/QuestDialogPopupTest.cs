using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class QuestDialogPopupTest
{
    [UnityTest]
    public IEnumerator DialogPopupStartsHidden()
    {
        GameObject questObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("ExampleQuest"));
        DialogPopup popup = questObject.GetComponentInChildren<DialogPopup>();
        yield return null;
        bool isActive = popup.isActiveAndEnabled;

        Assert.IsFalse(isActive);
        GameObject.Destroy(questObject);
    }

    [UnityTest]
    public IEnumerator DialogPopupShowsOnQuestClicked()
    {
        GameObject questObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("ExampleQuest"));
        QuestGiver quest = questObject.GetComponent<QuestGiver>();
        DialogPopup popup = questObject.GetComponentInChildren<DialogPopup>();
        yield return null;
        quest.OnMouseDown();
        yield return null;
        yield return null;
        bool isActive = popup.isActiveAndEnabled;

        Assert.IsTrue(isActive);
        GameObject.Destroy(questObject);
    }

    [UnityTest]
    public IEnumerator QuestHasStates()
    {
        GameObject questObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("ExampleQuest"));
        QuestGiver quest = questObject.GetComponent<QuestGiver>();
        DialogPopup popup = questObject.GetComponentInChildren<DialogPopup>();
        yield return null;
        int count = quest.GetComponentsInChildren<QuestState>().Length;

        Assert.Greater(count, 0, "There are no QuestStates in ExampleQuest, there need to be some to test DialogPopupTextChangeToQuestState");
        GameObject.Destroy(questObject);
    }

    [UnityTest]
    public IEnumerator DialogPopupTextEqualInitialState()
    {
        GameObject questObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("ExampleQuest"));
        QuestGiver quest = questObject.GetComponent<QuestGiver>();
        DialogPopup popup = questObject.GetComponentInChildren<DialogPopup>();
        yield return null;
        string actual = popup.getText();
        string expected = quest.getCurrentQuestState().text;
        Assert.AreNotEqual(expected, actual, "The default textmesh text didn't change to the quest state's text");
        GameObject.Destroy(questObject);
    }
}
