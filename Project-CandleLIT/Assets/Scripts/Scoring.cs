using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour {

    public static float score = 0;
    public static Text scoreText;
    public string scoreTextName = "ScoreValue";
    public static float diamondPickupValue = 50f;

    public static List<string> highScores;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        scoreText = GameObject.Find(scoreTextName).GetComponent<Text>();
        updateScoreText();
        highScores = new List<string>();
        resetScore();
    }

    private void Update()
    {
        //FOR TESTING ONLY
        if (Input.GetKeyDown("i"))
        {
            Scoring.increaseScore(250);
        }
    }

    public static float getScore()
    {
        return score;
    }

    public static void increaseScore(float increaseAmount)
    {
        score += increaseAmount;
        updateScoreText();
    }

    public static void decreaseScore(float decreaseAmount)
    {
        score -= decreaseAmount;
        if (score < 0) { score = 0; }
        updateScoreText();
    }

    public static void resetScore()
    {
        score = 0;
    }

    public static void UpdateHighScore(string initials, float score)
    {
        var squishedScore = FormatScore(score) + initials;
        highScores.Add(squishedScore);
        highScores.Sort();

        if (highScores.Count > 10)
        {
            highScores.RemoveAt(0);
        }

        for (int i = highScores.Count - 1; i > -1; i--)
        {
            PlayerPrefs.SetString(i + "highscore", highScores[i]);
        }
    }

    public static void updateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = score.ToString();
        }
    }

    private static string FormatScore(float score)
    {
        var scoreStr = score.ToString();
        while (scoreStr.Length < 8)
        {
            scoreStr = "0" + scoreStr;
        }
        return scoreStr;
    }

    public static void LoadHighScores()
    {
        for (int i = 0; i < 10; i++)
        {
            if (PlayerPrefs.HasKey(i + "highscore"))
            {
                highScores.Add(PlayerPrefs.GetString(i + "highscore"));
            }
        }
        if (highScores.Count > 0)
        {
            highScores.Sort();
        }
    }

    public static void ResetHighScores()
    {
        PlayerPrefs.DeleteAll();
    }

    public static float GetLowestScore()
    {
        if (highScores.Count < 1)
        {
            throw new System.Exception("Lowest score is not available. Please make sure scores are loaded.");
        } else
        {
            return GetValueFromScore(highScores[0]);
        }
    }

    public static string GetInitialsFromScore(string highScoreStr)
    {
        return highScoreStr.Substring(8);
    }

    public static float GetValueFromScore(string highScoreStr)
    {
        return float.Parse(highScoreStr.Substring(0, 8));
    }
}
