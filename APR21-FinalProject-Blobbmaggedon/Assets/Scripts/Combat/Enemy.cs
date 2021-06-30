using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : PlayerInteractable
{
    public CharacterStats stats;
    public float deathDelay = 1f;
    
    void Start()
    {
        stats = GetComponent<CharacterStats>();
        stats.OnHealthZero += Die;
    }

    public virtual void Die()
    {
        StartCoroutine(TimedDestroy(deathDelay));
    }

    public virtual IEnumerator TimedDestroy(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(this.gameObject);

    }
   
}
