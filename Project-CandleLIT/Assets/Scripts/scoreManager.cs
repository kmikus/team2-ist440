using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreManager : MonoBehaviour
{

    public static int score;
    public Text scoreText;
    // Use this for initialization
    void Start()
    {
        score = 0;
        UpdateScore();

    }

    public void AddScore(int newScoreValue)
    {
        score = newScoreValue;
        UpdateScore();
    }

    // Update is called once per frame
    void UpdateScore()
    {
        scoreText.text = "SCORE: " + score;

    }
}
