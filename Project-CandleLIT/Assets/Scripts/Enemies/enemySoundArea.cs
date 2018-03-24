using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySoundArea : MonoBehaviour {

	AudioSource enemyParentAudio;

	// Use this for initialization
	void Start () {

		enemyParentAudio = transform.parent.gameObject.GetComponent<AudioSource>();

	}

	void Update()
	{

		Vector2.MoveTowards (transform.position,transform.parent.position,1);

	}


	void OnTriggerEnter2D(Collider2D player){

		if (player.tag == "Player") {

			enemyParentAudio.Play ();

		}
	}

	void OnTriggerExit2D(Collider2D player){

		if (player.tag == "Player") {

			enemyParentAudio.Stop ();

		}
	}
}
