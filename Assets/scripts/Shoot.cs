using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public List<GameObject> enemies;
    private tower towerData;
    // Start is called before the first frame update
    void Start()
    {
        enemies = new List<GameObject>();
        towerData = gameObject.GetComponentInChildren<tower>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnemyDestroy(GameObject enemy)
    {
        enemies.Remove (enemy);
    }

    void OnTriggerEnter2D (Collider2D other)
    {
    // 2
        if (other.gameObject.tag.Equals("Enemy"))
        {
            enemies.Add(other.gameObject);
            EnemyDestructionDelegate del =
                other.gameObject.GetComponent<EnemyDestructionDelegate>();
            del.enemyDelegate += OnEnemyDestroy;
        }
    }
    // 3
    void OnTriggerExit2D (Collider2D other)
    {
        if (other.gameObject.tag.Equals("Enemy"))
        {
            enemies.Remove(other.gameObject);
            EnemyDestructionDelegate del =
                other.gameObject.GetComponent<EnemyDestructionDelegate>();
            del.enemyDelegate -= OnEnemyDestroy;
        }
    }

    void shooting(Collider2D target)
    {
        GameObject bullet = towerData.type;
        Vector3 startPosition = gameObject.transform.position;
        Vector3 targetPosition = target.transform.position;
    }


}
