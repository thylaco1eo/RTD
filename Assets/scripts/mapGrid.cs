using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using LitJson;
using UnityEngine.SceneManagement;

public class mapGrid : MonoBehaviour
{
    public int width = 10;
    public int height = 5;

    public mapcell cellPrefab;

    private mapcell[] cells;
    private string s;
    [SerializeField]
    public int[] map;
    // Start is called before the first frame update
    void Start()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        string path = "./Assets/data/map-"+index+".json";
        cells = new mapcell[4 * height * width];
        map = new int[4 * height*width];
        if (File.Exists(path))
        {
            map = LoadMap(path);
            for (int i = -1*height, count = 0; i < height; i++)
            {
                for (int j = -1*width; j < width; j++)
                {
                    CreateCell(j, i, count++, map[(i+height)*2*width+j+width]);
                }
            }
        }
        else
        {
            int type;
            for (int i = 0, count = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (i == j || j == i+1)
                    {
                        type = 1;
                    }
                    else
                    {
                        type = 0;
                    }
                    CreateCell(j,i,count++,type);
                    map[i*width+j] = type;
                }
            }
            s = JsonMapper.ToJson(map);
            File.WriteAllText("./Assets/data/map.json", s);
        }
        
    }

	int[] LoadMap(string path)
	{
		string Jsonstring = File.ReadAllText(path);
        int[] data = JsonMapper.ToObject<int[]>(Jsonstring);
        return data;
    }

    void CreateCell(int x, int y, int count,int type)
    {
        Vector3 position;
        position.x = x+0.5f;
        position.y = y+0.5f;
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
