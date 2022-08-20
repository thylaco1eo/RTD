using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class placeTower : MonoBehaviour
{
    private static placeTower instance;

    public static placeTower Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        instance = this;
    }

    public GameObject firetower;
    public GameObject icetower;
    public GameObject watertower;
    public GameObject electower;
    public GameObject panel;
    public GameObject Upgradepanel;

    private GameObject Tower;
  
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
                return false;
            }
            else
            {
                return true;
            }
        }
        else
        {
            return false;
        }
    }

    private void OnMouseUp()
    {
        if(CanPlaceTower() && !panel.activeSelf)
        {
            GameObject child;
            panel.transform.position = gameObject.transform.position;
            panel.SetActive(true);
            GameObject test = gameObject.GetComponent<placeTower>().panel;
            child = test.transform.GetChild(0).gameObject;
            child.GetComponent<Button>().onClick.AddListener(() =>
            {
                Tower = (GameObject)Instantiate(firetower, transform.position, Quaternion.identity);
                panel.SetActive(false);
            });
            child = test.transform.GetChild(1).gameObject;
            child.GetComponent<Button>().onClick.AddListener(() =>
            {
                Tower = (GameObject)Instantiate(icetower, transform.position, Quaternion.identity);
                panel.SetActive(false);
            });
            child = test.transform.GetChild(2).gameObject;
            child.GetComponent<Button>().onClick.AddListener(() =>
            {
                Tower = (GameObject)Instantiate(watertower, transform.position, Quaternion.identity);
                panel.SetActive(false);
            });
            child = test.transform.GetChild(3).gameObject;
            child.GetComponent<Button>().onClick.AddListener(() =>
            {
                Tower = (GameObject)Instantiate(electower, transform.position, Quaternion.identity);
                panel.SetActive(false);
            });
        }
        else if(CanUpgrade()&& !Upgradepanel.activeSelf)
        {
            GameObject child;
            Upgradepanel.transform.position = gameObject.transform.position;
            Upgradepanel.SetActive(true);
            child = Upgradepanel.transform.GetChild(0).gameObject;
            child.GetComponent<Button>().onClick.AddListener(() =>
            {
                Tower.GetComponent<tower>().IncreaseLevel();
                Upgradepanel.SetActive(false);
            });
            child = Upgradepanel.transform.GetChild(1).gameObject;
            child.GetComponent<Button>().onClick.AddListener(() =>
            {
                Destroy(Tower);
                Upgradepanel.SetActive(false);
            });
        }
        else if (!CanUpgrade() && !CanUpgrade() && !Upgradepanel.activeSelf)
        {
            
        }
    }
}
