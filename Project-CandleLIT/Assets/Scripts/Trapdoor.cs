using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trapdoor : MonoBehaviour {

    public SpriteRenderer thisSpriteRenderer;
    public BoxCollider2D thisBoxCollider;
    public bool trapdoorOpen = false;
    public Sprite openSprite;
    public Sprite closedSprite;

	// Use this for initialization
	void Start () {

        thisSpriteRenderer = GetComponent<SpriteRenderer>();
        thisBoxCollider = GetComponent<BoxCollider2D>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (trapdoorOpen == false)
        {
            thisSpriteRenderer.sprite = openSprite;
            trapdoorOpen = true;
            thisBoxCollider.isTrigger = true;
        }
        else if (trapdoorOpen == true)
        {
            thisSpriteRenderer.sprite = closedSprite;
            trapdoorOpen = false;
            thisBoxCollider.isTrigger = false;
        }
    }
}
