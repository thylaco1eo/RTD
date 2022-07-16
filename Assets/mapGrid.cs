using System.Collections;
using System.Collections.Generic;
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
        cells = new mapcell[height * width];
        for (int i = 0, count = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                CreateCell(j,i,count++);
            }
        }
    }

    void CreateCell(int x, int y, int count)
    {
        Vector3 position;
        position.x = x * 10;
        position.y = y * 10;
        position.z = 0;
        cells[count] = Instantiate<mapcell>(cellPrefab);
        cells[count].transform.SetParent(transform,false);
        cells[count].transform.localPosition = position;
        cells[count].transform.localScale = new Vector3(10, 10, 1);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
