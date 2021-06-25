using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ichablob : MonoBehaviour
{
    private Animator blobAnimator;
    private Transform target;
    private NavMeshAgent navMeshAgent;
    
    void Start()
    {
        target = Camera.main.transform;

        navMeshAgent = GetComponent<NavMeshAgent>();

        blobAnimator = GetComponent<Animator>();

    }

    public void SetPlayer(Transform player)
    {
        this.target = player;
    }
    
    void Update()
    {
        navMeshAgent.SetDestination(target.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "MainCamera")
        {
            blobAnimator.SetBool("Attack", true);
        }
    }
    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.tag == "MainCamera")
        {
            blobAnimator.SetBool("Attack", false);
        }
    }
}
