using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed = 10;
    public int damage;
    public GameObject target;
    public Vector3 startPosition;
    public Vector3 targetPosition;

    private float distance;
    private float startTime;


    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        distance = Vector2.Distance(startPosition,targetPosition);
        
    }

    // Update is called once per frame
    void Update()
    {
        float travelTime = Time.time - startTime;
        gameObject.transform.position = Vector3.Lerp(startPosition, targetPosition, travelTime * speed/distance);
        if (gameObject.transform.position.Equals(targetPosition))
        {
            if (target != null)
            {
                ;
            }
            Destroy(gameObject);
        }  
    }
}
