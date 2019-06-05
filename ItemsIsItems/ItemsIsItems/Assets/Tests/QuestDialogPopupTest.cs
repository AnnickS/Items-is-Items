using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class DialogPopupTest
{
    [Test]
    public void ExampleQuestIsNotNull()
    {
        GameObject quest = MonoBehaviour.Instantiate(Resources.Load<GameObject>("PreFabs/ForTests/TestPrefabForQuestDialogPopupTest"));
        Assert.NotNull(quest);
        MonoBehaviour.Destroy(quest);
    }

    [Test]
    public void ExampleQuestHasRotateTowardPosition()
    {
        GameObject quest = MonoBehaviour.Instantiate(Resources.Load<GameObject>("PreFabs/ForTests/TestPrefabForQuestDialogPopupTest"));
        RotateTowardPosition rotateTowardPosition = quest.GetComponent<RotateTowardPosition>();

        Assert.NotNull(rotateTowardPosition);

        MonoBehaviour.Destroy(quest);
    }

    [UnityTest]
    public IEnumerator DialogPopupStartsHidden()
    {
        GameObject questObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("PreFabs/ForTests/TestPrefabForQuestDialogPopupTest"));
        DialogPopup popup = questObject.GetComponentInChildren<DialogPopup>();
        yield return null;
        bool isActive = popup.isActiveAndEnabled;

        Assert.IsFalse(isActive);
        GameObject.Destroy(questObject);
    }

    [UnityTest]
    public IEnumerator DialogPopupShowsOnQuestClicked()
    {
        GameObject questObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("PreFabs/ForTests/TestPrefabForQuestDialogPopupTest"));
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
    public IEnumerator DialogPopupDoesntMoveWhenObjectDoes()
    {
        GameObject questNPC = MonoBehaviour.Instantiate(Resources.Load<GameObject>("PreFabs/NPC/Doctor_Base"));
        questNPC.transform.position = new Vector3(0, 0, 0);
        TextSortingPosition Sort = questNPC.GetComponentInChildren<DialogPopup>().GetComponentInChildren<TextSortingPosition>();
        yield return null;
        yield return null;
        Vector3 prevPosition = Sort.getPos();
        questNPC.transform.position = new Vector3(10, 10, 0);
        yield return null;
        yield return null;
        Vector3 lastPosition = Sort.getPos();

        Assert.IsTrue(lastPosition == prevPosition);
        GameObject.Destroy(questNPC);
    }

    [UnityTest]
    public IEnumerator DialogPopupDoesntRotateWhenObjectDoes()
    {
        GameObject questNPC = MonoBehaviour.Instantiate(Resources.Load<GameObject>("PreFabs/NPC/Doctor_Base"));
        TextSortingPosition Sort = questNPC.GetComponentInChildren<DialogPopup>().GetComponentInChildren<TextSortingPosition>();
        yield return null;
        yield return null;
        Quaternion prevRot = Sort.getRot();
        questNPC.transform.rotation = new Quaternion( 30, 1, 11, 0);
        yield return null;
        yield return null;
        Quaternion lastRot = Sort.getRot();

        Assert.IsTrue(Quaternion.Angle(Quaternion.Euler(prevRot.x, prevRot.y, prevRot.z), Quaternion.Euler(lastRot.x, lastRot.y, lastRot.z)) < .001);
        GameObject.Destroy(questNPC);
    }

    [UnityTest]
    public IEnumerator QuestHasStates()
    {
        GameObject questObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("PreFabs/ForTests/TestPrefabForQuestDialogPopupTest"));
        QuestGiver quest = questObject.GetComponent<QuestGiver>();

        yield return null;
        int count = quest.GetComponentsInChildren<QuestState>().Length;

        Assert.Greater(count, 0, "There are no QuestStates in ExampleQuest, there need to be some to test DialogPopupTextChangeToQuestState");
        GameObject.Destroy(questObject);
    }

    [UnityTest]
    public IEnumerator DialogPopupTextEqualInitialState()
    {
        GameObject questObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("PreFabs/ForTests/TestPrefabForQuestDialogPopupTest"));
        QuestGiver quest = questObject.GetComponent<QuestGiver>();
        DialogPopup popup = questObject.GetComponentInChildren<DialogPopup>();
        yield return null;
        string actual = popup.getText();
        string expected = quest.getCurrentQuestState().text;
        Assert.AreNotEqual(expected, actual, "The default textmesh text didn't change to the quest state's text. Expected: " + expected + " Actual: " + actual);
        GameObject.Destroy(questObject);
    }

    [UnityTest]
    public IEnumerator DialogPopupTextEqualQuestStateAfterClick()
    {
        GameObject questObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("PreFabs/ForTests/TestPrefabForQuestDialogPopupTest"));
        QuestGiver quest = questObject.GetComponent<QuestGiver>();
        DialogPopup popup = questObject.GetComponentInChildren<DialogPopup>();
        yield return null;
        quest.OnMouseDown();
        yield return null;
        string actual = popup.getText();
        string expected = quest.getCurrentQuestState().text;
        Assert.AreEqual(expected, actual, "The default textmesh text didn't change to the quest state's text. Expected: " + expected + " Actual: " + actual);
        GameObject.Destroy(questObject);
    }
}
