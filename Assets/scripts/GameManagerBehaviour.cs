using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerBehaviour : MonoBehaviour
{
    public GameObject UI;
    public GameObject[] nextWaveLabels;
    private int gold;
    private int health;
    public GameObject basement;
    public bool gameOver = false;

    private int wave;
    // Start is called before the first frame update
    void Start()
    {
        Gold = 1000;
        Health = 100;
        Wave = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
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
                 /*
                 if (!gameOver)
                 {
                     for (int i = 0; i < nextWaveLabels.Length; i++)
                     {
                         nextWaveLabels[i].GetComponent<Animator>().SetTrigger("nextWave");
                     }
                 }*/
                 UI.transform.GetChild(2).gameObject.GetComponent<Text>().text = "WAVE: " + (wave + 1);
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
                //GameObject gameOverText = GameObject.FindGameObjectWithTag("GameOver");
                //gameOverText.GetComponent<Animator>().SetBool("gameOver", true);
            }
        }
    }
}
