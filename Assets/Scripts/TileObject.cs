using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileObject : MonoBehaviour {
    
    public string tileName;
    public Vector2 tileID;
    public int tileTypeID;
    public LevelManager levelManager;
	// Use this for initialization
	void Start () {
        levelManager = gameObject.GetComponentInParent<LevelManager>();
		if (!levelManager.editMode && ((tag == "Empty") || (tag == "Spawn")))
        {
            GetComponent<SpriteRenderer>().enabled = false;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public Sprite GetSprite()
    {
        return GetComponent<SpriteRenderer>().sprite;
    }



}
