using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyBookOnPlayerCollide : MonoBehaviour
{

    private BoxCollider2D bookCollider;
    private BoxCollider2D playerCollider;

    // Use this for initialization
    void Start()
    {
        bookCollider = GetComponent<BoxCollider2D>();
        playerCollider = GameObject.Find("Player").GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (bookCollider.IsTouching(playerCollider))
        {
            GameManager.scoreValue -= 1;
            Object.Destroy(this.gameObject);

            if (GameManager.scoreValue < 0)
                GameManager.scoreValue = 0;
        }

    }
}
