using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;

public class QuestStatesTest
{
    /*
    [Test]
    public void ExampleQuestIsNotNull()
    {
        GameObject quest = MonoBehaviour.Instantiate(Resources.Load<GameObject>("ExampleQuest"));
        Assert.NotNull(quest);
        MonoBehaviour.Destroy(quest);
    }

    [Test]
    public void ExampleQuestQuestComponentIsNotNull()
    {

        GameObject quest = MonoBehaviour.Instantiate(Resources.Load<GameObject>("ExampleQuest"));
        Quest questComponent = quest.GetComponent<Quest>();
        Assert.NotNull(questComponent);
        MonoBehaviour.Destroy(quest);
    }

    [Test]
    public void ExampleQuestDialogIsNotNull()
    {

        GameObject quest = MonoBehaviour.Instantiate(Resources.Load<GameObject>("ExampleQuest"));
        Quest questComponent = quest.GetComponent<Quest>();
        Dialog dialog = questComponent.dialog;
        Assert.NotNull(dialog);
        MonoBehaviour.Destroy(quest);
    }

    [UnityTest]
    public IEnumerator QuestStateBeforeClickIsStartState()
    {

        GameObject quest = MonoBehaviour.Instantiate(Resources.Load<GameObject>("ExampleQuest"));
        Quest questComponent = quest.GetComponent<Quest>();
        Dialog dialog = questComponent.dialog;

        List<QuestState> states = new List<QuestState>();
        QuestState startState = new QuestStateAskFor(dialog, "By the power invested in me... Gimme a flower!");
        QuestState nextState = new QuestStateIdle(dialog, "I'm currently Idle, bugger off?!");
        states.Add(startState);
        states.Add(nextState);
        questComponent.states = states;

        yield return null;

        QuestState actualState = questComponent.getCurrentQuestState();
        QuestState expectedState = startState;
        Assert.AreEqual(expectedState, actualState);
        MonoBehaviour.Destroy(quest);
    }

    [UnityTest]
    public IEnumerator QuestStateAfterClickIsStartState()
    {
        GameObject quest = MonoBehaviour.Instantiate(Resources.Load<GameObject>("ExampleQuest"));
        Quest questComponent = quest.GetComponent<Quest>();
        Dialog dialog = questComponent.dialog;

        List<QuestState> states = new List<QuestState>();
        QuestState startState = new QuestStateAskFor(dialog, "By the power invested in me... Gimme a flower!");
        QuestState nextState = new QuestStateIdle(dialog, "I'm currently Idle, bugger off?!");
        states.Add(startState);
        states.Add(nextState);
        questComponent.states = states;

        yield return null;
        questComponent.OnMouseDown();

        QuestState actualState = questComponent.getCurrentQuestState();
        QuestState expectedState = startState;
        Assert.AreEqual(expectedState, actualState);
        MonoBehaviour.Destroy(quest);
    }

    [UnityTest]
    public IEnumerator QuestStateAfterDialogDisappearsIsNextState()
    {

        GameObject quest = MonoBehaviour.Instantiate(Resources.Load<GameObject>("ExampleQuest"));
        Quest questComponent = quest.GetComponent<Quest>();
        Dialog dialog = questComponent.dialog;

        List<QuestState> states = new List<QuestState>();
        QuestState startState = new QuestStateAskFor(dialog, "By the power invested in me... Gimme a flower!");
        QuestState nextState = new QuestStateIdle(dialog, "I'm currently Idle, bugger off?!");
        states.Add(startState);
        states.Add(nextState);
        questComponent.states = states;

        yield return null;
        questComponent.OnMouseDown();

        float beforeTimeScale = Time.timeScale;
        Time.timeScale = 100;
        yield return new WaitForSeconds(10);
        Time.timeScale = beforeTimeScale;

        QuestState actualState = questComponent.getCurrentQuestState();
        QuestState expectedState = nextState;
        Assert.AreEqual(expectedState, actualState);
        MonoBehaviour.Destroy(quest);
    }//*/

}
