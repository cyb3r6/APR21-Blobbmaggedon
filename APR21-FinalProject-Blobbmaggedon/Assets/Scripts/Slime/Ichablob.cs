using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ichablob : MonoBehaviour
{
    private Animator blobAnimator;
    private Transform target;
    private NavMeshAgent navMeshAgent;
    private Combat combat;
    private Enemy enemy;
    
    void Start()
    {
        target = Camera.main.transform;

        navMeshAgent = GetComponent<NavMeshAgent>();

        blobAnimator = GetComponent<Animator>();

        combat = GetComponent<Combat>();

        combat.OnAttack += OnAttack;

        enemy = GetComponent<Enemy>();

        enemy.stats.OnHealthZero += Death;
    }

    public void SetPlayer(Transform player)
    {
        this.target = player;
    }
    
    void Update()
    {
        navMeshAgent.SetDestination(target.position);
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "MainCamera")
        {
            OnAttack();
        }
    }

    public void OnAttack()
    {
        blobAnimator.SetTrigger("Attack");
        combat.Attack(Player.instance.playerstats);
    }

    public void Death()
    {
        blobAnimator.SetTrigger("Death");

        navMeshAgent.isStopped = true;

        var rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        Level.level.SetEnemiesRemaining(Level.level.GetEnemiesRemaining() - 1);
    }
   
}
