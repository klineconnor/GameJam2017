using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public int playerNumber;
    public float speed;
	Rigidbody2D rb;


	public Vector3 outputMovement;
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
}
