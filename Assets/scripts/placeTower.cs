using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class placeTower : MonoBehaviour
{
    public GameObject TowerPrefab;
    public AnimationCurve showCurve;
    public AnimationCurve hidCurve;
    public float Animationspeed;
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

    private void OnMouseUp()
    {
        StartCoroutine(ShowPanel(panel));

    }

    IEnumerator ShowPanel(GameObject gameObject)
    {
        float timer = 0;
        while (timer <= 1)
        {
            gameObject.transform.localScale = Vector3.one * showCurve.Evaluate(timer);
            timer += Time.deltaTime * Animationspeed;
            yield return null;
        }
    }

    IEnumerator HidePanel(GameObject gameObject)
    {
        float timer = 0;
        while (timer <= 1)
        {
            gameObject.transform.localScale = Vector3.one * showCurve.Evaluate(timer);
            timer += Time.deltaTime * Animationspeed;
            yield return null;
        }
    }
}
