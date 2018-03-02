﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemies : MonoBehaviour {

    public float horizontalSpeed;
    public float verticalSpeed;
    public float amplitude;

    public Vector3 tempPosition;


	// Use this for initialization
	void Start () {
        tempPosition = transform.position;
		
	}
	
	// Update is called once per frame
	void Update () {

        tempPosition.x += horizontalSpeed;
        tempPosition.y = Mathf.Sin(Time.realtimeSinceStartup * verticalSpeed) * amplitude;
        transform.position = tempPosition;
		
	}
}
