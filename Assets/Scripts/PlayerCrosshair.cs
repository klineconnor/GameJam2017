using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrosshair : MonoBehaviour {
    public float MAX_CROSSHAIR_DISTANCE;
    public Camera mainCamera;


    Vector2 crosshairDirection;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //crosshairDirection.x = Input.GetAxis("Horizontal");
        //crosshairDirection.y = Input.GetAxis("Vertical");
        Vector3 mousePos = Input.mousePosition;
        crosshairDirection = mainCamera.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, mainCamera.nearClipPlane));
        crosshairDirection = crosshairDirection - new Vector2(transform.position.x, transform.position.y);
        crosshairDirection = crosshairDirection.normalized * MAX_CROSSHAIR_DISTANCE;
        gameObject.transform.localPosition = crosshairDirection;




    }
}
