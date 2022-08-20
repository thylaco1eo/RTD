using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using LitJson;
using System.IO;
using Unity.VisualScripting;


public class enemy : MonoBehaviour
{
    public float speed = 1f;
    public float Armor;
    private int checkpoint = 0;
    private Vector3 startPosition;
    public GameObject[] map;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = map[checkpoint].transform.position;
        RotateIntoMoveDirection();
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
        gameObject.transform.position = Vector3.Lerp (startPosition, endPosition, Time.deltaTime / totalTimeForPath);
        startPosition = gameObject.transform.position;
        if (gameObject.transform.position.Equals(endPosition))
        {
            if (checkpoint < map.Length - 2)
            {
                checkpoint++;
                RotateIntoMoveDirection();
            }
            else
            {
                Destroy(gameObject);
                GameManagerBehaviour gameManager = GameObject.Find("GameManager").GetComponent<GameManagerBehaviour>();
                gameManager.Health -= 10;
            }
        }
    }
    
    private void RotateIntoMoveDirection()
    {
        //1
        Vector3 newStartPosition = map [checkpoint].transform.position;
        Vector3 newEndPosition = map [checkpoint + 1].transform.position;
        Vector3 newDirection = (newEndPosition - newStartPosition);
        //2
        float x = newDirection.x;
        float y = newDirection.y;
        float rotationAngle = Mathf.Atan2 (y, x) * 180 / Mathf.PI;
        //3
        gameObject.transform.rotation = Quaternion.AngleAxis(rotationAngle+90, Vector3.forward);
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

    public void KnockedBack(Vector3 source)
    {
        Vector3 direction = (map[checkpoint+1].transform.position-startPosition).normalized;
        Vector3 distance = Vector3.Dot(direction, (gameObject.transform.position-source).normalized) * direction;
        startPosition += distance*0.2f;
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
