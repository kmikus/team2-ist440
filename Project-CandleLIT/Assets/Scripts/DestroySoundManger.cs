using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySoundManger : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (GameObject.Find("SoundManager") != null)
        {
            var soundManager = GameObject.Find("SoundManager");
            Destroy(soundManager);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
