using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using LitJson;
using System.IO;


public class enemy : MonoBehaviour
{
    private float speed = 1f;
    public float Armor;
    private int checkpoint = 0;
    private Vector3 startPosition;
    public GameObject[] map;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = map[checkpoint].transform.position;
        //ReadMap("./Assets/data/map.json");
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void ReadMap(string path)
    {
        string Jsonstring = File.ReadAllText(path);
        this.map = JsonMapper.ToObject<GameObject[]>(Jsonstring);
    }

    void Move()
    {
        Vector3 endPosition = map [checkpoint + 1].transform.position;
        float pathLength = Vector3.Distance (startPosition, endPosition);
        float totalTimeForPath = pathLength /speed;
        gameObject.transform.position = Vector2.Lerp (startPosition, endPosition, Time.deltaTime / totalTimeForPath);
        startPosition = gameObject.transform.position;
        if (gameObject.transform.position.Equals(endPosition))
        {
            if (checkpoint < map.Length - 2)
            {
                checkpoint++;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    public float DistancetoGoal()
    {
        float distance = 0;
        distance += Vector2.Distance(gameObject.transform.position, map[checkpoint].transform.position);
        for (int i = checkpoint + 1; i < map.Length - 1; i++)
        {
            distance += Vector2.Distance(map[i].transform.position, map[i+1].transform.position);
        }
        return distance;
    }

    public void freeze()
    {
        speed = 0.1f * speed;
    }

    public void restoreSpeed()
    {
        speed = 10 * speed;
    }

    public void ReduceArmor()
    {
        Armor = 0.7f * Armor;
    }

    public void RestoreArmor()
    {
        Armor = Armor / 0.7f;
    }

    public void GetStun()
    {
        speed = 0.0001f *speed;
    }

    public void RecoverFromStun()
    {
        speed = 10000f * speed;
    }
}
