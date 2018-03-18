using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddScore : MonoBehaviour {

    private Button button;
	// Use this for initialization
	void Start () {
        button = GetComponent<Button>();
        button.onClick.AddListener(AddPlayerScore);
	}

    private void AddPlayerScore()
    {
        Scoring.AddNewScore(Scoring.score);
        Scoring.resetScore();
    }

    // Update is called once per frame
    void Update () {
		
	}

}
