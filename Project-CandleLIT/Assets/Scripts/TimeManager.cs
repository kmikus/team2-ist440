using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;


public class TimeManager : MonoBehaviour
{

    // For Score
    //public static int scoreValue = 0;
    //Text score;

    // For Timer
    public Text countdownTime;
    private float timeElapsed = 180f;

    // This adds an additional 5 seconds after time runs out until it switches to the next scene
    // During this 5 seconds the player should not be able to move and the Spawner should stop
    // It is just so the transition is more smooth so it does not abrupty switch to the next scene
    private float timeOnGame = 65f;
    public bool pauseTimer = false;

    // Use this for initialization
    void Start()
    {
        //score = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

        //score.text = "SCORE: $" + scoreValue;

        timeOnGame -= Time.deltaTime;

        timeElapsed -= Time.deltaTime;
        countdownTime.text = "TIME: " + FormatTime(value: timeElapsed);

        if (timeElapsed <= 0)
        {
            countdownTime.text = "TIME: 00:00";

            // Load next Scene after 5 seconds of game/round/level ending
            /*if (timeOnGame <= 0)
            {
                // Currently will load a high score scene
                // When more levels/rounds are added, update Build Settings to go to next appropriate Scene
                SceneManager.LoadScene("HighScore");

            }*/
        }

        //if (timeElapsed > 0)
        //{

        //        scoreManager.score += 10;
        //}



        if (Input.GetKeyDown(KeyCode.P))
        {
            pauseTimer = true;
        }
    }

    string FormatTime(float value)
    {
        TimeSpan t = TimeSpan.FromSeconds(value);
        return string.Format("{0:D2}:{1:D2}", t.Minutes, t.Seconds);
    }

}
