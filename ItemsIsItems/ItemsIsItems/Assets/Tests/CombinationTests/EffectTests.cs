using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class EffectTests {

    [Test]
    public void EffectSpawnAtTest()
    {
        SetUpScene();

        GameObject targetPositionObj = new GameObject("targetPosition");
        targetPositionObj.transform.position = new Vector3(10, 10, 10);
        GameObject objToClone = new GameObject("ObjectToBeClone");
        objToClone.AddComponent<Item>();

        EffectSpawnAt spawnAt = ScriptableObject.CreateInstance<EffectSpawnAt>();
        spawnAt.targetItemPosition = targetPositionObj;
        spawnAt.prefab = objToClone;

        spawnAt.Execute(null, null);

        GameObject cloned = GameObject.Find(objToClone.name+"(Clone)");
        Assert.NotNull(cloned);
        Assert.IsTrue(targetPositionObj.transform.position == cloned.transform.position);

        ScriptableObject.DestroyImmediate(spawnAt);
        CleanUpScene();
    }

    [Test]
    public void EffectSpawnItemTest()
    {
        SetUpScene();

        GameObject interacteeObj = new GameObject("interactee");
        Item target = interacteeObj.AddComponent<Item>();
        interacteeObj.transform.position = new Vector3(10, 10, 10);

        GameObject objToClone = new GameObject("ObjectToBeClone");
        objToClone.AddComponent<Item>();

        EffectSpawnItem spawn = ScriptableObject.CreateInstance<EffectSpawnItem>();
        spawn.itemToSpawn = objToClone;

        spawn.Execute(null, target);

        GameObject cloned = GameObject.Find("ObjectToBeClone(Clone)");
        Assert.NotNull(cloned);
        Assert.IsTrue(interacteeObj.transform.position == cloned.transform.position);

        ScriptableObject.DestroyImmediate(spawn);
        CleanUpScene();
    }

    [Test]
    public void EffectTeleportToJailTest()
    {
        SetUpScene();

        GameObject jailObj = new GameObject("jail");
        jailObj.transform.position = new Vector3(10, 10, 10);

        GameObject objToMove = new GameObject("ObjectToMove");
        Item mover = objToMove.AddComponent<Item>();

        GameObject sendingObj = new GameObject("SenderObject");
        Item sender = sendingObj.AddComponent<Item>();
        sender.jail = jailObj;

        EffectTeleportToJail tpToJail = ScriptableObject.CreateInstance<EffectTeleportToJail>();

        tpToJail.Execute(sender, mover);

        Assert.IsTrue(jailObj.transform.position == objToMove.transform.position);

        ScriptableObject.DestroyImmediate(tpToJail);
        CleanUpScene();
    }

    [Test]
    public void EffectDestroyItemTest()
    {
        SetUpScene();

        GameObject objToBeDestroyed = new GameObject("ObjectToBeDestroyed");
        Item destroyed = objToBeDestroyed.AddComponent<Item>();

        EffectDestroyItem destroySecond = ScriptableObject.CreateInstance<EffectDestroyItem>();

        destroySecond.Execute(null, destroyed);

        Assert.IsTrue(destroyed.IsDestroyed());

        ScriptableObject.DestroyImmediate(destroySecond);
        CleanUpScene();
    }

    [Test]
    public void CraftEffectDestroyNoneTest()
    {
        SetUpScene();

        GameObject obj1 = new GameObject("Object1");
        Item item1 = obj1.AddComponent<Item>();

        GameObject obj2 = new GameObject("Object2");
        Item item2 = obj2.AddComponent<Item>();
        obj2.transform.position = new Vector3(10, 10, 10);

        GameObject objToSpawn = new GameObject("objToSpawn");
        Item spawned = objToSpawn.AddComponent<Item>();

        CraftEffect craft = ScriptableObject.CreateInstance<CraftEffect>();
        craft.deleteItem1 = false;
        craft.deleteItem2 = false;
        craft.itemsToSpawn.Add(objToSpawn);

        craft.Execute(item1, item2);

        Assert.IsTrue(item1.IsDestroyed() == false);
        Assert.IsTrue(item2.IsDestroyed() == false);

        ScriptableObject.DestroyImmediate(craft);
        CleanUpScene();
    }

    [Test]
    public void CraftEffectDestroyOneTest()
    {
        SetUpScene();

        GameObject obj1 = new GameObject("Object1");
        Item item1 = obj1.AddComponent<Item>();

        GameObject obj2 = new GameObject("Object2");
        Item item2 = obj2.AddComponent<Item>();
        obj2.transform.position = new Vector3(10, 10, 10);

        GameObject objToSpawn = new GameObject("objToSpawn");
        Item spawned = objToSpawn.AddComponent<Item>();

        CraftEffect craft = ScriptableObject.CreateInstance<CraftEffect>();
        craft.deleteItem1 = true;
        craft.deleteItem2 = false;
        craft.itemsToSpawn.Add(objToSpawn);

        craft.Execute(item1, item2);

        Assert.IsTrue(item1.IsDestroyed());
        Assert.IsTrue(item2.IsDestroyed() == false);

        ScriptableObject.DestroyImmediate(craft);
        CleanUpScene();
    }

    [Test]
    public void CraftEffectDestroyOtherOneTest()
    {
        SetUpScene();

        GameObject obj1 = new GameObject("Object1");
        Item item1 = obj1.AddComponent<Item>();

        GameObject obj2 = new GameObject("Object2");
        Item item2 = obj2.AddComponent<Item>();
        obj2.transform.position = new Vector3(10, 10, 10);

        GameObject objToSpawn = new GameObject("objToSpawn");
        Item spawned = objToSpawn.AddComponent<Item>();

        CraftEffect craft = ScriptableObject.CreateInstance<CraftEffect>();
        craft.deleteItem1 = false;
        craft.deleteItem2 = true;
        craft.itemsToSpawn.Add(objToSpawn);

        craft.Execute(item1, item2);

        Assert.IsTrue(item1.IsDestroyed() == false);
        Assert.IsTrue(item2.IsDestroyed());

        ScriptableObject.DestroyImmediate(craft);
        CleanUpScene();
    }

    [Test]
    public void CraftEffectSpawnTest()
    {
        SetUpScene();

        GameObject obj1 = new GameObject("Object1");
        Item item1 = obj1.AddComponent<Item>();

        GameObject obj2 = new GameObject("Object2");
        Item item2 = obj2.AddComponent<Item>();
        obj2.transform.position = new Vector3(10, 10, 10);

        GameObject objToSpawn = new GameObject("objToSpawn");
        Item spawned = objToSpawn.AddComponent<Item>();

        CraftEffect craft = ScriptableObject.CreateInstance<CraftEffect>();
        craft.deleteItem1 = false;
        craft.deleteItem2 = false;
        craft.itemsToSpawn.Add(objToSpawn);

        craft.Execute(item1, item2);

        GameObject newObject = GameObject.Find(objToSpawn.name+"(Clone)");

        Assert.NotNull(newObject);

        ScriptableObject.DestroyImmediate(craft);
        CleanUpScene();
    }

    [Test]
    public void EffectMultipleEffectTest()
    {
        SetUpScene();

        GameObject objToClone = new GameObject("ObjectToBeClone");
        Item item = objToClone.AddComponent<Item>();

        EffectSpawnItem spawn = ScriptableObject.CreateInstance<EffectSpawnItem>();
        spawn.itemToSpawn = objToClone;
        EffectMultipleEffects multi = ScriptableObject.CreateInstance<EffectMultipleEffects>();
        multi.effects.Add(spawn);
        multi.effects.Add(spawn);

        multi.Execute(null, item);

        Item[] cloned = GameObject.FindObjectsOfType<Item>();
        Assert.IsTrue(cloned.Length == multi.effects.Count + 1);

        ScriptableObject.DestroyImmediate(spawn);
        ScriptableObject.DestroyImmediate(multi);
        CleanUpScene();
    }

    [Test]
    public void CombinationTriggersEffect()
    {
        SetUpScene();


        ItemValidator item1Val = ScriptableObject.CreateInstance<ItemValidator>();
        item1Val.name = "Item1";

        ItemValidator item2Val = ScriptableObject.CreateInstance<ItemValidator>();
        item2Val.name = "Item2";

        GameObject obj1 = new GameObject("Item1");
        Item item1 = obj1.AddComponent<Item>();

        GameObject obj2 = new GameObject("Item2");
        Item item2 = obj2.AddComponent<Item>();

        GameObject objToSpawn = new GameObject("objToSpawn");
        Item spawned = objToSpawn.AddComponent<Item>();

        EffectSpawnItem spawn = ScriptableObject.CreateInstance<EffectSpawnItem>();
        spawn.itemToSpawn = objToSpawn;

        Combination comb = ScriptableObject.CreateInstance<Combination>();
        comb.itemValidator1 = item1Val;
        comb.itemValidator2 = item2Val;
        comb.effect = spawn;

        comb.Execute(item1, item2);

        GameObject newObject = GameObject.Find(objToSpawn.name + "(Clone)");

        Assert.NotNull(newObject);

        ScriptableObject.DestroyImmediate(comb);
        ScriptableObject.DestroyImmediate(spawn);
        ScriptableObject.DestroyImmediate(item1Val);
        ScriptableObject.DestroyImmediate(item2Val);        
        
        CleanUpScene();
    }

    public GameManager SetUpScene()
    {
        GameObject gameManagerObject = new GameObject("GameManager");
        GameManager gameManager = gameManagerObject.AddComponent<GameManager>();


        return gameManager;
    }

    public void CleanUpScene()
    {
        foreach (Object obj in SceneManager.GetActiveScene().GetRootGameObjects())
        {
            MonoBehaviour.Destroy(obj);
        }
    }
}
