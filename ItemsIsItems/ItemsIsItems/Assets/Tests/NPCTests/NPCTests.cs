﻿using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class NPCTests
{
    //Tests:
    //Within View
    //Target Selection

    [UnityTest]
    public IEnumerator InstantiateNPCTest()
    {
        GameObject npc = MonoBehaviour.Instantiate(Resources.Load<GameObject>("PreFabs/NPC/NPC_Base"), new Vector3(0, 0, 0), new Quaternion());
        Assert.IsNotNull(npc);
        MonoBehaviour.Destroy(npc);
        yield return null;
    }

    /*** Within View ***/
    //Within Circle
    //Within View
    //Within Smell
    //Behind Obstacle

    /* Within Circle */
    //Calculates what's in the NPC's observation circle correctly
    [UnityTest]
    public IEnumerator WithinCircle()
    {
        GameObject npc = MonoBehaviour.Instantiate(Resources.Load<GameObject>("PreFabs/NPC/NPC_Base"), new Vector3(0, 0, 0), new Quaternion());
        GameObject itemOne = MonoBehaviour.Instantiate(Resources.Load<GameObject>("PreFabs/Item/Rose_Base"), new Vector3(0F, -2F, 0), new Quaternion());
        GameObject itemTwo = MonoBehaviour.Instantiate(Resources.Load<GameObject>("PreFabs/Item/Rose_Base"), new Vector3(0F, 2F, 0), new Quaternion());
        GameObject itemThree = MonoBehaviour.Instantiate(Resources.Load<GameObject>("PreFabs/Item/Rose_Base"), new Vector3(0F, 6F, 0), new Quaternion());

        // yield to skip a frame
        yield return null;
        yield return null;

        Assert.True(npc.GetComponent<DetectionRange>().WithinCircle.Length.Equals(2));

        MonoBehaviour.Destroy(npc);
        MonoBehaviour.Destroy(itemOne);
        MonoBehaviour.Destroy(itemTwo);
        MonoBehaviour.Destroy(itemThree);
        yield return null;
    }

    /* Within View */
    //Calculates what's in the NPC's sight correctly
    [UnityTest]
    public IEnumerator WithinView()
    {
        GameObject npc = MonoBehaviour.Instantiate(Resources.Load<GameObject>("PreFabs/NPC/NPC_Base"), new Vector3(0, 0, 0), new Quaternion());
        GameObject itemOne = MonoBehaviour.Instantiate(Resources.Load<GameObject>("PreFabs/Item/Rose_Base"), new Vector3(0, -2F, 0), new Quaternion());
        GameObject itemTwo = MonoBehaviour.Instantiate(Resources.Load<GameObject>("PreFabs/Item/Rose_Base"), new Vector3(0, 2F, 0), new Quaternion());

        yield return null;
        yield return null;
        
        Assert.True(npc.GetComponent<DetectionRange>().WithinView.Count.Equals(1));

        MonoBehaviour.Destroy(npc);
        MonoBehaviour.Destroy(itemOne);
        MonoBehaviour.Destroy(itemTwo);
        yield return null;
    }

    /* Within Smell */
    //Calculates what's in the NPC's 'smell distance' correctly
    [UnityTest]
    public IEnumerator WithinSmell()
    {
        GameObject npc = MonoBehaviour.Instantiate(Resources.Load<GameObject>("PreFabs/NPC/NPC_Base"), new Vector3(0, 0, 0), new Quaternion());
        GameObject itemOne = MonoBehaviour.Instantiate(Resources.Load<GameObject>("PreFabs/Item/Rose_Base"), new Vector3(0F, 2F, 0), new Quaternion());

        yield return null;

        Assert.True(npc.GetComponent<DetectionRange>().WithinSmell.Count.Equals(1));

        MonoBehaviour.Destroy(npc);
        MonoBehaviour.Destroy(itemOne);
        yield return null;
    }

    /* Behind Obstacle */
    //Obstacle can block vision of an item
    [UnityTest]
    public IEnumerator BehindObstacle()
    {
        GameObject npc = MonoBehaviour.Instantiate(Resources.Load<GameObject>("PreFabs/NPC/NPC_Base"), new Vector3(0, 0, 0), new Quaternion());
        GameObject character = MonoBehaviour.Instantiate(Resources.Load<GameObject>("PreFabs/Character"), new Vector3(0F, -1F, 0), new Quaternion());
        GameObject item = MonoBehaviour.Instantiate(Resources.Load<GameObject>("PreFabs/Item/Rose_Base"), new Vector3(0F, -3F, 0), new Quaternion());

        yield return null;

        Assert.True(npc.GetComponent<DetectionRange>().WithinView.Count.Equals(0));
        Assert.True(npc.GetComponent<DetectionRange>().WithinSmell.Count.Equals(1));

        MonoBehaviour.Destroy(npc);
        MonoBehaviour.Destroy(character);
        MonoBehaviour.Destroy(item);
        yield return null;
    }

    /*** Target Selection ***/
    //View Selection
    //Smell Selection

    /* View Selection */
    //Selects target as item position that NPC is attracted to or scared of
    [UnityTest]
    public IEnumerator SelectsItemsWithinView()
    {
        GameObject npc = MonoBehaviour.Instantiate(Resources.Load<GameObject>("PreFabs/NPC/NPC_Base"), new Vector3(0, 0, 0), new Quaternion());
        GameObject item = MonoBehaviour.Instantiate(Resources.Load<GameObject>("PreFabs/Item/Rose_Base"), new Vector3(0, -3, 0), new Quaternion());

        Time.timeScale = 100;
        yield return new WaitForSeconds(1);

        Assert.True(npc.GetComponent<NPC>().CurrentTarget.Equals(new Vector2(0, -3)));

        MonoBehaviour.Destroy(npc);
        MonoBehaviour.Destroy(item);
        yield return null;
    }

    /* Smell Selection */
    //Triggers rotation if there is an item that is smellable outside of NPC view
    [UnityTest]
    public IEnumerator RotatesWhenItemWithinSmell()
    {
        GameObject npc = MonoBehaviour.Instantiate(Resources.Load<GameObject>("PreFabs/NPC/NPC_Base"), new Vector3(0, 0, 0), new Quaternion());
        GameObject item = MonoBehaviour.Instantiate(Resources.Load<GameObject>("PreFabs/Item/Rose_Base"), new Vector3(0, 3, 0), new Quaternion());

        Time.timeScale = 100;
        yield return new WaitForSeconds(10);
        
        Assert.True(npc.GetComponent<NPC>().Rotate.Equals(true));

        MonoBehaviour.Destroy(npc);
        MonoBehaviour.Destroy(item);
        yield return null;
    }
}