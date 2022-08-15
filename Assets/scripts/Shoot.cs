using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public List<GameObject> enemies;
    private tower towerData;

    private float lastShoot;

    public GameObject target = null;
    // Start is called before the first frame update
    void Start()
    {
        enemies = new List<GameObject>();
        lastShoot = Time.time;
        towerData = gameObject.GetComponentInChildren<tower>();
    }

    // Update is called once per frame
    void Update()
    {
        target = null;
        float minimalDistance = float.MaxValue;
        foreach (GameObject enemy in enemies)
        {
            float distance = enemy.GetComponent<enemy>().DistancetoGoal();
            if (distance<minimalDistance)
            {
                target = enemy;
                minimalDistance = distance;
            }
        }

        if (target is not null)
        {
            if (Time.time - lastShoot > towerData.AttackSpeed)
            {
                Shooting(target.GetComponent<Collider2D>());
                lastShoot = Time.time;
            }
        }
        
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

    void Shooting(Collider2D target)
    {
        GameObject bullet = towerData.type;
        Vector3 startPosition = gameObject.transform.position;
        Vector3 targetPosition = target.transform.position;
        startPosition.z = bullet.transform.position.z;
        targetPosition.z = bullet.transform.position.z;
        GameObject newBullet = Instantiate(bullet);
        newBullet.transform.position = startPosition;
        Bullet bulletcomp = newBullet.GetComponent<Bullet>();
        bulletcomp.type = towerData.element;
        bulletcomp.target = target.gameObject;
        bulletcomp.startPosition = startPosition;
        bulletcomp.targetPosition = targetPosition;
        bulletcomp.damage = 5.0f;

    }


}
