using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {
    public GameObject gun;
    public GameObject gunInstance;
    public bool pickupActive;
    public int MAX_RESPAWN_TIME;
    public int remainingRespawnTime;
	// Use this for initialization
	void Start () {
        gunInstance = Instantiate(gun, transform.position, Quaternion.identity);
        pickupActive = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (pickupActive)
        {
            gunInstance.transform.Rotate(new Vector3(0, 0, 45) * Time.deltaTime);
        }
        else
        {
            remainingRespawnTime--;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        remainingRespawnTime = MAX_RESPAWN_TIME;
        pickupActive = false;
    }
}
