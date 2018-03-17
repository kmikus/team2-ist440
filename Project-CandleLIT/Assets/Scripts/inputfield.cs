using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inputfield : MonoBehaviour {

     public InputField Gname;
     public Text fText;

     public void setget()
     {
         fText.text = "1. Name: " + Gname.text + " Score: " + Scoring.score;
     }

    /*public Text[] highScores;

    int[] highScoreValue;
    string[] highScoreNames;

    void Start()
    {
        highScoreValue = new int[highScores.Length];
        highScoreNames = new string[highScores.Length];
        for (int x = 0; x < highScores.Length; x++)
        {
            highScoreValue[x] = PlayerPrefs.GetInt("highScoreValues" + x);
            highScoreNames[x] = PlayerPrefs.GetString("highScoreValues" + x);
        }
        DrawScores();
    }

    void SaveScores()
    {
        for (int x = 0; x < highScores.Length; x++)
        {
            PlayerPrefs.SetInt("highScoreValues" + x, highScoreValue [x]);
            PlayerPrefs.SetString("highScoreNames" + x, highScoreNames[x]);
        }
    }

    public void CheckForHighScore(int _value, string _userName)
    {
        for (int x =0; x < highScores.Length; x++)
        {
            if(_value > highScoreValue[x])
            {
                for(int y = highScores.Length - 1; y > x; y--)
                {
                    highScoreValue[y] = highScoreValue[y - 1];
                    highScoreNames[y] = highScoreNames[y - 1];
                }
                highScoreValue[x] = _value;
                highScoreNames[x] = _userName;
                DrawScores();
                SaveScores();
                break;

            }
        }
    }

    void DrawScores()
    {
        for (int x = 0; x < highScores.Length; x++)
        {
            highScores [x].text = highScoreValue [x].ToString();
        }
    }

    void update()
    {

    }*/
}
