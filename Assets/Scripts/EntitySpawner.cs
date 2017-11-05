using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitySpawner : MonoBehaviour {
    public GameObject entity;
    public bool spawnAtStart;
    EntityManager em;
	// Use this for initialization
	void Start () {
        em = GetComponentInParent<EntityManager>();
        em.AddEntitySpawner(gameObject);
		int totalPlayers = GameObject.Find ("Persistant").GetComponent<TitleScreen> ().numPlayers;
		int playerNum = entity.GetComponent<PlayerController> ().playerNumber;
		print ("Spawning " + playerNum + " out of " + totalPlayers);
		if (playerNum <= totalPlayers) {
			print ("Success " + playerNum);
			if (spawnAtStart)
			{
				SpawnEntity();
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SpawnEntity()
    {
        //print("Spawning");
        GameObject temp = Instantiate(entity, transform.position, Quaternion.identity);
		temp.GetComponent<PlayerController>().em = em;
    }
}
