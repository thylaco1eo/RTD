using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Wave
{
    public GameObject enemyPrefab;
    public float spawnInterval = 2;
    public int maxEnemies = 20;
}

public class spawnEnemy : MonoBehaviour
{
    public Wave[] waves;
    public int timeBetweenWaves = 5;

    private float lastSpawnTime;
    private int enemiesSpawned = 0;
    public GameObject[] maps;
    public GameObject testEnemyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(testEnemyPrefab).GetComponent<enemy>().map = maps;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
