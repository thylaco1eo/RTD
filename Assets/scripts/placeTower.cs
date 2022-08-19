using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class placeTower : MonoBehaviour
{
    public GameObject firetower;
    public GameObject icetower;
    public GameObject watertower;
    public GameObject electower;
    public GameObject panel;

    private GameObject Tower;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private bool CanPlaceTower()
    {
        return Tower == null;
    }

    private bool CanUpgrade()
    {
        if (Tower != null)
        {
            int level = Tower.GetComponent<tower>().GetCurrentLevel();
            if (level == 1)
            {
                return false
            }
            else
            {
                return true;
            }
        }
    }

    private void OnMouseUp()
    {
        if(CanPlaceTower())
        {
            GameObject child;
            ShowPanel(panel);
            GameObject test = gameObject.GetComponent<placeTower>().panel;
            child = test.transform.GetChild(0).gameObject;
            child.GetComponent<Button>().onClick.AddListener(() =>
            {
                Tower = (GameObject)Instantiate(firetower, transform.position, Quaternion.identity);
                HidePanel(panel);
            });
            child = test.transform.GetChild(1).gameObject;
            child.GetComponent<Button>().onClick.AddListener(() =>
            {
                Tower = (GameObject)Instantiate(icetower, transform.position, Quaternion.identity);
                HidePanel(panel);
            });
            child = test.transform.GetChild(2).gameObject;
            child.GetComponent<Button>().onClick.AddListener(() =>
            {
                Tower = (GameObject)Instantiate(watertower, transform.position, Quaternion.identity);
                HidePanel(panel);
            });
            child = test.transform.GetChild(3).gameObject;
            child.GetComponent<Button>().onClick.AddListener(() =>
            {
                Tower = (GameObject)Instantiate(electower, transform.position, Quaternion.identity);
                HidePanel(panel);
            });
        }
        else if(CanUpgrade())
        {
            
        }
    }
    

    void ShowPanel(GameObject gameObject)
    {
        gameObject.SetActive(true);
    }

    void HidePanel(GameObject gameObject)
    {
        gameObject.SetActive(false);
    }
}
