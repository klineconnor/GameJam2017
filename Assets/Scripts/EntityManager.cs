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

    public void SpawnStartingSpawns()
    {
        /*print("EM starting spawns. " + entitySpawners.Count + " spawners in list");
        for (int i = 0; i < entitySpawners.Count; i++)
        {
            if (entitySpawners[i].GetComponent<EntitySpawner>().spawnAtStart)
            {
                entitySpawners[i].GetComponent<EntitySpawner>().SpawnEntity();
            }
        }*/
    }
}
