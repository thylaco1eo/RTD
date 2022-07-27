using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
using LitJson;

public class mapGrid : MonoBehaviour
{
    public int width = 6;
    public int height = 6;

    public mapcell cellPrefab;

    private mapcell[] cells;
    private string s;
    [SerializeField]
    private int[,] map;
    // Start is called before the first frame update
    void Start()
    {
        string path = "./Assets/data/map.json";
        if (File.Exists(path))
        {
            LoadMap(path);
        }
        int type;
        cells = new mapcell[height * width];
        map = new int[height, width];
        for (int i = 0, count = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                if (i == j)
                {
                    type = 1;
                }
                else
                {
                    type = 0;
                }
                CreateCell(j,i,count++,type);
                map[i,j] = type;
            }
        }
        s = JsonMapper.ToJson(map);
        File.WriteAllText("./Assets/data/map.json", s);
    }

	int LoadMap(string path)
	{
		string Jsonstring = File.ReadAllText(path);
        JsonData data = JsonMapper.ToObject(Jsonstring);
        return data[0];
    }

    void CreateCell(int x, int y, int count,int type)
    {
        Vector3 position;
        position.x = x;
        position.y = y;
        position.z = 0;
        cells[count] = Instantiate<mapcell>(cellPrefab);
        cells[count].transform.SetParent(transform,false);
        cells[count].setCelltype(type);
        cells[count].transform.localPosition = position;
        cells[count].transform.localScale = new Vector3(1, 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
