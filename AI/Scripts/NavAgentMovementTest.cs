using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class NavAgentMovementTest : MonoBehaviour
{
    //attach this script to a primitive to test movement around scene
    //especially useful for testing offmeshlinks

    public Transform moveTransform;
    public NavMeshAgent agent;

    // Update is called once per frame
    void Update()
    {
        agent.destination = moveTransform.position;
    }
}
