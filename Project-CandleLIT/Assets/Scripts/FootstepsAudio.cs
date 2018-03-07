using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepsAudio : MonoBehaviour {

	public float speed = 5f;
	public bool facingRight = true;
	Vector3 scale;
	// Use this for initialization
	void Start () {

		 scale = transform.localScale;

	}
	
	// Update is called once per frame
	void Update () {

		Movement ();
	}

	void Movement()
	{
		if (Input.GetKey (KeyCode.D)) {

			if (!GetComponent<AudioSource> ().isPlaying)
				GetComponent<AudioSource> ().Play ();
			
			transform.Translate (Vector2.right * speed * Time.deltaTime);

			if(!facingRight){

				scale.x *= -1;
				transform.localScale = scale;
				facingRight = !facingRight;

			}
				


		} else if (Input.GetKey (KeyCode.A)) {

			if (!GetComponent<AudioSource> ().isPlaying)
				GetComponent<AudioSource> ().Play ();

			transform.Translate (Vector2.right * -speed * Time.deltaTime);

			if (facingRight) {

				scale.x *= -1;
				transform.localScale = scale;
				facingRight = !facingRight;

			}

		} 
		else 
		{
			if (GetComponent<AudioSource> ().isPlaying)
				GetComponent<AudioSource> ().Stop();
		}

	}
}
