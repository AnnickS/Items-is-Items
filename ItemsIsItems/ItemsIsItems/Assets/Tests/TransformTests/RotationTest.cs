using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class RotationTest {

    [Test]
    public void InstantiateCharacterTest()
    {
        GameObject character = MonoBehaviour.Instantiate(Resources.Load<GameObject>("PreFabs/Character"));
        Assert.IsNotNull(character);
        MonoBehaviour.Destroy(character);
    }

    [UnityTest]
    public IEnumerator DifferentRotationTest()
    {
        GameObject character = MonoBehaviour.Instantiate(Resources.Load<GameObject>("PreFabs/Character"));
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
        GameObject character = MonoBehaviour.Instantiate(Resources.Load<GameObject>("PreFabs/Character"));
        character.transform.position = new Vector2(0, 0);
        MoveTowardPosition moveScript = character.GetComponent<MoveTowardPosition>();
        RotateTowardMovementTarget rotateScript = character.GetComponent<RotateTowardMovementTarget>();

        character.transform.position = new Vector3(0, 0);
        Vector2 targetPosition = new Vector2(1, 1);
        moveScript.moveToPosition(targetPosition);

        rotateScript.rotateTowardsTargetPosition();

        Quaternion actual = character.transform.rotation;
        Quaternion expected = Quaternion.Euler(new Vector3(0, 0, -45 + rotateScript.rotationOffset));

        string errorMessage = "";
        errorMessage += "The Rotation Test failed it had: ";
        errorMessage += "/nActual rotation of: ";
        errorMessage += actual;
        errorMessage += "/nExpected rotation of: ";
        errorMessage += expected;
        errorMessage += "/nActual eular angle of ";
        errorMessage += actual.eulerAngles;
        errorMessage += "/nExpected eular angle of ";
        errorMessage += expected.eulerAngles;

        Assert.True(actual.eulerAngles.z.Equals(expected.eulerAngles.z), errorMessage);
        MonoBehaviour.Destroy(character);
        yield return null;
    }
}
