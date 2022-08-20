using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickHandler : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        if (gameObject.transform.GetChild(1).gameObject.activeSelf)
        {
            gameObject.transform.GetChild(1).gameObject.SetActive(false);
        }

        if (gameObject.transform.GetChild(2).gameObject.activeSelf)
        {
            gameObject.transform.GetChild(2).gameObject.SetActive(false);
        }
    }
}
