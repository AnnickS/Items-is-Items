using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class QuestTest
{
    [Test]
    public void SetupGameManager()
    {
        GameObject gameManager = new GameObject();
        gameManager.AddComponent<GameManager>();

        Assert.NotNull(gameManager);

        MonoBehaviour.Destroy(gameManager);
    }

    [Test]
    public void SetupDog()
    {
        GameObject dog = MonoBehaviour.Instantiate(Resources.Load<GameObject>("PreFabs/NPC/Pupper_Base"));
        Assert.NotNull(dog);
        MonoBehaviour.Destroy(dog);
    }

    [Test]
    public void SetupDoctor()
    {
        GameObject doctor = MonoBehaviour.Instantiate(Resources.Load<GameObject>("PreFabs/NPC/Doctor_Base"));
        Assert.NotNull(doctor);
        MonoBehaviour.Destroy(doctor);
    }

    [Test]
    public void SetupHerb()
    {
        GameObject herb = MonoBehaviour.Instantiate(Resources.Load<GameObject>("PreFabs/Item/Herb_Base"));
        Assert.NotNull(herb);
        MonoBehaviour.Destroy(herb);
    }

    [Test]
    public void SetupMedicine()
    {
        GameObject medicine = MonoBehaviour.Instantiate(Resources.Load<GameObject>("PreFabs/Item/Medicine_Base"));
        Assert.NotNull(medicine);
        MonoBehaviour.Destroy(medicine);
    }

    [UnityTest]
    public IEnumerator QuestHealDog()
    {
        GameObject gameManager = new GameObject();
        gameManager.AddComponent<GameManager>();

        GameObject dog = MonoBehaviour.Instantiate(Resources.Load<GameObject>("PreFabs/NPC/Pupper_Base"));
        dog.transform.position = new Vector3(3, 0, 0);

        GameObject doctor = MonoBehaviour.Instantiate(Resources.Load<GameObject>("PreFabs/NPC/Doctor_Base"));
        doctor.transform.position = new Vector3(-3, 0, 0);

        GameObject herb = MonoBehaviour.Instantiate(Resources.Load<GameObject>("PreFabs/Item/Herb_Base"));
        herb.transform.position = new Vector3(0, 3, 0);
        yield return null;

        QuestGiver dogQuestGiver = dog.GetComponent<QuestGiver>();
        dogQuestGiver.OnMouseDown();
        yield return null;

        QuestGiver doctorQuestGiver = doctor.GetComponent<QuestGiver>();
        doctorQuestGiver.OnMouseDown();
        yield return null;

        herb.transform.position = doctor.transform.position;
        yield return null;
        yield return null;
        yield return null;

        GameObject medicine = GameObject.Find("Medicine_Base(Clone)");
        medicine.transform.position = dog.transform.position;
        yield return null;
        yield return null;
        yield return null;

        string actual = dogQuestGiver.getCurrentQuestState().transform.name;
        string expected = "I'mBetter";

        Assert.IsTrue(expected.Equals(actual));

        GameObject.Destroy(gameManager);
        GameObject.Destroy(dog);
        GameObject.Destroy(doctor);
        GameObject.Destroy(herb);
        GameObject.Destroy(medicine);
    }
}
