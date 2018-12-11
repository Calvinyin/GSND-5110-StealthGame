using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class marks : MonoBehaviour {

    public NavMeshAgent agent;
    public NavMeshAgent player;
    // Use this for initialization

    // Update is called once per frame
    
    void Chase()
    {
        Debug.Log("chasing");
        Vector3 pos;
        pos = player.transform.position;
        agent.SetDestination(player.transform.position);
    }
}
