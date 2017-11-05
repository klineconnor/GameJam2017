using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public int playerNumber;
    public float speed;
	Rigidbody2D rb;
	public EntityManager em;
    public float health;

    public ScoreManager SM;
	public Vector3 outputMovement;



	private bool shuttingDown = false;
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
        SM = em.gameObject.GetComponent<ScoreManager>();

        SM.UpdateHealth(playerNumber, health);
    }

    /*private void FixedUpdate()
    {
		float moveHorizontal = Input.GetAxis("HorizontalP" + playerNumber);
		float moveVertical = Input.GetAxis("VerticalP" + playerNumber);
        Vector3 movement = new Vector3(moveHorizontal, moveVertical);
		rb.AddForce(movement * speed * Time.deltaTime, ForceMode2D.Impulse);
    }*/
	private void Update()
	{
		float moveHorizontal = Input.GetAxis("HorizontalP" + playerNumber);
		float moveVertical = Input.GetAxis("VerticalP" + playerNumber);
		Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0);
		outputMovement = movement;
		rb.MovePosition (transform.position + (movement * speed * Time.deltaTime));
		//transform.Translate(movement * speed * Time.deltaTime); 	}

	void OnTriggerEnter2D(Collider2D other) {
		//print (other.gameObject.tag);
		if ((other.gameObject.tag != ("p"+ playerNumber)) && other.GetComponent<BulletDespawn>()) {
			HitDamage(other.GetComponent<BulletDespawn>().damage, other.GetComponent<BulletDespawn>().playerNumber);
		}
	}

	void OnCollisionEnter2D(Collision2D coll){
		//print (other.gameObject.tag);
		if ((coll.gameObject.tag != ("p"+ playerNumber)) && coll.gameObject.GetComponent<BulletDespawn>()) {
			HitDamage(coll.gameObject.GetComponent<BulletDespawn>().damage, coll.gameObject.GetComponent<BulletDespawn>().playerNumber);
		}
	}

    void HitDamage(float damage, int enemyNum) {
        health -= damage;
        SM.UpdateHealth(playerNumber, health);
        if (health < 0)
        {
            SM.UpdateScore(enemyNum, 1);
            Destroy(gameObject);
        }
    }

    void OnApplicationQuit()
	{
		shuttingDown = true;
	}

	void OnDestroy() {
		if (!shuttingDown) {
			em.RespawnEntity (this.gameObject);
		}
	}
}
