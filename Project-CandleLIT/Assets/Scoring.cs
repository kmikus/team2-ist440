﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour {

    private static float score = 0;
    public static Text scoreText;
    public string scoreTextName = "ScoreValue";

    private void Start()
    {
        scoreText = GameObject.Find(scoreTextName).GetComponent<Text>();
        scoreText.text = score.ToString();
    }

    public static float getScore()
    {
        return score;
    }

    public static void increaseScore(float increaseAmount)
    {
        score += increaseAmount;
        scoreText.text = score.ToString();
    }

    public static void decreaseScore(float decreaseAmount)
    {
        score -= decreaseAmount;
        if (score < 0) { score = 0; }
        scoreText.text = score.ToString();
    }

    public static void resetScore()
    {
        score = 0;
    }
}