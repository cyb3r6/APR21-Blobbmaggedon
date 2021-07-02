using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance;
    public int maxNumber = 3;

    [SerializeField]
    private Transform[] spawnPoints;

    [SerializeField]
    private GameObject[] enemyTypes;

    [SerializeField]
    private GameObject[] currentEnemyTypes;

    [SerializeField]
    private float spawnDelay = 1f;

    private bool roundOver;
    private float nextRoundTime;
    private float roundDelay;
    private int enemies;
    private int spawnPoint;
    private float nextSpawn;
    private GameObject spawned;
    private GameObject player;
    private GameObject newEnemy;
    
    void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        GetNumberOfEnemies();
        RandomEnemy();
    }

    void Update()
    {
        if (!roundOver)
        {
            IsAllDead();
            SpawnEnemies();
        }
        else
        {
            if(Time.time >= nextRoundTime)
            {
                GameObject newSpawner = Instantiate(this.gameObject);
                Destroy(this.gameObject);
            }
        }
    }

    public int RandomPositionIndex()
    {
        return Random.Range(0, maxNumber);
    }
    

    private void RandomEnemy()
    {
        currentEnemyTypes = new GameObject[enemies];

        for(int i = 0; i < enemies; i++)
        {
            currentEnemyTypes[i] = enemyTypes[Random.Range(0, enemyTypes.Length)];
        }
    }

    private void GetNumberOfEnemies()
    {
        enemies = Level.level.GetLevel();
        Level.level.SetEnemiesRemaining(enemies);
    }

    private void IsAllDead()
    {
        //Checks if all enemies are dead and begins next round
        if (Level.level.GetEnemiesRemaining() <= 0)
        {
            roundOver = true;
            nextRoundTime = Time.time + roundDelay;
            Level.level.SetLevel(Level.level.GetLevel() + 1);
        }
    }

    private void SpawnEnemies()
    {
        if(enemies> 0)
        {
            if (Time.time >= nextSpawn)
            {
                nextSpawn = Time.time + spawnDelay;
                spawnPoint = Random.Range(0, spawnPoints.Length);
                newEnemy = Instantiate(currentEnemyTypes[enemies - 1], spawnPoints[spawnPoint].position, spawnPoints[spawnPoint].rotation);
                newEnemy.GetComponent<Ichablob>().SetPlayer(GameManager.instance.player);
                enemies--;
            }
        }
    }
}
