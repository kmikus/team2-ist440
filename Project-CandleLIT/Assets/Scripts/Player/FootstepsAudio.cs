using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepsAudio : MonoBehaviour {

	public bool grounded;
	public LayerMask ground;

	AudioSource[] allSources; 

	Collider2D playerCollider;

	//public AudioSource jumpAudio;

	// Use this for initialization
	void Start () {

		allSources = GetComponents<AudioSource> ();

		playerCollider = GetComponent<Collider2D> ();



	}

	// Update is called once per frame
	void Update () {

		grounded = playerCollider.IsTouchingLayers (ground);
		PlayStopFootSteps ();
		PlayStopJump ();

	}

	void PlayStopFootSteps()
	{


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
		if ((Input.GetKey (KeyCode.Space)) && grounded) {

			if (!allSources[1].isPlaying)
				allSources[1].Play ();
			//jumpAudio.Play();
		} 
		else 
		{
			if (allSources[1].isPlaying)
				allSources[1].Stop();
		}

	}
}
