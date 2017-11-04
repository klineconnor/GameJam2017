using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDespawn : MonoBehaviour {

	public float despawnTime;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (despawnTime == 0) {
			Destroy (gameObject);
		}
		despawnTime--;
	}
}
