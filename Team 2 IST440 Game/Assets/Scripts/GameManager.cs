using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour {

    // For Score
    public static int scoreValue = 0;
    Text score;

    // For Timer
    public Text countdownTime;
    private float timeElapsed = 60f;

    // Use this for initialization
    void Start() {
        score = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update() {

        score.text = "SCORE: $" + scoreValue;

        timeElapsed -= Time.deltaTime;
        countdownTime.text = "TIME: " + FormatTime(timeElapsed);
    }

    void ResetGame()
    {
        timeElapsed = 0;
    }

    string FormatTime (float value)
    {
        TimeSpan t = TimeSpan.FromSeconds(value);
        return string.Format("{0:D2}:{1:D2}", t.Minutes, t.Seconds);
    }
}

    

