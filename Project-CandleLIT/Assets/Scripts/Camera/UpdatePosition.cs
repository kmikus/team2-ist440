using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdatePosition : MonoBehaviour {

    public Transform player1;
    public Transform player2;

    private Transform currentPosition;
    private float newX;
    private float newY;

	// Use this for initialization
	void Start () {
        currentPosition = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        
        if (NumPlayersChecker.numOfPlayers == 2) {
            newX = (player1.position.x + player2.position.x) / 2;
            newY = (player1.position.y + player2.position.y) / 2;

            currentPosition.position = new Vector3(newX, newY, currentPosition.position.z);
        } else {
            currentPosition.position = player1.position;
        }

    }
}
