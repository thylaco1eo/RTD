using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class mapcell : MonoBehaviour
{
    [SerializeField]
    // Start is called before the first frame update

    public void setCelltype(int type)
    {
        string path = "image/tileGrass1.png";
        switch (type)
        {
            case 0: path = "image/tileGrass1";
                break;
            case 1: path = "image/tileSand_roadEast";
                break;
            case 2: path = "image/tileSand_roadNorth";
                break;
            case 3: path = "image/tileSand_roadCornerLL";
                break;
            case 4: path = "image/tileSand_roadCornerLR";
                break;
            case 5: path = "image/tileSand_roadCornerUL";
                break;
            case 6: path = "image/tileSand_roadCornerUR";
                break;
        }
        
        Sprite sprite = Resources.Load<Sprite>(path);
        this.GetComponent<SpriteRenderer>().sprite = sprite;
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
