using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class QuestDialogPopupTest
{
    [UnityTest]
    public IEnumerator DialogPopupStartsHidden()
    {
        GameObject quest = MonoBehaviour.Instantiate(Resources.Load<GameObject>("ExampleQuest"));
        DialogPopup popup = quest.GetComponentInChildren<DialogPopup>();
        yield return null;
        bool isActive = popup.isActiveAndEnabled;

        Assert.IsFalse(isActive);
        GameObject.Destroy(popup);
    }

    [UnityTest]
    public IEnumerator DialogPopupShowsOnQuestClicked()
    {
        GameObject questObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("ExampleQuest"));
        Quest quest = questObject.GetComponent<Quest>();
        DialogPopup popup = questObject.GetComponentInChildren<DialogPopup>();
        yield return null;
        quest.OnMouseDown();
        yield return null;
        yield return null;
        bool isActive = popup.isActiveAndEnabled;

        Assert.IsTrue(isActive);
        GameObject.Destroy(popup);
    }
}
