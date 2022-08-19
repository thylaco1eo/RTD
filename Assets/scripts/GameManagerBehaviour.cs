using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerBehaviour : MonoBehaviour
{
    public Text goldLabel;
    public Text waveLabel;
    public GameObject[] nextWaveLabels;
    private int gold;
    public bool gameOver = false;

    private int wave;
    // Start is called before the first frame update
    void Start()
    {
        
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
            goldLabel.GetComponent<Text>().text = "GOLD: " + gold;
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
                 if (!gameOver)
                 {
                     for (int i = 0; i < nextWaveLabels.Length; i++)
                     {
                         nextWaveLabels[i].GetComponent<Animator>().SetTrigger("nextWave");
                     }
                 }
                 waveLabel.text = "WAVE: " + (wave + 1);
             }
         }
}
