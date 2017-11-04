using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrosshair2 : MonoBehaviour {
    public float MAX_CROSSHAIR_DISTANCE;
    public Camera mainCamera;

    public Vector3 testMouse;
    public Vector3 testPos;
    public Vector3 testDiff;
    Vector2 crosshairDirection;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        crosshairDirection.x = Input.GetAxis("ReticalHP2");
        crosshairDirection.y = Input.GetAxis("ReticalVP2");
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
