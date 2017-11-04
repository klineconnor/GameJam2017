using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDespawn : MonoBehaviour {


    public int MAX_BOUNCES;
    public int remainingBounces;
	public float despawnTime;
	// Use this for initialization
	void Start () {
        remainingBounces = MAX_BOUNCES;
	}
	
	// Update is called once per frame
	void Update () {
		if (despawnTime == 0) {
			Destroy (gameObject);
		}
		despawnTime--;
	}

	void OnTriggerEnter2D(Collider2D other) {
		//print (other.gameObject.tag);
		if (other.gameObject.tag == "Wall") {
            if(remainingBounces <= 0)
            {
                Destroy(gameObject);
            }
            remainingBounces--;
		}

	}
}
