using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayGameOverSound : MonoBehaviour {

    private SoundEffects sfx;
	// Use this for initialization
	void Start () {
        sfx = SoundManager.instance.GetComponent<SoundEffects>();
        SoundManager.instance.PlaySingle2(sfx.gameOver);
	}
}
