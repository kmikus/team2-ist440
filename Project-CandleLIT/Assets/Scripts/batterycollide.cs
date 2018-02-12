using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class batterycollide : MonoBehaviour {

    private BoxCollider2D batteryCollider;
    private BoxCollider2D playerCollider;

    private float Energy;




    // Use this for initialization
    void Start()
    {
        batteryCollider = GetComponent<BoxCollider2D>();
        playerCollider = GameObject.Find("Player").GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (batteryCollider.IsTouching(playerCollider))
        {
            Energy += 10;
            Object.Destroy(this.gameObject);
        }

    }
}
