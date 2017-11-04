using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public int playerNumber;
    public float speed;
	Rigidbody2D rb;
	public EntityManager em;


	public Vector3 outputMovement;



	private bool shuttingDown = false;
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
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
