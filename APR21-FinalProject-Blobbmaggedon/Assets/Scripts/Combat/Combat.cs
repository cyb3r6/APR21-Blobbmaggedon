using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Combat : MonoBehaviour
{
    public float attackRate = 1f;
    private float attackCountdown = 0f;

    public UnityAction OnAttack;

    private CharacterStats charStats;
    private CharacterStats enemyStats;


    
    void Start()
    {
        charStats = GetComponent<CharacterStats>();
    }

    
    void Update()
    {
        attackCountdown -= Time.deltaTime;
    }

    public virtual void Attack(CharacterStats enemystats)
    {
        if(attackCountdown <= 0f)
        {
            this.enemyStats = enemystats;
            attackCountdown = 1f / attackRate;
            StartCoroutine(DoDamage(enemystats, 0.6f));

            if(OnAttack != null)
            {
                OnAttack();
            }

        }
    }

    public virtual IEnumerator DoDamage(CharacterStats stats, float delay)
    {
        Debug.Log("Start attack!");
        yield return new WaitForSeconds(delay);

        Debug.Log($"{transform.name} attacks for {charStats.damage.GetValue()} damage");

        enemyStats.TakeDamage(charStats.damage.GetValue());
    }

    public virtual void Attack(CharacterStats enemystats, Transform enemyTransform)
    {
        this.enemyStats = enemystats;
        DoDamage(enemystats);
    }

    public virtual void DoDamage(CharacterStats stats)
    {
        Debug.Log("Weapon attack!");
        Debug.Log($"{transform.name} attacks for {charStats.damage.GetValue()} damage");
        enemyStats.TakeDamage(charStats.damage.GetValue());
    }
}
