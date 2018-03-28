using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.EventSystems;

public class HighScoreInputManager : MonoBehaviour {

    public int currentInitial = 1;
    public Text initial1;
    public Text initial2;
    public Text initial3;
    //public EventSystem eventSystem;
    public Button mainMenuButton;

    private bool isScoreSubmitted = false;
    private bool newHighScore = true;
    private bool inputActionHappened = false;
    private float t = 0f;
    public float inputDelay = 0.2f;
    public Text labelForInitials;

    // Use this for initialization
    void Start () {

        Scoring.LoadHighScores();
        UpdateHighScoreUI();

        // If the current score doesn't beat the high scores disable ability to submit a new high score
        if (Scoring.getScore() < Scoring.GetLowestScore() && Scoring.highScores.Count > 10)
        {
            newHighScore = false;
            initial1.gameObject.SetActive(false);
            initial2.gameObject.SetActive(false);
            initial3.gameObject.SetActive(false);
            labelForInitials.gameObject.SetActive(false);
            mainMenuButton.Select();
        }

    }
	
	// Update is called once per frame
	void Update () {

        if (inputActionHappened)
        {
            t += Time.deltaTime;
        }

        if (t > inputDelay)
        {
            inputActionHappened = false;
            t = 0f;
        }

        if (Input.GetButtonDown("Submit"))
        {
            SubmitHighScore();
        }

		if (Input.GetAxisRaw("Horizontal") > 0 && !inputActionHappened)
        {
            inputActionHappened = true;
            currentInitial++;
            if(currentInitial == 4)
            {
                currentInitial = 1;
            }
        }

        if (Input.GetAxisRaw("Horizontal") < 0 && !inputActionHappened)
        {
            inputActionHappened = true;
            currentInitial--;
            if(currentInitial == 0)
            {
                currentInitial = 3;
            }
        }

        if (currentInitial == 1)
        {
            if (Input.GetAxisRaw("Vertical") > 0 && !inputActionHappened)
            {
                inputActionHappened = true;
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

            if (Input.GetAxisRaw("Vertical") < 0 && !inputActionHappened)
            {
                inputActionHappened = true;
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
            if (Input.GetAxisRaw("Vertical") > 0 && !inputActionHappened)
            {
                inputActionHappened = true;
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

            if (Input.GetAxisRaw("Vertical") < 0 && !inputActionHappened)
            {
                inputActionHappened = true;
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
            if (Input.GetAxisRaw("Vertical") > 0 && !inputActionHappened)
            {
                inputActionHappened = true;
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

            if (Input.GetAxisRaw("Vertical") < 0 && !inputActionHappened)
            {
                inputActionHappened = true;
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

    private void UpdateHighScoreUI()
    {
        int sizeOfHighScores = Scoring.highScores.Count;

        for (int i = 1; i <= sizeOfHighScores; i++)
        {
            var initials1 = GameObject.Find("Initials" + i).GetComponent<Text>();
            var initial1 = GameObject.Find("Initial" + i).GetComponent<Text>();
            initials1.text = Scoring.highScores[sizeOfHighScores - i].Substring(8);
            initial1.text = Scoring.highScores[sizeOfHighScores - i].Substring(0, 8);
        }
    }

    private void SubmitHighScore()
    {
        if (!isScoreSubmitted && newHighScore)
        {
            string initials = initial1.text.ToCharArray()[0].ToString() + initial2.text.ToCharArray()[0].ToString() + initial3.text.ToCharArray()[0].ToString();
            Scoring.UpdateHighScore(initials, Scoring.score);
            Scoring.resetScore();
            UpdateHighScoreUI();
            isScoreSubmitted = true;

            initial1.gameObject.SetActive(false);
            initial2.gameObject.SetActive(false);
            initial3.gameObject.SetActive(false);
            labelForInitials.gameObject.SetActive(false);

            mainMenuButton.Select();
        }
    }
}
