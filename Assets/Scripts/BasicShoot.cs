using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicShoot : MonoBehaviour {

	public GameObject Reticle;
	public GameObject bullet;
	public float speed;
	public float CoolDown;
	private float myCoolDown;
	private GameObject projectile;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (myCoolDown > 0) {
			myCoolDown--;
		}

		if (Input.GetAxis("FireP1")>0) {
			//print ("Try Fire");
			Vector2 target = Reticle.transform.position;
			Vector2 myPos = new Vector2(transform.position.x,transform.position.y);
			Vector2 direction = target - myPos;

			direction.Normalize();
			Quaternion rotation = Quaternion.Euler( 0, 0, Mathf.Atan2 ( direction.y, direction.x ) * Mathf.Rad2Deg );
			if (myCoolDown == 0) {
				projectile = (GameObject)Instantiate (bullet, myPos, rotation);
				myCoolDown = CoolDown;
			}
			projectile.GetComponent<Rigidbody2D>().velocity = direction * speed;
		}

	}
}
