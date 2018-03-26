using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDoorLocation : MonoBehaviour {

    public GameObject door;

    private Transform[] doorLocations;

	// Use this for initialization
	void Start () {
        doorLocations = GetComponentsInChildren<Transform>();

        if (doorLocations.Length > 1)
        {
            door.transform.position = doorLocations[Random.Range(1, doorLocations.Length)].position;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
