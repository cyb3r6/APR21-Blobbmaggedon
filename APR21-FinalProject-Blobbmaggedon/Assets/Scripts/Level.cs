using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public static Level level;

    private int levelIndex;
    private int numberOfEnemiesRemaining;


    
    void Start()
    {
        level = this;
        levelIndex = 1;
        numberOfEnemiesRemaining = 0;
    }

   

    public int GetLevel()
    {
        return levelIndex;
    }

    public void SetLevel(int index)
    {
        levelIndex = index;
    }

    public void SetEnemiesRemaining(int value)
    {
        numberOfEnemiesRemaining = value;
    }

    public int GetEnemiesRemaining()
    {
        return numberOfEnemiesRemaining;
    }

    
}
