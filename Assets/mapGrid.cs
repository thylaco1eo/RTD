using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;

public class mapGrid : MonoBehaviour
{
    public int width = 6;
    public int height = 6;

    public mapcell cellPrefab;

    private mapcell[] cells;
    // Start is called before the first frame update
    void Start()
    {
        int type;
        string s;
        cells = new mapcell[height * width];
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
                s = cells[count - 1].SavetoString();
                Console.WriteLine(s);
                File.WriteAllText("./Assets/data/map.json", s);
            }
        }
        
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
