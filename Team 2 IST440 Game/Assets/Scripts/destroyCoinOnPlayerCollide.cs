using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyCoinOnPlayerCollide : MonoBehaviour {

    private BoxCollider2D coinCollider;
    private BoxCollider2D playerCollider;

	// Use this for initialization
	void Start () {
        coinCollider = GetComponent<BoxCollider2D>();
        playerCollider = GameObject.Find("Player").GetComponent<BoxCollider2D>();
    }
	
	// Update is called once per frame
	void Update () {
        
        if (coinCollider.IsTouching(playerCollider))
        {
            GameManager.scoreValue += 1;
            Object.Destroy(this.gameObject);
     
        }
	}
}
