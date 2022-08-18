using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{
    private int status;
    private float[] timer;
    private int count;

    private bool[] S;
    // Start is called before the first frame update
    void Start()
    {
        // freeze, Superconduction, Electrification
        S = new bool[3]{false,false,false};
        timer = new float[3]{0.0f,0.0f,0.0f};
    }

    // Update is called once per frame
    void Update()
    {
        if (S[0] && timer[0] - Time.deltaTime <= 0)
        {
            gameObject.GetComponent<enemy>().restoreSpeed();
            timer[0] = 0.0f;
            S[0] = false;
            status = 0;
        }
        else
        {
            timer[0] -= Time.deltaTime;
        }
    }

    public float reaction(int type)
    {
        float multi = 1.0f;
        if (status == 0 || status == type)
        {
            status = type;
        }
        else
        {
            switch (status+type)
            {
                case 3:// ice(1)+water(2) = freezing(3)
                    status = 0;
                    Freeze();
                    break;
                case 5:// ice(1)+fire(4) = melt(5)
                    status = 0;
                    Melt();
                    multi = 1.5f;
                    break;
                case 6://water(2)+fire(4) = evaporation(6)
                    status = 0;
                    Evaporation();
                    multi = 2.0f;
                    break;
                case 9:// ice(1)+elct(8) = Superconduction(9)
                    status = 0;
                    Superconduction();
                    break;
                case 10:// water(2)+elct(8) = Electrification(10)
                    status = 0;
                    Electrification();
                    multi = 1.1f;
                    break;
                case 12://fire(4)+elct(8) = explosion(12)
                    status = 0;
                    Explosion();
                    multi = 1.3f;
                    break;
            }
        }
        return multi;
    }

    void Freeze()
    {
        if (!S[0])
        {
            gameObject.GetComponent<enemy>().freeze();
        }
        timer[0] = 2.0f;
        S[0] = true;
    }

    void Explosion()
    {
        
    }

    void Melt()
    {
        
    }

    void Evaporation()
    {
        
    }

    void Superconduction()
    {
        
    }

    void Electrification()
    {
        
    }
    
}