using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepsAudio : MonoBehaviour {


	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		PlayStopFootSteps ();

	}

	void PlayStopFootSteps()
	{
		if (Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.RightArrow)) {

			if (!GetComponent<AudioSource> ().isPlaying)
				GetComponent<AudioSource> ().Play ();
		} 
		else 
		{
			if (GetComponent<AudioSource> ().isPlaying)
				GetComponent<AudioSource> ().Stop();
		}

	}
}
