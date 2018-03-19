using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreInputManager : MonoBehaviour {

    public int currentInitial = 1;
    private Text initial1;
    private Text initial2;
    private Text initial3;

	// Use this for initialization
	void Start () {
        initial1 = GameObject.Find("InputInit1").GetComponent<Text>();
        initial2 = GameObject.Find("InputInit2").GetComponent<Text>();
        initial3 = GameObject.Find("InputInit3").GetComponent<Text>();

        Scoring.LoadHighScores();

        if (Scoring.highScores.Count > 0)
        {
            GameObject.Find("InitialsTest").GetComponent<Text>().text = Scoring.highScores[Scoring.highScores.Count - 1];
        }

        int sizeOfHighScores = Scoring.highScores.Count;

        for (int i = 1; i <= sizeOfHighScores; i++)
        {
            var initials1 = GameObject.Find("Initials" + i).GetComponent<Text>();
            var initial1 = GameObject.Find("Initial" + i).GetComponent<Text>();
            initials1.text = Scoring.highScores[sizeOfHighScores - i].Substring(8);
            initial1.text = Scoring.highScores[sizeOfHighScores - i].Substring(0, 8);
        }


    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Return))
        {
            string initials = initial1.text.ToCharArray()[0].ToString() + initial2.text.ToCharArray()[0].ToString() + initial3.text.ToCharArray()[0].ToString();
            Scoring.UpdateHighScore(initials, Scoring.score);
            Scoring.resetScore();
        }

		if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentInitial++;
            if(currentInitial == 4)
            {
                currentInitial = 1;
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentInitial--;
            if(currentInitial == 0)
            {
                currentInitial = 3;
            }
        }

        if (currentInitial == 1)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                var currentLetter = initial1.text;
                int asciiNum = System.Convert.ToInt32(currentLetter.ToCharArray()[0]);
                //Debug.Log(asciiNum);
                asciiNum++;
                if (asciiNum > 90)
                {
                    asciiNum = 65;
                }
                //Debug.Log(asciiNum);
                initial1.text = System.Convert.ToChar(asciiNum).ToString();
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                var currentLetter = initial1.text;
                int asciiNum = System.Convert.ToInt32(currentLetter.ToCharArray()[0]);
                //Debug.Log(asciiNum);
                asciiNum--;
                if (asciiNum < 65)
                {
                    asciiNum = 90;
                }
                //Debug.Log(asciiNum);
                initial1.text = System.Convert.ToChar(asciiNum).ToString();
            }
        }
        else if (currentInitial == 2)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                var currentLetter = initial2.text;
                int asciiNum = System.Convert.ToInt32(currentLetter.ToCharArray()[0]);
                //Debug.Log(asciiNum);
                asciiNum++;
                if (asciiNum > 90)
                {
                    asciiNum = 65;
                }
                //Debug.Log(asciiNum);
                initial2.text = System.Convert.ToChar(asciiNum).ToString();
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                var currentLetter = initial2.text;
                int asciiNum = System.Convert.ToInt32(currentLetter.ToCharArray()[0]);
                //Debug.Log(asciiNum);
                asciiNum--;
                if (asciiNum < 65)
                {
                    asciiNum = 90;
                }
                //Debug.Log(asciiNum);
                initial2.text = System.Convert.ToChar(asciiNum).ToString();
            }
        }
        else if (currentInitial == 3)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                var currentLetter = initial3.text;
                int asciiNum = System.Convert.ToInt32(currentLetter.ToCharArray()[0]);
                //Debug.Log(asciiNum);
                asciiNum++;
                if (asciiNum > 90)
                {
                    asciiNum = 65;
                }
                //Debug.Log(asciiNum);
                initial3.text = System.Convert.ToChar(asciiNum).ToString();
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                var currentLetter = initial3.text;
                int asciiNum = System.Convert.ToInt32(currentLetter.ToCharArray()[0]);
                //Debug.Log(asciiNum);
                asciiNum--;
                if (asciiNum < 65)
                {
                    asciiNum = 90;
                }
                //Debug.Log(asciiNum);
                initial3.text = System.Convert.ToChar(asciiNum).ToString();
            }
        }
	}
}
