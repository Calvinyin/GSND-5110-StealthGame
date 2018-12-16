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
    public enum State { goingToA, goingToB, chasing, waiting, discoverd};
    Vector3 pa, pb;
    public AudioSource au;

    private void Start()
    {
        pa = pointA.position;
        pb = pointB.position;

        mark.SetActive(false);
    }

    // Update is called once per frame

    void FixedUpdate()
    {
        
        // Set patrol route
        if (V3Equals(agent.transform.position, pa) && state == State.goingToA)
        {
            state = State.goingToB;
            agent.SetDestination(pb);
        }
        else if (V3Equals(agent.transform.position, pb) && state == State.goingToB)
        {
            state = State.goingToA;
            agent.SetDestination(pa);
        }
        else if (state == State.chasing)
        {
            if (V3Equals(player.transform.position, agent.transform.position) )
            {
                Caught();
            }
            else
            {
                if (Vector3.SqrMagnitude(player.transform.position - agent.transform.position) < 100)
                {
                    agent.SetDestination(player.transform.position);
                }
                // Always return to the closer point
                else if (Vector3.SqrMagnitude(agent.transform.position - pa) < Vector3.SqrMagnitude(agent.transform.position - pb))
                {
                    ReturnToA();
                }
                else
                {
                    ReturnToB();
                }
            }

        }

    }



    void EnemySees()
    {
        state = State.chasing;
        mark.SetActive(true);
        agent.speed = 9f;
        au.Play();
    }

    void ReturnToA()
    {
        agent.speed = 4f;
        mark.SetActive(false);
        state = State.goingToA;
        agent.SetDestination(pa);
    }

    void ReturnToB()
    {
        agent.speed = 4f;
        mark.SetActive(false);
        state = State.goingToB;
        agent.SetDestination(pb);
    }

   

    void Caught()
    {
        canvas.SetActive(true);
    }

    bool V3Equals(Vector3 a, Vector3 b)
    {
        return Vector3.SqrMagnitude(a - b) <= 3;
    }

}
