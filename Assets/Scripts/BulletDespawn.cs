using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDespawn : MonoBehaviour {


    public int MAX_BOUNCES;
    public int remainingBounces;
	public float despawnTime;
    public float damage;
	public AudioClip AC;
    public int playerNumber;
	// Use this for initialization
	void Start () {
        remainingBounces = MAX_BOUNCES;
		/*if (remainingBounces > 0) {
			GetComponent<BoxCollider2D> ().isTrigger = false;
		} else {
			GetComponent<BoxCollider2D> ().isTrigger = true;
		}*/

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
            /*(remainingBounces <= 0)
            {
                Destroy(gameObject);
			}*/
			if (remainingBounces > 0) {
				GetComponent<BoxCollider2D> ().isTrigger = false;
			} else {
				GetComponent<BoxCollider2D> ().isTrigger = true;
				Destroy(gameObject);
			}
            remainingBounces--;
		}

	}
	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Wall") {
			if (remainingBounces > 0) {
				GetComponent<BoxCollider2D> ().isTrigger = false;
			} else {
				GetComponent<BoxCollider2D> ().isTrigger = true;
			}
			remainingBounces--;
		}
	}
}
