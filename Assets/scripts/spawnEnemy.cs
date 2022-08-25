using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wave
{
    public GameObject enemyPrefab;
    public float spawnInterval = 2;
    public int maxEnemies = 20;
}

public class spawnEnemy : MonoBehaviour
{
    public int timeBetweenWaves = 5;
    private GameManagerBehaviour gameManager;
    private float lastSpawnTime;
    private int enemiesSpawned = 0;
    public GameObject[] maps;
    public Wave[] waves;

    private GameObject gameOver;

    private GameObject gameWon;
    // Start is called before the first frame update
    void Start()
    {
        lastSpawnTime = Time.time;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.gameOver)
        {
            return;
        }
        int currentWave = gameManager.Wave;
        if (currentWave < waves.Length && !gameManager.gameOver)
        {
            
            float timeInterval = Time.time - lastSpawnTime;
            if (enemiesSpawned == 0 && timeInterval <= timeBetweenWaves)
            {
                gameManager.TimeBetweenSpawn = timeBetweenWaves - timeInterval;
            }
            float spawnInterval = waves[currentWave].spawnInterval;
            if (((enemiesSpawned == 0 && timeInterval > timeBetweenWaves) ||
                 enemiesSpawned != 0 && timeInterval > spawnInterval) && 
                enemiesSpawned < waves[currentWave].maxEnemies)
            {
                lastSpawnTime = Time.time;
                GameObject newEnemy = (GameObject)
                    Instantiate(waves[currentWave].enemyPrefab);
                newEnemy.GetComponent<enemy>().map = maps;
                enemiesSpawned++;
            }
            if (enemiesSpawned == waves[currentWave].maxEnemies &&
                GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                gameManager.Wave++;
                enemiesSpawned = 0;
                lastSpawnTime = Time.time;
            }
        }
        else
        {
            gameManager.gameOver = true;
            //GameObject gameOverText = GameObject.FindGameObjectWithTag ("GameWon");
            //gameOverText.GetComponent<Animator>().SetBool("gameOver", true);
        }
    }
}
