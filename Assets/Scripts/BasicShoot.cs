using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicShoot : MonoBehaviour {

	public GameObject Reticle;
	public GameObject bullet;
	public float speed;
	public float CoolDown;
	public Vector2 direction;
    public int playerNumber;
	private float myCoolDown;

    private float MAX_PITCH;
    private float MIN_PITCH;
    public float currentPitch;

    private int PITCH_CYCLE_MAX;
    public int currentPitchCycle;
    private int pitchChangeDir;

	private AudioSource AS;
	// Use this for initialization
	void Start () {
        playerNumber = gameObject.GetComponent<PlayerController>().playerNumber;
		AS = GetComponent<AudioSource>();
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

		if (Input.GetAxis("FireP" + playerNumber)>0) {
			//print ("Try Fire " + playerNumber);

			Quaternion rotation = Quaternion.Euler( 0, 0, Mathf.Atan2 ( direction.y, direction.x ) * Mathf.Rad2Deg );

			if (myCoolDown == 0) {
				GameObject projectile = (GameObject)Instantiate (bullet, myPos, rotation);
				AS.Play ();
                ProcessPitch();
				myCoolDown = CoolDown;
				projectile.GetComponent<Rigidbody2D>().velocity = direction * speed;
				projectile.tag = "p" + playerNumber;
			}
		}
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
		if ((collision.gameObject.tag == "Pickup"))
		{
			
			//print ("Pickuponly " );
			//print (Input.GetButton ("PickupP" + GetComponent<PlayerController>().playerNumber));
		}
		if ((collision.gameObject.tag == "Pickup"))//&& (Input.GetAxis("PickupP" + GetComponent<PlayerController>().playerNumber) > 0))
        {
			PickupNewGun(collision.gameObject.GetComponent<Pickup>().guns[collision.gameObject.GetComponent<Pickup>().gunIndex]);
			collision.gameObject.GetComponent<Pickup>().PickupGrabbed();
            Destroy(collision.gameObject.GetComponent<Pickup>().gunInstance);
			//print ("Pickup");
        }
    }
    void PickupNewGun(GameObject gun)
    {
        BasicGun gunData = gun.GetComponent<BasicGun>();
        bullet = gunData.bullet;
        speed = gunData.speed;
        CoolDown = gunData.CoolDown;
        MAX_PITCH = gunData.maxPitch;
        MIN_PITCH = gunData.minPitch;
        PITCH_CYCLE_MAX = gunData.pitchCycleSize;
        pitchChangeDir = gunData.pitchChangeDir;
		AS.clip = gunData.bullet.GetComponent<BulletDespawn>().AC;
        currentPitch = MAX_PITCH;
        GameObject temp = Instantiate(gun, transform.position, Quaternion.identity);
        temp.transform.parent = gameObject.transform;
		temp.GetComponent<BasicGun> ().gunActive = true;
    }

    void ProcessPitch()
    {
        if((currentPitchCycle <= 0)&&(pitchChangeDir < 0))
        {
            currentPitchCycle = PITCH_CYCLE_MAX;
        }
        else if ((currentPitchCycle >= PITCH_CYCLE_MAX) && (pitchChangeDir > 0))
        {
            currentPitchCycle = 0;
        }
        currentPitch = ((MAX_PITCH - MIN_PITCH) * ((float) currentPitchCycle / (float) PITCH_CYCLE_MAX)) + MIN_PITCH;
        AS.pitch = currentPitch;
        currentPitchCycle += pitchChangeDir;
    }
}
