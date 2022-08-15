using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable()]
public class tower : MonoBehaviour
{
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

}
