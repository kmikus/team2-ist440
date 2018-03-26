using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderStop : MonoBehaviour {

    public GameObject spider;
    private Rigidbody2D spiderBody2d;
    private SpiderState spiderState;
	// Use this for initialization
	void Start () {
        spiderBody2d = spider.GetComponent<Rigidbody2D>();
        spiderState = GetComponentInParent<SpiderState>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject == spider)
        {
            spiderBody2d.velocity = new Vector2(0, 5);
            spiderState.Attacking = false;
            spiderState.Retracting = true;
        }
    }
}
