using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowTarget : MonoBehaviour {

    private NavMeshAgent agent;

    private GameObject target;

    // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            target = other.gameObject;
            agent.destination = target.transform.position;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            target = other.gameObject;
            Vector3 targetLocation = target.transform.position;
            // Only update agent 
            if (Vector3.Distance(transform.position, targetLocation) > agent.stoppingDistance)
            {
                agent.destination = targetLocation;
            }
        }
    }
}
