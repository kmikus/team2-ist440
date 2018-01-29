using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRun : MonoBehaviour {

    private Rigidbody2D playerBody2d;
    public float speed = 0.1f;

	// Use this for initialization
	void Start () {
        playerBody2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKey) {
            this.transform.Translate(0.02f*speed*Input.GetAxis("Horizontal"), 0, 0);
        }
    }
}
