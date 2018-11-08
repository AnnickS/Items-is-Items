using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class PickUpTest
{
    [UnityTest]
    public IEnumerator PickUpDyeItemTest()
    {
        GameObject dye = MonoBehaviour.Instantiate(Resources.Load<GameObject>("ItemDye"));
        Vector2 dyePosition = new Vector2(3, 3);
        dye.transform.position = dyePosition;

        GameObject character = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Character"));
        MoveTowardPosition moveTowardPosition = character.GetComponent<MoveTowardPosition>();
        character.transform.position = new Vector2(0, 0);

        moveTowardPosition.moveToPosition(dyePosition);

        Time.timeScale = 100;
        yield return new WaitForSeconds(10);

        Vector2 targetPosition = new Vector2(10, 3);
        moveTowardPosition.moveToPosition(targetPosition);

        yield return new WaitForSeconds(10);

        float distance = Vector2.Distance(dye.transform.position, character.transform.position);
        Assert.True(distance < 5f);

        Time.timeScale = 1;
        MonoBehaviour.Destroy(dye);
        MonoBehaviour.Destroy(character);

    }
}
