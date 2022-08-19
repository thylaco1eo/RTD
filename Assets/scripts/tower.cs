using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable()]
public class Towerlevel
{
    public int cost;
    public GameObject visual;
    public int damage;
    public float AttackSpeed;
}
public class tower : MonoBehaviour
{
    public List<Towerlevel> levels;
    private Towerlevel currentlevel;
    public GameObject type;
    public float AttackRange { get; set; }
    public float AttackSpeed;
    private float Attack { get; set; }
    public int element;

    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Towerlevel Currentlevel
    {
        get
        {
            return currentlevel;
        }
        set
        {
            currentlevel = value;
            int currentlevelindex = levels.IndexOf(currentlevel);
            levels[1-currentlevelindex].visual.SetActive(false);
            levels[currentlevelindex].visual.SetActive(true);
        }
    }

    public int GetCurrentLevel()
    {
        return levels.IndexOf(currentlevel);
    }
    
    void OnEnable()
    {
        currentlevel = levels[0];
    }

}
