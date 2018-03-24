using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Audio : MonoBehaviour {

	public bool grounded;
	public LayerMask ground;

	AudioSource[] allSources; 

	Collider2D playerCollider;

	int check = 0;

	// Use this for initialization
	void Start () {

		allSources = GetComponents<AudioSource> ();

		playerCollider = GetComponent<Collider2D> ();



	}

	// Update is called once per frame
	void Update () {


		PlayStopFootSteps ();
		PlayStopJump ();


	}

	void PlayStopFootSteps()
	{
		grounded = playerCollider.IsTouchingLayers (ground);

		if ((Input.GetKey (KeyCode.C) || Input.GetKey (KeyCode.V)) && grounded) {

			if (!allSources[0].isPlaying)
				allSources[0].Play ();
		} 
		else 
		{
			if (allSources[0].isPlaying)
				allSources[0].Stop();
		}

	}

	void PlayStopJump()
	{
		grounded = playerCollider.IsTouchingLayers (ground);

		if ((Input.GetKeyDown(KeyCode.J)) && grounded) {

			allSources [1].Play ();
		} 


	}


}

