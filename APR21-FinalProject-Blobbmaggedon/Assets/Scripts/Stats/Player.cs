using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;
    public Combat combat;
    public PlayerStats playerstats;

    
    void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        playerstats.OnHealthZero += Die;
    }

    public void Die()
    {
        // gameover?
    }
}
