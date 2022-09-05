using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class main : MonoBehaviour
{
    private GameObject panel;

    private GameObject levelchoose;

    private GameObject[] listener;
    // Start is called before the first frame update
    void Start()
    {
        levelchoose = GameObject.Find("Canvas").gameObject.transform.GetChild(1).gameObject;
        listener = new GameObject[5];
        panel = GameObject.Find("Canvas").gameObject.transform.GetChild(0).gameObject;
        listener[0] = panel.transform.GetChild(0).gameObject;
        listener[0].GetComponent<Button>().onClick.AddListener(() =>
        {
            panel.SetActive(false);
            levelchoose.SetActive(true);
        });
        listener[1] = panel.transform.GetChild(1).gameObject;
        listener[1].GetComponent<Button>().onClick.AddListener(() =>
        {
            listener[0].SetActive(false);
            listener[1].SetActive(false);
            panel.transform.GetChild(2).gameObject.SetActive(true);
        });
        /*
        for (int i = 0; i < 3; ++i)
        {
            listener[i+2] = levelchoose.transform.GetChild(i).gameObject;
            listener[i+2].GetComponent<Button>().onClick.AddListener(() =>
            {
                print(i+1);
                SceneManager.LoadScene(i + 1);
            });
        }*/
        listener[2] = levelchoose.transform.GetChild(0).gameObject;
        listener[2].GetComponent<Button>().onClick.AddListener(() =>
        {
            SceneManager.LoadScene(1);
        });
        listener[3] = levelchoose.transform.GetChild(1).gameObject;
        listener[3].GetComponent<Button>().onClick.AddListener(() =>
        {
            SceneManager.LoadScene(2);
        });
        listener[4] = levelchoose.transform.GetChild(2).gameObject;
        listener[4].GetComponent<Button>().onClick.AddListener(() =>
        {
            SceneManager.LoadScene(3);
        });
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && levelchoose.activeSelf)
        {
            levelchoose.SetActive(false);
            panel.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Space) && panel.transform.GetChild(2).gameObject.activeSelf)
        {
            listener[0].SetActive(true);
            listener[1].SetActive(true);
            panel.transform.GetChild(2).gameObject.SetActive(false);
        }
    }
}
