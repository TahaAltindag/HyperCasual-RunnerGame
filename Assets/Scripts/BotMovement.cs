using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BotMovement : MonoBehaviour
{

    public Transform finishLine;
    private Transform startPos;
    private Vector3 pos;
    NavMeshAgent agent;
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        startPos = GetComponent<Transform>();
        pos = startPos.position;
        agent = GetComponent<NavMeshAgent>();
        agent.destination = finishLine.position;
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Obstacle" || collision.collider.tag == "stick")
        {
            agent.transform.position = pos;
        }
        if(collision.collider.tag == "FinishLine")
        {
            animator.SetBool("isFinished", true);
            agent.isStopped = true;
        }
        
    }


}
