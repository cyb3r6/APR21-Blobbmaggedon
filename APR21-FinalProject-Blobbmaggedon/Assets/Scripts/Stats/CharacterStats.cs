using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterStats : MonoBehaviour
{
    public int maxhealth;

    public int currentHealth { get; private set; }

    public Stats damage;
    public Stats armor;


    public UnityAction OnHealthZero;


    private void Awake()
    {
        currentHealth = maxhealth;
    }

    public virtual void Start()
    {

    }

    public void TakeDamage(int damage)
    {
        damage -= armor.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        currentHealth -= damage;

        Debug.Log($"{transform.name} takes {damage} current health is {currentHealth}");

        if(currentHealth <= 0)
        {
            // die
            Die();

        }
    }
    
    public virtual void Die()
    {
        OnHealthZero?.Invoke();
    }
}
