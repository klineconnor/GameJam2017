﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour {

    public float speed;

    


    private void Update()
    {
        float moveHorizontal = Input.GetAxis("HorizontalP1");
        float moveVertical = Input.GetAxis("VerticalP1");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
		transform.Translate(movement * speed * Time.deltaTime);
    }
}
