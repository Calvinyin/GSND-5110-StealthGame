using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyControler : MonoBehaviour {

    public NavMeshAgent agent;
    public NavMeshAgent player;
    public Transform pointA;
    public Transform pointB;
    public GameObject mark;
    public GameObject canvas;
    State state = State.goingToA;
    public enum State { goingToA, goingToB, chasing};

    Vector3 pos;

    // Update is called once per frame
    void Update () {
        pos = player.transform.position;
        if (state != State.chasing)
        {
            mark.SetActive(false);
            if (V3Equals(agent.transform.position, pointA.position) && state == State.goingToA)
            {
                state = State.goingToB;
                agent.SetDestination(pointB.position);
            }
            if (V3Equals(agent.transform.position, pointB.position) && state == State.goingToB)
            {
                state = State.goingToA;
                agent.SetDestination(pointA.position);
            }
        }
        else
        {
            if(V3Equals(pos,agent.transform.position))
            {
                Caught();
            }
            else
            {
                agent.SetDestination(pos);
            }
        }

    }

    

    void EnemySees()
    {
        if (state == State.chasing)
        {
        }
        else
        {
            state = State.chasing;
            mark.SetActive(true);
            agent.SetDestination(pos);

        }
    }

    IEnumerator Chase()
    {
        yield return new WaitForSeconds(2);
    }

    void Caught()
    {
        canvas.SetActive(true);
    }

    bool V3Equals(Vector3 a, Vector3 b)
    {
        return Vector3.SqrMagnitude(a - b) <= 5;
    }
}
