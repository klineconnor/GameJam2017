using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {
    public GameObject[] guns;
    public GameObject gunInstance;
    public bool pickupActive;
    public int MAX_RESPAWN_TIME;
    public int remainingRespawnTime;
	public int gunIndex;
	// Use this for initialization
	void Start () {
		gunIndex = Random.Range (0, guns.Length);
        gunInstance = Instantiate(guns[gunIndex], transform.position, Quaternion.identity);
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
            if (remainingRespawnTime <= 0)
            {
                print("attemptreset");
                gunInstance = Instantiate(guns[gunIndex], transform.position, Quaternion.identity);
                GetComponent<CircleCollider2D>().enabled = true;
                pickupActive = true;
            }
            remainingRespawnTime--;
        }
    }
    public void PickupGrabbed()
    {
        remainingRespawnTime = MAX_RESPAWN_TIME;
        GetComponent<CircleCollider2D>().enabled = false;
        pickupActive = false;
    }
}
