using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class ItemManagerGUITest
{

    [Test]
    public void ResourceItemManagerGUIExists()
    {
        GameObject itemManagerGUIGameObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("ItemManagerGUI"));
        ItemManagerGUI itemManagerGUI = itemManagerGUIGameObject.GetComponent<ItemManagerGUI>();
        Assert.IsNotNull(itemManagerGUIGameObject);
        MonoBehaviour.Destroy(itemManagerGUIGameObject);
    }

    [Test]
    public void ResourceFlowerRoseExists()
    {
        GameObject flowerRose = MonoBehaviour.Instantiate(Resources.Load<GameObject>("FlowerRose"));
        Item flowerRoseItem = flowerRose.GetComponent<Item>();
        Assert.IsNotNull(flowerRoseItem);
        MonoBehaviour.Destroy(flowerRose);
    }

    [Test]
    public void ResourceCharacterExists()
    {
        GameObject character = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Character"));
        Item characterItem = character.GetComponent<Item>();
        Assert.IsNotNull(characterItem);
        MonoBehaviour.Destroy(character);
    }

    [Test]
    public void ResourceChangeColorEffectExists()
    {
        GameObject effectChangeColor = MonoBehaviour.Instantiate(Resources.Load<GameObject>("ChangeColorEffect"));
        Effect effectChangeColorEffect = effectChangeColor.GetComponent<Effect>();
        Assert.IsNotNull(effectChangeColorEffect);
        MonoBehaviour.Destroy(effectChangeColor);
    }

    [Test]
    public void ItemManagerGUIExistsInResource()
    {
        GameObject itemManagerGUIGameObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("ItemManagerGUI"));
        ItemManagerGUI itemManagerGUI = itemManagerGUIGameObject.GetComponent<ItemManagerGUI>();
        Assert.IsNotNull(itemManagerGUI);
        MonoBehaviour.Destroy(itemManagerGUIGameObject);
    }
    
    [UnityTest]
    public IEnumerator WhenCombinationNewFullEmptyAgain()
    {
        GameObject itemManagerGUIGameObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("ItemManagerGUI"));
        ItemManagerGUI itemManagerGUI = itemManagerGUIGameObject.GetComponent<ItemManagerGUI>();

        GameObject flowerRose = MonoBehaviour.Instantiate(Resources.Load<GameObject>("FlowerRose"));
        Item flowerRoseItem = flowerRose.GetComponent<Item>();
        GameObject effectChangeColor = MonoBehaviour.Instantiate(Resources.Load<GameObject>("ChangeColorEffect"));
        Effect effectChangeColorEffect = effectChangeColor.GetComponent<Effect>();

        yield return null;

        itemManagerGUI.combinationNew.useItemType = flowerRoseItem;
        yield return null;
        itemManagerGUI.combinationNew.affectedItemType = flowerRoseItem;
        yield return null;
        itemManagerGUI.combinationNew.effect = effectChangeColorEffect;

        yield return null;

        bool actual = itemManagerGUI.combinationNew.useItemType == null 
            && itemManagerGUI.combinationNew.affectedItemType == null
            && itemManagerGUI.combinationNew.effect == null;

        Assert.IsTrue(actual);

        MonoBehaviour.Destroy(itemManagerGUIGameObject);
        MonoBehaviour.Destroy(flowerRoseItem);
        MonoBehaviour.Destroy(effectChangeColorEffect);
    }

    [UnityTest]
    public IEnumerator CombinationNewFullAddToCombinationsDisplay()
    {
        GameObject itemManagerGUIGameObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("ItemManagerGUI"));
        ItemManagerGUI itemManagerGUI = itemManagerGUIGameObject.GetComponent<ItemManagerGUI>();
        ItemManager ItemManager = itemManagerGUIGameObject.GetComponent<ItemManager>();

        GameObject flowerRose = MonoBehaviour.Instantiate(Resources.Load<GameObject>("FlowerRose"));
        Item flowerRoseItem = flowerRose.GetComponent<Item>();
        GameObject character = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Character"));
        Item characterItem = character.GetComponent<Item>();
        GameObject effectChangeColor = MonoBehaviour.Instantiate(Resources.Load<GameObject>("ChangeColorEffect"));
        Effect effectChangeColorEffect = effectChangeColor.GetComponent<Effect>();

        yield return null;

        itemManagerGUI.combinationNew.useItemType = flowerRoseItem;
        yield return null;
        itemManagerGUI.combinationNew.affectedItemType = flowerRoseItem;
        yield return null;
        itemManagerGUI.combinationNew.effect = effectChangeColorEffect;

        yield return null;

        yield return null;

        itemManagerGUI.combinationNew.useItemType = flowerRoseItem;
        yield return null;
        itemManagerGUI.combinationNew.affectedItemType = characterItem;
        yield return null;
        itemManagerGUI.combinationNew.effect = effectChangeColorEffect;

        yield return null;

        int actual = itemManagerGUI.combinationDisplay.Count;
        int expected = 2;

        Assert.AreEqual(expected, actual);
        
        MonoBehaviour.Destroy(itemManagerGUIGameObject);
        MonoBehaviour.Destroy(flowerRoseItem);
        MonoBehaviour.Destroy(characterItem);
        MonoBehaviour.Destroy(effectChangeColorEffect);
    }

    [UnityTest]
    public IEnumerator CombinationDisplayAddingKeeps()
    {
        GameObject itemManagerGUIGameObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("ItemManagerGUI"));
        ItemManagerGUI itemManagerGUI = itemManagerGUIGameObject.GetComponent<ItemManagerGUI>();

        GameObject flowerRose = MonoBehaviour.Instantiate(Resources.Load<GameObject>("FlowerRose"));
        Item flowerRoseItem = flowerRose.GetComponent<Item>();
        GameObject character = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Character"));
        Item characterItem = character.GetComponent<Item>();
        GameObject effectChangeColor = MonoBehaviour.Instantiate(Resources.Load<GameObject>("ChangeColorEffect"));
        Effect effectChangeColorEffect = effectChangeColor.GetComponent<Effect>();

        yield return null;
        ItemCombinationGUI newCombination = new ItemCombinationGUI(flowerRoseItem, characterItem, effectChangeColorEffect);
        itemManagerGUI.combinationDisplay.Add(newCombination);
        yield return null;
        yield return null;
        yield return null;

        int actual = itemManagerGUI.combinationDisplay.Count;
        int expected = 1;

        Assert.AreEqual(expected, actual);

        MonoBehaviour.Destroy(itemManagerGUIGameObject);
        MonoBehaviour.Destroy(flowerRoseItem);
        MonoBehaviour.Destroy(characterItem);
        MonoBehaviour.Destroy(effectChangeColorEffect);
    }

    [UnityTest]
    public IEnumerator Search()
    {
        GameObject itemManagerGUIGameObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("ItemManagerGUI"));
        ItemManagerGUI itemManagerGUI = itemManagerGUIGameObject.GetComponent<ItemManagerGUI>();

        GameObject flowerRose = MonoBehaviour.Instantiate(Resources.Load<GameObject>("FlowerRose"));
        Item flowerRoseItem = flowerRose.GetComponent<Item>();
        GameObject character = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Character"));
        Item characterItem = character.GetComponent<Item>();
        GameObject effectChangeColor = MonoBehaviour.Instantiate(Resources.Load<GameObject>("ChangeColorEffect"));
        Effect effectChangeColorEffect = effectChangeColor.GetComponent<Effect>();

        yield return null;
        ItemCombinationGUI combination1 = new ItemCombinationGUI(flowerRoseItem, flowerRoseItem, effectChangeColorEffect);
        ItemCombinationGUI combination2 = new ItemCombinationGUI(flowerRoseItem, characterItem, effectChangeColorEffect);
        ItemCombinationGUI combination3 = new ItemCombinationGUI(characterItem, flowerRoseItem, effectChangeColorEffect);
        itemManagerGUI.combinationDisplay.Add(combination1);
        itemManagerGUI.combinationDisplay.Add(combination2);
        itemManagerGUI.combinationDisplay.Add(combination3);
        Assert.AreEqual(3, itemManagerGUI.combinationDisplay.Count);
        yield return null;
        itemManagerGUI.combinationNew = new ItemCombinationGUI();
        yield return null;

        itemManagerGUI.combinationNew.useItemType = flowerRoseItem;
        yield return null;
        int actual = itemManagerGUI.combinationDisplay.Count;
        int expected = 2;

        Assert.AreEqual(expected, actual);

        MonoBehaviour.Destroy(itemManagerGUIGameObject);
        MonoBehaviour.Destroy(flowerRoseItem);
        MonoBehaviour.Destroy(characterItem);
        MonoBehaviour.Destroy(effectChangeColorEffect);
    }
}
