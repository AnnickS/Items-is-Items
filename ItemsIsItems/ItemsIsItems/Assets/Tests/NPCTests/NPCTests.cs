using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class NPCTests
{
    //Tests:
    //In-place Rotation
    //Within View
    //Target Selection

    [Test]
    public void NewTestScriptSimplePasses()
    {
        // Use the Assert class to test conditions.
    }

    //NPC Exists
    [Test]
    public IEnumerator InstantiateNPCTest()
    {
        GameObject NPC = MonoBehaviour.Instantiate(Resources.Load<GameObject>("NPCCharacter"));
        Assert.IsNotNull(NPC);
        MonoBehaviour.Destroy(NPC);
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
        GameObject NPC = MonoBehaviour.Instantiate(Resources.Load<GameObject>("NPCCharacter"));
        GameObject itemOne = MonoBehaviour.Instantiate(Resources.Load<GameObject>("FlowerRoseSmellable"), new Vector3(0F, -2F, 0), new Quaternion());
        GameObject itemTwo = MonoBehaviour.Instantiate(Resources.Load<GameObject>("FlowerRoseSmellable"), new Vector3(0F, 2F, 0), new Quaternion());
        GameObject itemThree = MonoBehaviour.Instantiate(Resources.Load<GameObject>("FlowerRoseSmellable"), new Vector3(0F, 6F, 0), new Quaternion());

        // yield to skip a frame
        yield return null;

        Assert.True(NPC.GetComponent<NPC>().WithinCircle.Length.Equals(3));
    }

    /* Within View */
    //Calculates what's in the NPC's sight correctly
    [UnityTest]
    public IEnumerator WithinView()
    {
        GameObject NPC = MonoBehaviour.Instantiate(Resources.Load<GameObject>("NPCCharacter"));
        GameObject itemOne = MonoBehaviour.Instantiate(Resources.Load<GameObject>("FlowerRoseSmellable"), new Vector3(0F, -2F, 0), new Quaternion());
        GameObject itemTwo = MonoBehaviour.Instantiate(Resources.Load<GameObject>("FlowerRoseSmellable"), new Vector3(0F, 2F, 0), new Quaternion());

        yield return null;

        Assert.True(NPC.GetComponent<NPC>().WithinView.Equals(1));
    }

    /* Within Smell */
    //Calculates what's in the NPC's 'smell distance' correctly
    [UnityTest]
    public IEnumerator WithinSmell()
    {
        GameObject NPC = MonoBehaviour.Instantiate(Resources.Load<GameObject>("NPCCharacter"));
        GameObject itemOne = MonoBehaviour.Instantiate(Resources.Load<GameObject>("FlowerRoseSmellable"), new Vector3(0F, -2F, 0), new Quaternion());
        GameObject itemTwo = MonoBehaviour.Instantiate(Resources.Load<GameObject>("FlowerRoseSmellable"), new Vector3(0F, 2F, 0), new Quaternion());

        yield return null;

        Assert.True(NPC.GetComponent<NPC>().WithinSmell.Equals(1));
    }

    /* Behind Obstacle */
    //Obstacle can block vision of an item
    [UnityTest]
    public IEnumerator BehindObstacle()
    {
        GameObject NPC = MonoBehaviour.Instantiate(Resources.Load<GameObject>("NPCCharacter"));
        GameObject character = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Character"), new Vector3(0F, -1F, 0), new Quaternion());
        GameObject item = MonoBehaviour.Instantiate(Resources.Load<GameObject>("FlowerRoseSmellable"), new Vector3(0F, -3F, 0), new Quaternion());

        yield return null;

        Assert.True(NPC.GetComponent<NPC>().WithinSmell.Equals(1));
    }

    /*** Target Selection ***/
    //View Selection
    //Smell Selection

    /* View Selection */
    //Selects target as item position that NPC is attracted to or scared of
    [UnityTest]
    public IEnumerator SelectsItemsWithinView()
    {
        GameObject NPC = MonoBehaviour.Instantiate(Resources.Load<GameObject>("NPCCharacter"));
        GameObject item = MonoBehaviour.Instantiate(Resources.Load<GameObject>("FlowerRoseSmellable"), new Vector3(0F, -3F, 0), new Quaternion());

        yield return null;

        Assert.True(NPC.GetComponent<NPC>().Target.Equals(new Vector2(0, -3)));
    }

    /* Smell Selection */
    //Triggers rotation if there is an item that is smellable outside of NPC view
    [UnityTest]
    public IEnumerator RotatesWhenItemWithinSmell()
    {
        GameObject NPC = MonoBehaviour.Instantiate(Resources.Load<GameObject>("NPCCharacter"));
        GameObject item = MonoBehaviour.Instantiate(Resources.Load<GameObject>("FlowerRoseSmellable"), new Vector3(0F, 3F, 0), new Quaternion());

        yield return null;

        Assert.True(NPC.GetComponent<NPC>().Rotate.Equals(true));
    }
}