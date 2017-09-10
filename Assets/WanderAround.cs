﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;	

public class WanderAround : MonoBehaviour {

    [SerializeField]
    public float wanderMaxDistance = 5.0f;
    public float wanderMinDistance = 1.0f;

    private bool isWandering = true;

	private NavMeshAgent agent;
    private Rigidbody rb;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update () {

        if (isWandering)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                {
                    // Done
                    isWandering = false;
                    Wander();
                }
            }
        }
    }

    // Go to a random location
    void Wander()
    {
        // Set a flag to wander
        isWandering = true;
        // Pick a random distance between the range we set
        float distance = Random.Range(wanderMinDistance, wanderMaxDistance);
        // Pick a random Vector3 location within a sphere the radius of the distance we picked
        // This will be the offset of our character
        Vector3 offset = UnityEngine.Random.insideUnitSphere * distance;
        Vector3 wanderTo = transform.position + offset;
        
        // NavMesh.SamplePosition will check if the place we're wandering to is a valid location to path to
        // It will store the postion in navHit (denoted by the "out" keyword) when it is done
        NavMeshHit navHit;
        NavMesh.SamplePosition(wanderTo, out navHit, distance, -1);

        // Start pathing to the new position given to us in navHit
        agent.SetDestination(navHit.position);
    }

	/// <summary>
	/// OnTriggerEnter is called when the Collider other enters the trigger.
	/// </summary>
	/// <param name="other">The other Collider involved in this collision.</param>
	void OnTriggerEnter(Collider other)
	{
		// If the other is the Player, stop wandering
        if (other.tag == "Player")
        {
            isWandering = false;
            agent.ResetPath();
        }
	}

    /// <summary>
    /// OnTriggerExit is called when the Collider other has stopped touching the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerExit(Collider other)
	{
		// If the other is the Player, then start wandering again
		if (other.tag == "Player")
        {
            if (!isWandering)
                Wander();
        }
	}
}
