using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable()]
public class tower : MonoBehaviour
{
    private int Type { get; set; }
    private float AttackRange { get; set; }
    private float AttackSpeed { get; set; }
    private float Attack { get; set; }
    private enemy target = null;

    private bool Aim = false;

    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        /*
         1. check if aiming at a monster
         2. if so, check if the monster is still in range
         3. if so, firing 
         4. if not, looking for a new target and firing
         5. delay according to the attack speed*/
        if (this.Aim && this.checkInRange())
        {
            this.firing();
        }
        else
        {
            ;
        }
    }

    void SetTarget(enemy[] enemies)
    {
        float close = this.AttackRange;
        /* for each living monsters, check whether the monster who stays the closest to the tower in tower's range */
        foreach (enemy e in enemies )
        {
            float distance = (float)Math.Pow((e.transform.position.x - this.transform.position.x),2) +
                           (float)Math.Pow((e.transform.position.y - this.transform.position.y),2);
            if (distance <Math.Pow(close,2))
            {
                close = distance;
                this.target = e;
                this.Aim = true;
            }
        }
    }

    void firing()
    {

    }

    bool checkInRange()
    {
        float distance = (float)Math.Pow((this.target.transform.position.x - this.transform.position.x),2) + 
                         (float)Math.Pow((this.target.transform.position.y - this.transform.position.y),2);
        if (distance < Math.Pow(this.AttackRange,2))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
