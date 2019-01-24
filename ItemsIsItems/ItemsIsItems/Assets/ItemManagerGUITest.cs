using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class ItemManagerGUITest
{

    [Test]
    public void ItemManagerGUIResourceExists()
    {
        GameObject itemManagerGUIGameObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("ItemManagerGUI"));
        ItemManagerGUI itemManagerGUI = itemManagerGUIGameObject.GetComponent<ItemManagerGUI>();
        Assert.IsNotNull(itemManagerGUIGameObject);
        MonoBehaviour.Destroy(itemManagerGUIGameObject);
    }

    [Test]
    public void ItemManagerGUIExistsInResource()
    {
        GameObject itemManagerGUIGameObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("ItemManagerGUI"));
        ItemManagerGUI itemManagerGUI = itemManagerGUIGameObject.GetComponent<ItemManagerGUI>();
        Assert.IsNotNull(itemManagerGUI);
        MonoBehaviour.Destroy(itemManagerGUIGameObject);
    }

    // A UnityTest behaves like a coroutine in PlayMode
    // and allows you to yield null to skip a frame in EditMode
    [UnityTest]
    public IEnumerator WhenCombinationNewFullEmptyAgain()
    {
        GameObject itemManagerGUIGameObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("ItemManagerGUI"));
        ItemManagerGUI itemManagerGUI = itemManagerGUIGameObject.GetComponent<ItemManagerGUI>();

        yield return null;

        itemManagerGUI.combinationNew.useItemType = new Item();
        yield return null;
        itemManagerGUI.combinationNew.affectedItemType = new Item();
        yield return null;
        itemManagerGUI.combinationNew.effect = new EffectChangeColor();

        yield return null;

        bool actual = itemManagerGUI.combinationNew.useItemType == null 
            && itemManagerGUI.combinationNew.affectedItemType == null
            && itemManagerGUI.combinationNew.effect == null;

        Assert.IsTrue(actual);

        MonoBehaviour.Destroy(itemManagerGUIGameObject);
    }

    [UnityTest]
    public IEnumerator WhenCombinationNewFullAddToCombinationsDisplay()
    {
        GameObject itemManagerGUIGameObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("ItemManagerGUI"));
        ItemManagerGUI itemManagerGUI = itemManagerGUIGameObject.GetComponent<ItemManagerGUI>();
        ItemManager ItemManager = itemManagerGUIGameObject.GetComponent<ItemManager>();

        yield return null;

        itemManagerGUI.combinationNew.useItemType = new Item();
        yield return null;
        itemManagerGUI.combinationNew.affectedItemType = new Item();
        yield return null;
        itemManagerGUI.combinationNew.effect = new EffectChangeColor();

        yield return null;
        yield return null;
        yield return null;

        int actual = itemManagerGUI.combinationDisplay.Count;
        int expected = 1;

        Assert.AreEqual(expected, actual);

        MonoBehaviour.Destroy(itemManagerGUIGameObject);
    }
}
