using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using LitJson;
using System.IO;


public class enemy : MonoBehaviour
{
    private int width = 6;
    private int height = 6;
    private Vector3[] m =
    {
        new Vector3(-1,0,0),
        new Vector3(0,-1,0),
        new Vector3(1,0,0),
        new Vector3(0,1,0)
    };
    private int[] map;
    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = new Vector3(0,0,0);
        ReadMap("./Assets/data/map.json");
        
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    void ReadMap(string path)
    {
        string Jsonstring = File.ReadAllText(path);
        this.map = JsonMapper.ToObject<int[]>(Jsonstring);
    }

    void move()
    {
        foreach(Vector3 i in m)
        {
            Vector3 tmp = i + this.transform.position;
            if (tmp.x>=0 && tmp.y>=0 && tmp.x < this.height && tmp.y < this.width && this.map[(int)tmp.y*width +(int)tmp.x] == 1)
            {
                this.map[(int)this.transform.position.y * this.width + (int)this.transform.position.x] = 0;
                this.transform.position = tmp;
                
            }
        }
    }
}
