using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicGun : MonoBehaviour {


    public GameObject bullet;
    public float speed;
    public float CoolDown;
	public bool gunActive = false;

    Vector3 targetDirection;
    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
	{
		if (gunActive == true) {
			Vector2 diff = GetComponentInParent<BasicShoot>().direction;
			//Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
			diff.Normalize();

			float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg + 90;
			transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
		}

    }
}
