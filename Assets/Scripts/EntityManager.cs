using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityManager : MonoBehaviour {

    public List<GameObject> entitySpawners;
	// Use this for initialization
	void Start () {
        entitySpawners = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddEntitySpawner(GameObject es)
    {
        entitySpawners.Add(es);
        print("added spawner");
    }

    public void RespawnEntity(GameObject entity)
    {
        for (int i = 0; i < entitySpawners.Count; i++)
        {
			if (entitySpawners[i].GetComponent<EntitySpawner>().entity.tag == entity.tag)
            { 
                entitySpawners[i].GetComponent<EntitySpawner>().SpawnEntity();
            }
        }
    }
}
