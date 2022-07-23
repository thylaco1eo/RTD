using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class mapcell : MonoBehaviour
{
    private int Celltype;
    // Start is called before the first frame update

    public void setCelltype(int type)
    {
        this.Celltype = type;
    }

    public string SavetoString()
    {
        return JsonUtility.ToJson(this);
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
