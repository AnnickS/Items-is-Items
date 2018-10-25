using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class RotationTest {

    [Test]
    public void InstantiateCharacterTest()
    {
        GameObject character = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Character"));
        Assert.IsNotNull(character);
        MonoBehaviour.Destroy(character);
    }

    [UnityTest]
    public IEnumerator DifferentRotationTest()
    {
        GameObject character = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Character"));
        MoveTowardPosition moveTowardPosition = character.GetComponent<MoveTowardPosition>();

        character.transform.position = new Vector3(0, 0);
        Quaternion before = character.transform.rotation;

        Vector2 targetPosition = new Vector2(1, 1);
        moveTowardPosition.moveToPosition(targetPosition);
        
        yield return new WaitForSeconds(1);

        Quaternion after = character.transform.rotation;

        Assert.False(after.Equals(before));
        MonoBehaviour.Destroy(character);
    }

    [UnityTest]
    public IEnumerator RotateTowardsMovePositionTest()
    {
        GameObject character = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Character"));
        MoveTowardPosition moveTowardPosition = character.GetComponent<MoveTowardPosition>();
        RotateTowardPosition rotateTowardPosition = character.GetComponent<RotateTowardPosition>();

        character.transform.position = new Vector3(0, 0);
        Vector2 targetPosition = new Vector2(1, 1);
        moveTowardPosition.moveToPosition(targetPosition);

        yield return null;

        Quaternion actual = character.transform.rotation;
        Quaternion expected = Quaternion.Euler(new Vector3(0, 0, -45 + rotateTowardPosition.rotationOffset));

        Assert.True(actual.eulerAngles.z.Equals(expected.eulerAngles.z));
        MonoBehaviour.Destroy(character);
    }
}
