using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerBehaviour : MonoBehaviour
{
    public GameObject UI;
    public GameObject[] nextWaveLabels;
    private int gold;
    private int health;
    private int maxWave;
    private float timebetweenspawn;
    private spawnEnemy spawnenemy;
    public GameObject basement;
    public bool gameOver = false;

    private int wave;
    // Start is called before the first frame update
    void Start()
    {
        spawnenemy = GameObject.Find("Road").GetComponent<spawnEnemy>();
        MaxWave = spawnenemy.waves.Length;
        Gold = 1000;
        Health = 35;
        basement.transform.GetChild(1).gameObject.GetComponent<HealthBar>().maxHealth = Health;
        Wave = 0;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public int MaxWave
    {
        get
        {
            return maxWave;
        }
        set
        {
            maxWave = value;
        }
    }

    public float TimeBetweenSpawn
    {
        get
        {
            return timebetweenspawn;
        }
        set
        {
            timebetweenspawn = value;
            UI.transform.GetChild(3).gameObject.GetComponent<Text>().text = "NEXT WAVE IN:" + timebetweenspawn.ToString("n2");
        }
    }
    public int Gold {
        get
        { 
            return gold;
        }
        set
        {
            gold = value;
            UI.transform.GetChild(1).gameObject.GetComponent<Text>().text = "GOLD: " + gold;
        }
    }
    public int Wave
         {
             get
             {
                 return wave;
             }
             set
             {
                 wave = value;
                 
                 if (wave==maxWave)
                 {
                     gameOver = true;
                     Scene scene = SceneManager.GetActiveScene();
                     GameObject gameWon = (GameObject)Instantiate(Resources.Load("prefab/gameWon"));
                     if (scene.buildIndex == 3)
                     {
                         gameWon.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>()
                             .text = "Menu";
                     }
                     GameObject NextLevel = gameWon.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
                     NextLevel.GetComponent<Button>().onClick.AddListener(() =>
                     {
                         Scene scene = SceneManager.GetActiveScene();
                         SceneManager.LoadScene((scene.buildIndex + 1)%4);
                     });
                 }
                 else
                 {
                     UI.transform.GetChild(2).gameObject.GetComponent<Text>().text = "WAVE: " + (wave + 1)+"/"+maxWave;
                 }
                 
             }
         }

    public int Health
    {
        get
        {
            return health;
        }
        set
        {
            health = value;
            UI.transform.GetChild(0).gameObject.GetComponent<Text>().text = "HEALTH: " + health;
            basement.transform.GetChild(1).gameObject.GetComponent<HealthBar>().currentHealth = health;
            if ( health<= 0 && !gameOver)
            {
                gameOver = true;
                GameObject gameEnd = (GameObject)Instantiate(Resources.Load("prefab/gameOver"));
                GameObject Restart = gameEnd.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
                Restart.GetComponent<Button>().onClick.RemoveAllListeners();
                Restart.GetComponent<Button>().onClick.AddListener(()=>
                {
                    Scene scene = SceneManager.GetActiveScene();
                    SceneManager.LoadScene(scene.name);
                });
                GameObject End = gameEnd.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject;
                End.GetComponent<Button>().onClick.RemoveAllListeners();
                End.GetComponent<Button>().onClick.AddListener(()=>
                {
                    Application.Quit();
                });
            }
        }
    }
}
