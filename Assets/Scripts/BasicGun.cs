using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicGun : MonoBehaviour {
    public GameObject projectile;
    public bool fired;
    public Vector2 fireDir;
    public float MAX_REFIRE_TIME;
    public float refireTime;
    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        diff.Normalize();
        fireDir = new Vector2(diff.x, diff.y);
        fireDir.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);

        if (!fired)
        {
            if (Input.GetButton("Fire1"))
            {
                fired = true;
                GameObject temp = Instantiate(projectile, transform.position, Quaternion.identity);
                temp.GetComponent<BasicProjectile>().velocity = new Vector2(fireDir.x, fireDir.y);
                temp.tag = "p" + GetComponentInParent<PlayerController>().playerNum.ToString();
                refireTime = MAX_REFIRE_TIME;
            }            
        }
        else
        {
            if (refireTime < 0)
            {
                fired = false;
            }
            refireTime--;
        }
    }
}
