using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameController : MonoBehaviour {

    public static gameController instance;
    public GameObject gameOverText;
    public bool gameOver = false;
    public Scene scene;
    public InputField highScoreInput;
	// Use this for initialization
	void Awake () {
		if(instance == null)
        {
            instance = this;
        }else if(instance != this)
        {
            Destroy(gameObject);
        }
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void EndGame()
    {
        gameOverText.SetActive(true);
        gameOver = true;

    }

    public void HighScoreInput()
    {
        string newInput = highScoreInput.text;
        PlayerPrefs.SetString("highscoreName", newInput);
        PlayerPrefs.SetInt("highscore", scoreManager.score);
    }
}
