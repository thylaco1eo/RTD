using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10;
    public float damage;
    public GameObject target;
    public Vector3 startPosition;
    public Vector3 targetPosition;
    public int type;

    private float distance;
    private float startTime;


    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        distance = Vector3.Distance(startPosition,targetPosition);
        
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
                float multi = target.GetComponent<Status>().reaction(type);
                float Armor = target.GetComponent<enemy>().Armor;
                Transform healthBarTransform = target.transform.Find("HealthBar");
                HealthBar healthBar = 
                    healthBarTransform.gameObject.GetComponent<HealthBar>();
                healthBar.currentHealth -= Mathf.Max(damage*multi/Armor, 0);
                // 4
                if (healthBar.currentHealth <= 0)
                {
                    Destroy(target);
                }
            }
            Destroy(gameObject);
        }  
    }
}
