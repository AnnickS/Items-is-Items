using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEngine.SceneManagement;

public class CombinationTest {

    [Test]
    public void ItemValidatorTrueTest() {
        ItemValidator val = ScriptableObject.CreateInstance<ItemValidator>();
        val.name = "Tester";

        GameObject obj = new GameObject();
        Item item = obj.AddComponent<Item>();
        item.name = "Tester";

        Assert.IsTrue(val.ValidateItem(item));

        ScriptableObject.DestroyImmediate(val);
        CleanUpScene();
    }

    [Test]
    public void ItemValidatorFalseTest()
    {
        ItemValidator val = ScriptableObject.CreateInstance<ItemValidator>();
        val.name = "Tester";

        GameObject obj = new GameObject();
        Item item = obj.AddComponent<Item>();
        item.name = "NotTester";

        Assert.IsFalse(val.ValidateItem(item));

        ScriptableObject.DestroyImmediate(val);
        CleanUpScene();
    }

    [Test]
    public void DescriptorValidatorTrueTest()
    {
        Descriptor desc = ScriptableObject.CreateInstance<Descriptor>();
        desc.name = "DescriptorTest";

        DescriptorValidator val = ScriptableObject.CreateInstance<DescriptorValidator>();
        val.descriptor = desc;

        GameObject obj = new GameObject();
        Item item = obj.AddComponent<Item>();
        item.Descriptors.Add(desc);

        Assert.IsTrue(val.ValidateItem(item));

        CleanUpScene();
        ScriptableObject.DestroyImmediate(desc);
        ScriptableObject.DestroyImmediate(val);
    }

    [Test]
    public void WithWrongDescriptorValidatorFalseTest()
    {
        Descriptor descRight = ScriptableObject.CreateInstance<Descriptor>();
        descRight.name = "DescriptorRight";

        Descriptor descWrong = ScriptableObject.CreateInstance<Descriptor>();
        descWrong.name = "DescriptorWrong";

        DescriptorValidator val = ScriptableObject.CreateInstance<DescriptorValidator>();
        val.descriptor = descWrong;

        GameObject obj = new GameObject();
        Item item = obj.AddComponent<Item>();
        item.Descriptors.Add(descRight);

        Assert.IsFalse(val.ValidateItem(item));

        CleanUpScene();
        ScriptableObject.DestroyImmediate(descRight);
        ScriptableObject.DestroyImmediate(descWrong);
        ScriptableObject.DestroyImmediate(val);
    }

    [Test]
    public void SubDescriptorValidatorFalseTest()
    {
        // Child is accepted by Parent Validtor
        //  Parent
        //      \- Child
        //
        //  Goblin Chief
        //      \- Goblin
        Descriptor descParent = ScriptableObject.CreateInstance<Descriptor>();
        descParent.name = "DescriptorParent";

        Descriptor descChild = ScriptableObject.CreateInstance<Descriptor>();
        descChild.name = "DescriptorChild";

        descParent.children.Add(descChild);

        DescriptorValidator val = ScriptableObject.CreateInstance<DescriptorValidator>();
        val.descriptor = descChild;

        GameObject obj = new GameObject();
        Item item = obj.AddComponent<Item>();
        item.Descriptors.Add(descParent);

        Assert.IsTrue(val.ValidateItem(item));

        CleanUpScene();
        ScriptableObject.DestroyImmediate(descChild);
        ScriptableObject.DestroyImmediate(descParent);
        ScriptableObject.DestroyImmediate(val);
    }

    [Test]
    public void WithoutDescriptorValidatorFalseTest()
    {
        Descriptor desc = ScriptableObject.CreateInstance<Descriptor>();
        desc.name = "DescriptorTest";

        DescriptorValidator val = ScriptableObject.CreateInstance<DescriptorValidator>();
        val.descriptor = desc;

        GameObject obj = new GameObject();
        Item item = obj.AddComponent<Item>();
        //item.Descriptors.Add(descWrong); //Desciptor is NOT added

        Assert.IsFalse(val.ValidateItem(item));

        CleanUpScene();
        ScriptableObject.DestroyImmediate(desc);
        ScriptableObject.DestroyImmediate(val);
    }

    [Test]
    public void CombinationIsInitNoneTest()
    {
        Combination comb = ScriptableObject.CreateInstance<Combination>();

        bool isInit = comb.IsInitialized();

        Assert.IsFalse(isInit);

        ScriptableObject.DestroyImmediate(comb);
    }

    [Test]
    public void CombinationIsInitOneTest()
    {
        Descriptor desc = ScriptableObject.CreateInstance<Descriptor>();
        desc.name = "Descriptor";

        DescriptorValidator descVal = ScriptableObject.CreateInstance<DescriptorValidator>();
        descVal.descriptor = desc;

        Combination comb = ScriptableObject.CreateInstance<Combination>();
        comb.itemValidator1 = descVal;

        bool isInit = comb.IsInitialized();

        Assert.IsFalse(isInit);

        ScriptableObject.DestroyImmediate(comb);
        ScriptableObject.DestroyImmediate(descVal);
        ScriptableObject.DestroyImmediate(desc);
    }

    [Test]
    public void CombinationIsInitOtherOneTest()
    {
        Descriptor desc = ScriptableObject.CreateInstance<Descriptor>();
        desc.name = "Descriptor";

        DescriptorValidator descVal = ScriptableObject.CreateInstance<DescriptorValidator>();
        descVal.descriptor = desc;

        Combination comb = ScriptableObject.CreateInstance<Combination>();
        comb.itemValidator2 = descVal;

        bool isInit = comb.IsInitialized();

        Assert.IsFalse(isInit);
        
        ScriptableObject.DestroyImmediate(comb);
        ScriptableObject.DestroyImmediate(descVal);
        ScriptableObject.DestroyImmediate(desc);
    }

    [Test]
    public void CombinationIsInitTwoTest()
    {
        Descriptor desc = ScriptableObject.CreateInstance<Descriptor>();
        desc.name = "Descriptor";

        DescriptorValidator descVal = ScriptableObject.CreateInstance<DescriptorValidator>();
        descVal.descriptor = desc;

        ItemValidator itemVal = ScriptableObject.CreateInstance<ItemValidator>();
        itemVal.name = "Item";

        Combination comb = ScriptableObject.CreateInstance<Combination>();
        comb.itemValidator1 = descVal;
        comb.itemValidator2 = itemVal;

        bool isInit = comb.IsInitialized();

        Assert.IsTrue(isInit);
        
        ScriptableObject.DestroyImmediate(comb);
        ScriptableObject.DestroyImmediate(itemVal);
        ScriptableObject.DestroyImmediate(descVal);
        ScriptableObject.DestroyImmediate(desc);
    }

    [Test]
    public void CombinationEventTest()
    {
        Descriptor desc = ScriptableObject.CreateInstance<Descriptor>();
        desc.name = "Descriptor";

        DescriptorValidator descVal = ScriptableObject.CreateInstance<DescriptorValidator>();
        descVal.descriptor = desc;

        ItemValidator itemVal = ScriptableObject.CreateInstance<ItemValidator>();
        itemVal.name = "Item";

        GameObject obj1 = new GameObject();
        Item item1 = obj1.AddComponent<Item>();
        item1.Descriptors.Add(desc);

        GameObject obj2 = new GameObject();
        Item item2 = obj2.AddComponent<Item>();
        item2.name = "Item";

        Combination comb = ScriptableObject.CreateInstance<Combination>();
        comb.itemValidator1 = descVal;
        comb.itemValidator2 = itemVal;

        bool success = false;
        comb.Subscribe(new CombinationEventHandler(() => success = true));
        if(comb.IsMatch(item1, item2))
        {
            comb.Execute(item1, item2);
        }

        Assert.IsTrue(success);

        CleanUpScene();
        ScriptableObject.DestroyImmediate(comb);
        ScriptableObject.DestroyImmediate(itemVal);
        ScriptableObject.DestroyImmediate(descVal);
        ScriptableObject.DestroyImmediate(desc);
    }

    public GameManager SetUpScene()
    {
        GameObject gameManagerObject = new GameObject("GameManager");
        GameManager gameManager = gameManagerObject.AddComponent<GameManager>();


        return gameManager;
    }

    public void CleanUpScene()
    {
        foreach(Object obj in SceneManager.GetActiveScene().GetRootGameObjects())
        {
            MonoBehaviour.Destroy(obj);
        }
    }
}
