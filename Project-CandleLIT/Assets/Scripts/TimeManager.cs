using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;


public class TimeManager : MonoBehaviour
{


    // For Timer
    private Text countdownTime;
    private float timeElapsed;
    public GameObject gameover;
    public bool gameOver = false;
    public float defaultLevelTime = 120f;

    // This adds an additional 5 seconds after time runs out until it switches to the next scene
    // During this 5 seconds the player should not be able to move and the Spawner should stop
    // It is just so the transition is more smooth so it does not abrupty switch to the next scene
    // private float timeOnGame = 0f;

    // Use this for initialization
    void Start()
    {
        countdownTime = GetComponent<Text>();
        var levelTimer = GameObject.Find("LevelTimer");
        if (levelTimer != null)
        {
            timeElapsed = levelTimer.GetComponent<LevelTimer>().amountOfTime;
        } else
        {
            timeElapsed = defaultLevelTime;
        }
    }

    // Update is called once per frame
    void Update()
    {

        //timeOnGame -= Time.deltaTime;

        timeElapsed -= Time.deltaTime;
        countdownTime.text = "TIME: " + FormatTime(value: timeElapsed);

        if (timeElapsed <= 0)
        {
            countdownTime.text = "TIME: 00:00";

            gameController.instance.EndGame();
            gameover.SetActive(true);
            gameOver = true;

        }
    }

    string FormatTime(float value)
    {
        TimeSpan t = TimeSpan.FromSeconds(value);
        return string.Format("{0:D2}:{1:D2}", t.Minutes, t.Seconds);
    }
    
    public void ResetTime()
    {
        timeElapsed = defaultLevelTime;
    }

    public void UpdateTime(float newTime)
    {
        timeElapsed = newTime;
    }

}
