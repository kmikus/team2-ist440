using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCameraSizeDynamic : MonoBehaviour {

    public Transform player1;
    public Transform player2;
    public float shiftThreshold = 0.7f;
    public float sizeIncrease = 1.25f;

    private Camera cam;
    private float camHeight;
    private float camWidth;

    private float playerDistanceX;
    private float playerDistanceY;

	// Use this for initialization
	void Start () {
        cam = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
        camHeight = cam.orthographicSize * 2;
        camWidth = cam.orthographicSize * 2 * cam.aspect;

        Debug.Log("Height: " + camHeight);
        Debug.Log("Width: " + camWidth);

        playerDistanceX = Mathf.Abs(player1.position.x - player2.position.x);
        playerDistanceY = Mathf.Abs(player1.position.y - player2.position.y);

        Debug.Log("Player X dist: " + playerDistanceX);
        Debug.Log("Player Y dist: " + playerDistanceY);

        if (playerDistanceX > shiftThreshold * camWidth)
        {
            cam.orthographicSize *= sizeIncrease;
        } else if (playerDistanceY > shiftThreshold * camHeight)
        {
            cam.orthographicSize *= sizeIncrease;
        }

    }
}
