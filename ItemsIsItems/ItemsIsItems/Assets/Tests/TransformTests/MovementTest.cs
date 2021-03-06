﻿using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class MovementTest
{
    
    [UnityTest]
    public IEnumerator FrameCountIncrementTest()
    {
        int before = Time.frameCount;
        yield return null;
        int after = Time.frameCount;
        Assert.AreNotEqual(before, after);
    }

    [UnityTest]
    public IEnumerator InstantiateCharacterTest()
    {
        GameObject character = MonoBehaviour.Instantiate(Resources.Load<GameObject>("PreFabs/Character"));
        Assert.IsNotNull(character);
        MonoBehaviour.Destroy(character);
        yield return null;
    }

    [UnityTest]
    public IEnumerator MovesAwayTest()
    {
        GameObject character = MonoBehaviour.Instantiate(Resources.Load<GameObject>("PreFabs/Character"));
        MoveTowardPosition moveTowardPosition = character.GetComponent<MoveTowardPosition>();
        Vector3 expected = character.transform.position;

        yield return null;

        moveTowardPosition.moveToPosition(new Vector2(1, 1));

        Time.timeScale = 100;
        yield return new WaitForSeconds(1);
        Vector3 actual = character.transform.position;

        Assert.False(actual.Equals(expected));
        MonoBehaviour.Destroy(character);
    }

    [UnityTest]
    public IEnumerator GoToPositionTest()
    {
        GameObject character = MonoBehaviour.Instantiate(Resources.Load<GameObject>("PreFabs/Character"));
        character.transform.position = new Vector2(0, 0);
        Vector2 targetPosition = new Vector2(1, 1);

        yield return null;

        character.GetComponent<MoveTowardPosition>().moveToPosition(targetPosition);

        Time.timeScale = 100;
        yield return new WaitForSeconds(10);
        Vector3 actual = character.transform.position;
        Debug.Log("Character position current: " + actual);
        Vector3 expected = new Vector3(targetPosition.x, targetPosition.y, character.transform.position.z);

        Assert.True(actual.Equals(expected));
        MonoBehaviour.Destroy(character);
    }

}
