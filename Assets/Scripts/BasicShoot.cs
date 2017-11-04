using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicShoot : MonoBehaviour {

	public GameObject Reticle;
	public GameObject bullet;
	public float speed;
	public float CoolDown;
	public Vector2 direction;

	private float myCoolDown;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (myCoolDown > 0) {
			myCoolDown--;
		}

		Vector2 target = Reticle.transform.position;
		Vector2 myPos = new Vector2(transform.position.x,transform.position.y);
		direction = target - myPos;
		direction.Normalize();

		if (Input.GetAxis("FireP" + GetComponent<PlayerController>().playerNumber)>0) {
			//print ("Try Fire");

			Quaternion rotation = Quaternion.Euler( 0, 0, Mathf.Atan2 ( direction.y, direction.x ) * Mathf.Rad2Deg );
			if (myCoolDown == 0) {
				GameObject projectile = (GameObject)Instantiate (bullet, myPos, rotation);
				myCoolDown = CoolDown;
				projectile.GetComponent<Rigidbody2D>().velocity = direction * speed;
				projectile.tag = "p" + GetComponent<PlayerController>().playerNumber;
			}
		}
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if ((collision.gameObject.tag == "Pickup") && (Input.GetAxis("Pickup" + GetComponent<PlayerController>().playerNumber) > 0))
        {
            PickupNewGun(gameObject.GetComponent<Pickup>().gun);
        }
    }
    void PickupNewGun(GameObject gun)
    {
        BasicGun gunData = gun.GetComponent<BasicGun>();
        bullet = gunData.bullet;
        speed = gunData.speed;
        CoolDown = gunData.CoolDown;
        GameObject temp = Instantiate(gun, transform.position, Quaternion.identity);
        temp.transform.parent = gameObject.transform;
    }
}
