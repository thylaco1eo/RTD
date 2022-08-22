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

    private GameManagerBehaviour gameManager;
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
            GameObject[] child = new GameObject[4];
            panel.SetActive(true);
            panel.transform.GetChild(1).transform.position = gameObject.transform.position;
            GameObject test = gameObject.GetComponent<placeTower>().panel.transform.GetChild(1).gameObject;
            child[0] = test.transform.GetChild(0).gameObject;
            child[0].GetComponent<Button>().onClick.RemoveAllListeners();
            child[0].GetComponent<Button>().onClick.AddListener(() =>
            {
                if (gameManager.Gold >= firetower.GetComponent<tower>().levels[0].cost)
                {
                    gameManager.Gold -= firetower.GetComponent<tower>().levels[0].cost;
                    Tower = (GameObject)Instantiate(firetower, transform.position+Vector3.back, Quaternion.identity);
                    panel.SetActive(false);
                }
            });
            child[1] = test.transform.GetChild(1).gameObject;
            child[1].GetComponent<Button>().onClick.RemoveAllListeners();
            child[1].GetComponent<Button>().onClick.AddListener(() =>
            {
                if (gameManager.Gold >= icetower.GetComponent<tower>().levels[0].cost){
                    gameManager.Gold -= icetower.GetComponent<tower>().levels[0].cost;
                    Tower = (GameObject)Instantiate(icetower, transform.position + Vector3.back, Quaternion.identity);
                    panel.SetActive(false);
                }
            });
            child[2] = test.transform.GetChild(2).gameObject;
            child[2].GetComponent<Button>().onClick.RemoveAllListeners();
            child[2].GetComponent<Button>().onClick.AddListener(() =>
            {
                if (gameManager.Gold >= watertower.GetComponent<tower>().levels[0].cost){
                    gameManager.Gold -= watertower.GetComponent<tower>().levels[0].cost;
                    Tower = (GameObject)Instantiate(watertower, transform.position + Vector3.back, Quaternion.identity);
                    panel.SetActive(false);
                }
            });
            child[3] = test.transform.GetChild(3).gameObject;
            child[3].GetComponent<Button>().onClick.RemoveAllListeners();
            child[3].GetComponent<Button>().onClick.AddListener(() =>
            {
                if (gameManager.Gold >= electower.GetComponent<tower>().levels[0].cost){
                    gameManager.Gold -= electower.GetComponent<tower>().levels[0].cost;
                    Tower = (GameObject)Instantiate(electower, transform.position + Vector3.back, Quaternion.identity);
                    panel.SetActive(false);
                }
            });
        }
        else if(CanUpgrade()&& !Upgradepanel.activeSelf)
        {
            GameObject[] child = new GameObject[2];
            Upgradepanel.transform.GetChild(1).gameObject.transform.GetChild(2).GetComponent<Text>().text = "-"+Tower.GetComponent<tower>().levels[1].cost;
            Upgradepanel.transform.GetChild(1).gameObject.transform.GetChild(3).GetComponent<Text>().text = "+"+(Tower.GetComponent<tower>().currentlevel.cost -50);
            Upgradepanel.SetActive(true);
            Upgradepanel.transform.GetChild(1).transform.position = gameObject.transform.position;
            child[0] = Upgradepanel.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject;
            child[0].GetComponent<Button>().onClick.RemoveAllListeners();
            child[0].GetComponent<Button>().onClick.AddListener(() =>
            {
                if(gameManager.Gold >= Tower.GetComponent<tower>().levels[1].cost)
                {
                    gameManager.Gold -= Tower.GetComponent<tower>().levels[1].cost;
                    child[0].GetComponent<Button>().onClick.RemoveAllListeners();
                    Tower.GetComponent<tower>().IncreaseLevel();
                    Upgradepanel.SetActive(false);
                }
            });
            child[1] = Upgradepanel.transform.GetChild(1).gameObject.transform.GetChild(1).gameObject;
            child[1].GetComponent<Button>().onClick.RemoveAllListeners();
            child[1].GetComponent<Button>().onClick.AddListener(() =>
            {
                gameManager.Gold += Tower.GetComponent<tower>().currentlevel.cost -50;
                child[0].GetComponent<Button>().onClick.RemoveAllListeners();
                Destroy(Tower);
                Upgradepanel.SetActive(false);
            });
        }
        else if(!CanPlaceTower() && !CanUpgrade() && !Upgradepanel.activeSelf)
        {
            GameObject child;
            Upgradepanel.transform.GetChild(1).gameObject.transform.GetChild(2).GetComponent<Text>().text = "Max";
            Upgradepanel.transform.GetChild(1).gameObject.transform.GetChild(3).GetComponent<Text>().text = "+"+(Tower.GetComponent<tower>().currentlevel.cost -50);
            Upgradepanel.SetActive(true);
            Upgradepanel.transform.GetChild(0).gameObject.SetActive(false);
            Upgradepanel.transform.GetChild(1).transform.position = gameObject.transform.position;
            child = Upgradepanel.transform.GetChild(1).gameObject.transform.GetChild(1).gameObject;
            child.GetComponent<Button>().onClick.RemoveAllListeners();
            child.GetComponent<Button>().onClick.AddListener(() =>
            {
                gameManager.Gold += Tower.GetComponent<tower>().currentlevel.cost -50;
                Destroy(Tower);
                child.GetComponent<Button>().onClick.RemoveAllListeners();
                Upgradepanel.SetActive(false);
            });
        }
    }

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerBehaviour>();
    }
}
