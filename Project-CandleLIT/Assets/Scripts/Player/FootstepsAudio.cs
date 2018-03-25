using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepsAudio : MonoBehaviour {

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

		if ((Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.RightArrow)) && grounded) {

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

		if ((Input.GetKeyDown(KeyCode.Space)) && grounded) {

			allSources [1].Play ();
		} 


	}


}
