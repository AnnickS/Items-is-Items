﻿// Patrol.cs
using UnityEngine;
using UnityEngine.AI;
using System.Collections;


public class Patrol : MonoBehaviour
{

    public Transform[] points;
    public Transform Destination;
    private int destPoint = 0;
    private NavMeshAgent agent;
    private bool HasTarget;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        agent.autoBraking = false;

        GotoNextPoint();
    }

    void SetDestination(Vector2 NewPoint)
    {
        //Sets new path to destination
        Destination.position.Set(NewPoint.x, NewPoint.y, this.transform.position.z);
        HasTarget = true;
        agent.autoBraking = true;
    }


    void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (points.Length == 0)
            return;

        if (HasTarget)
        {
            agent.destination = this.Destination.position;
        } else
        {
            // Set the agent to go to the currently selected destination.
            agent.destination = points[destPoint].position;

            // Choose the next point in the array as the destination,
            // cycling to the start if necessary.
            destPoint = (destPoint + 1) % points.Length;
        }
    }


    void Update()
    {
        // Choose the next destination point when the agent gets
        // close to the current one.
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            HasTarget = false;
            GotoNextPoint();
        }
    }
}