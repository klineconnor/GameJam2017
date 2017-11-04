using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrosshair : MonoBehaviour {
    public float MAX_CROSSHAIR_DISTANCE;
    public Camera mainCamera;

    public Vector3 testMouse;
    public Vector3 testPos;
    public Vector3 testDiff;
    Vector2 crosshairDirection;
	int playerNumber;
	// Use this for initialization
	void Start () {
		playerNumber = GetComponentInParent<PlayerController>().playerNumber;
	}
	
	// Update is called once per frame
	void Update () {
		crosshairDirection.x = Input.GetAxis("ReticalHP" + playerNumber);
		crosshairDirection.y = Input.GetAxis("ReticalVP" + playerNumber);
        //Vector3 mousePos = Input.mousePosition;
        //crosshairDirection = mainCamera.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, mainCamera.nearClipPlane));
        //crosshairDirection = crosshairDirection - new Vector2(transform.position.x, transform.position.y);
        Vector3 temp = transform.parent.position;
        //testPos = temp;
        //testMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //crosshairDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - temp;
        //testDiff = crosshairDirection;
        crosshairDirection = crosshairDirection.normalized * MAX_CROSSHAIR_DISTANCE;
        gameObject.transform.localPosition = crosshairDirection;
    }
}
