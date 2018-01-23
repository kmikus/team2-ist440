using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRun : MonoBehaviour {

    private Rigidbody2D playerBody2d;
    private float speed = 4.0f;

	// Use this for initialization
	void Start () {
        playerBody2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKey) { this.transform.Translate(0.1f*Input.GetAxis("Horizontal"), 0, 0); }
    }
}
