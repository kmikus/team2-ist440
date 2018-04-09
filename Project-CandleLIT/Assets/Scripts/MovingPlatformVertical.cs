using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformVertical : MonoBehaviour {

    public float delta = 1.5f;
    public float speed = 2.0f;
    private Vector3 startPos;

    // Use this for initialization
    void Start () {

        startPos = transform.position;
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        Vector3 v = startPos;
        v.y += delta * Mathf.Sin(Time.time * speed);
        transform.position = v;
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
        if (collision.gameObject.tag == "Player") {
            collision.transform.SetParent(transform);
        }
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
        if (collision.gameObject.tag == "Player") {
            collision.transform.parent = null;
        }
	}
}
