using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable()]
public class Towerlevel
{
    public int cost;
    public int damage;
    public float AttackSpeed;
}
public class tower : MonoBehaviour
{
    public List<Towerlevel> levels;
    public Towerlevel currentlevel;
    public GameObject type;
    public float AttackRange { get; set; }
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
        }
    }

    public int GetCurrentLevel()
    {
        return levels.IndexOf(currentlevel);
    }

    public void IncreaseLevel()
    {
        gameObject.transform.localScale = gameObject.transform.localScale * 1.5f;
        currentlevel = levels[1];
    }
    
    void OnEnable()
    {
        currentlevel = levels[0];
    }

}
