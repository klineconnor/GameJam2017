using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using UnityEngine;

[XmlRoot("LevelData")]
public class LevelData {
    [XmlAttribute("rows")]
    public int rows;
    [XmlAttribute("columns")]
    public int columns;
    [XmlIgnore]
    public int[,] tileGrid;

    [XmlArray("tileList")]
    public int[] tileList;
    /*
    public LevelData(int r, int c, int[,] grid)
    {

        rows = r;
        columns = c;
        tileGrid = grid;
    }
    */

    public void setVals(int r, int c, int[,] grid)
    {
        rows = r;
        columns = c;
        tileGrid = grid;
    }

    public void Save(string path)
    {
        tileList = new int[columns * rows];
        for (int x = 0; x < columns; x++)
        {
            for (int y = 0; y < rows; y++)
            {
                tileList[(x * rows) + y] = tileGrid[x, y];
            }
        }

        var serializer = new XmlSerializer(typeof(LevelData));
        using (var stream = new FileStream(path, FileMode.Create))
        {
            serializer.Serialize(stream, this);
        }
    }

    public static LevelData Load(string path)
    {
        var serializer = new XmlSerializer(typeof(LevelData));
        using (var stream = new FileStream(path, FileMode.Open))
        {
            LevelData ld = serializer.Deserialize(stream) as LevelData;
            ld.SetupGridFromList();
            return ld;
        }
    }

    //Loads the xml directly from the given string. Useful in combination with www.text.
    public static LevelData LoadFromText(string text)
    {
        var serializer = new XmlSerializer(typeof(LevelData));
        return serializer.Deserialize(new StringReader(text)) as LevelData;
    }

    public void SetupGridFromList()
    {
        tileGrid = new int[columns, rows];
        for (int x = 0; x < columns; x++)
        {
            for (int y = 0; y < rows; y++)
            {
                tileGrid[x, y] = tileList[(x * rows) + y];
            }
        }
    }
}
