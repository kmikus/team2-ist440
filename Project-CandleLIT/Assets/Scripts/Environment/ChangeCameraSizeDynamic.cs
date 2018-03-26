using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCameraSizeDynamic : MonoBehaviour {

    public Transform player1;
    public Transform player2;
    public float baseCameraSize = 10f;
    public float scalingFactor = 0.2f;

    private Camera cam;

    private float playerDistanceX;
    private float playerDistanceY;

	// Use this for initialization
	void Start () {
        cam = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {

        playerDistanceX = Mathf.Abs(player1.position.x - player2.position.x);
        playerDistanceY = Mathf.Abs(player1.position.y - player2.position.y);
        Vector2 playerDistVector = new Vector2(playerDistanceX, playerDistanceY);
        float playerDistMagnitude = playerDistVector.magnitude;

        //Debug.Log("Player X dist: " + playerDistanceX);
        //Debug.Log("Player Y dist: " + playerDistanceY);

        //Debug.Log("Distance: " + playerDistMagnitude);
        cam.orthographicSize = baseCameraSize + scalingFactor * playerDistMagnitude;
        //Debug.Log("Camera size: " + cam.orthographicSize);

    }
}
