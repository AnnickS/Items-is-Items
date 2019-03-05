using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class QuestStateWalk : QuestState
{
    public GameObject[] path;
    int index = 0;

    MoveTowardPosition movement;
    GameObject questGiver;
    bool isDone = false;

    public override void Initialize(GameObject questGiver)
    {
        movement = questGiver.GetComponent<MoveTowardPosition>();
        this.questGiver = questGiver;
    }

    void FixedUpdate()
    {
        if(index < path.Length)
        {
            GameObject currentNode = path[index];
            movement.moveToPosition(new Vector2(currentNode.transform.position.x, currentNode.transform.position.y));
            
            if (Vector2.Distance(getVector2(currentNode.transform.position), getVector2(questGiver.transform.position)) < 1)
            {
                index++;
            }
        }

        if (index >= path.Length)
        {
            isDone = true;
        }
    }

    private Vector2 getVector2(Vector3 vector3)
    {
        return new Vector2(vector3.x, vector3.y);

    }

    public override bool IsDone()
    {
        return isDone;
    }

    public override void ShowStory()
    {

    }
}
