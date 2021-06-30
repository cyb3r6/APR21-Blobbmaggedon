using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Transform player;

    [SerializeField]
    private Level levelPrefab;

    private Level level;
    
    void Awake()
    {
        instance = this;

        player = Camera.main.transform;

        if(level == null)
        {
            level = Instantiate(levelPrefab);
        }
    }
    
}
