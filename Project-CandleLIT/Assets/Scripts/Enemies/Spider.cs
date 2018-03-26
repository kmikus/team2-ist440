using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : MonoBehaviour {

    private Rigidbody2D spiderBody;

    public float newGravityScale = 0.5f;

	// Use this for initialization
	void Start () {
        spiderBody = GetComponentInParent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            spiderBody.AddForce(new Vector2(0, -5f));
        }
    }
}
