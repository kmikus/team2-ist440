using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour {

	public GameObject Door;
	public bool doorIsOpening;




	// Use this for initialization
	void Start () {
		if (doorIsOpening == true) {
			Door.transform.Translate (Vector2.up * Time.deltaTime * 5);
			// if the bool is true open the door
		
		}
		if (Door.transform.position.y > 7f) {
			//if the y of the door is > 7 we want to stop the door
	
		}
	

	}

}

