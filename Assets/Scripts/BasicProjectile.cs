using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicProjectile : MonoBehaviour {

    public Vector2 velocity;
    public float MAX_TTL;
    public float remainingTTL;
    public float projectileSpeed;

	// Use this for initialization
	void Start () {
        remainingTTL = MAX_TTL;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        remainingTTL--;
        Vector2 dx = velocity * projectileSpeed * Time.deltaTime;
        transform.Translate(dx.x, dx.y, 0);

        if(remainingTTL < 0)
        {
            Destroy(gameObject);
        }
	}
}
