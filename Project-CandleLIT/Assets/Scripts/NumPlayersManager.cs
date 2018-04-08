using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumPlayersManager : MonoBehaviour {

    public GameObject[] twoPlayerObjectsToDelete;
    public Camera mainCamera;

	// Use this for initialization
	void Start () {
        
        Debug.Log("num of players: " + NumPlayersChecker.numOfPlayers);
        if (NumPlayersChecker.numOfPlayers == 1)
        {

            // Delete all game objects specified to be 2 player only
            foreach (var gameObj in twoPlayerObjectsToDelete)
            {
                Destroy(gameObj);
            }

            // Disable the camera panning script
            if (mainCamera != null)
                mainCamera.GetComponent<ChangeCameraSizeDynamic>().enabled = false;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
