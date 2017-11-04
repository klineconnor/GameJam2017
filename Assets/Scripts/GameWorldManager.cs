using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

public class GameWorldManager : MonoBehaviour
{
    LevelManager levelManager;
    GameObject player;
    // Use this for initialization
    void Start()
    {
        levelManager = GetComponent<LevelManager>();
        LoadLevel();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GenerateLevel()
    {
        
    }

    public void LoadLevel()
    {
        string path = Path.Combine(Application.dataPath, "testfile.xml");
        levelManager.LoadLevelFromXML(path);
    }
    public void PlayerReadyFlag()
    {

    }
}
