using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class LevelManager : MonoBehaviour {

   
    public int columns = 8;
    public int rows = 8;
    public Vector2 gridOffset;
    public bool editMode;

    public GameObject[] worldTiles;

    public LevelData levelData;

    int[,] tileGrid;
    GameObject[,] levelTiles;

    private Transform boardHolder;
    private List<Vector3> gridPositions = new List<Vector3>();

       

    void InitializeGrid()
    {
        tileGrid = new int[columns, rows];

        levelTiles = new GameObject[columns, rows];
        levelData = new LevelData();
        levelData.setVals(rows, columns, tileGrid);
    }

    void InitializeGridFromXML()
    {
        columns = levelData.columns;
        rows = levelData.rows;
        tileGrid = levelData.tileGrid;

        levelTiles = new GameObject[columns, rows];
        //BoardSetup();
        /*for (int x = 0; x < columns; x++)
        {
            for (int y = 0; y < rows; y++)
            {
                Destroy(levelTiles[x, y]);
            }
        }*/

        boardHolder = new GameObject("Board").transform;

        print("Columns: " + columns + ", Rows: " + rows);
        for (int x = 0; x < columns; x++)
        {
            for (int y = 0; y < rows; y++)
            {
                GameObject toInstantiate = worldTiles[tileGrid[x,y]];
                //print(worldTiles[0].GetComponent<SpriteRenderer>().isVisible);
                //print(x + ", " + y);
                levelTiles[x, y] = Instantiate(toInstantiate, new Vector3((2 * x) + gridOffset.x, (2 * y) + gridOffset.y, 0f), Quaternion.identity) as GameObject;
                levelTiles[x, y].transform.SetParent(gameObject.transform);
                levelTiles[x, y].GetComponent<TileObject>().tileID = new Vector2(x, y);
                levelTiles[x, y].GetComponent<TileObject>().tileTypeID = tileGrid[x, y];
            }
        }
    }

    void BoardSetup()
    {
        boardHolder = new GameObject("Board").transform;

        print("Columns: " + columns + ", Rows: " + rows);
        for (int x = 0; x < columns ; x++)
        {
            for (int y = 0; y < rows ; y++)
            {
                GameObject toInstantiate = worldTiles[0];
                //print(worldTiles[0].GetComponent<SpriteRenderer>().isVisible);
                //print(x + ", " + y);
                levelTiles[x,y] = Instantiate(toInstantiate, new Vector3((2*x) + gridOffset.x, (2*y) + gridOffset.y, 0f), Quaternion.identity) as GameObject;
                levelTiles[x, y].transform.SetParent(gameObject.transform);
                levelTiles[x, y].GetComponent<TileObject>().tileID = new Vector2(x, y);
                levelTiles[x, y].GetComponent<TileObject>().tileTypeID = 0;
            }
        }
    }


    public void SetupScene(int r, int c)
    {
        rows = r;
        columns = c;
        InitializeGrid();
        BoardSetup();        
    }

    public void LoadLevelFromXML(string path)
    {
        levelData = LevelData.Load(path);

        InitializeGridFromXML();

        print("file load complete (LM)");
    }
}
