using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectDiamond : MonoBehaviour {

	AudioSource DiamondAudio;

	// Use this for initialization
	void Start () {

		DiamondAudio = GetComponent<AudioSource> ();

	}




	public void playDiamondCollect()
	{
		DiamondAudio.Play ();

	}

}
