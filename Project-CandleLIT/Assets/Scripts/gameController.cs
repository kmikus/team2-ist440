using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameController : MonoBehaviour {

    public static gameController instance;
    public GameObject gameover;
    public bool gameOver = false;
    public Scene scene;

    //public InputField playerName;
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
        gameover.SetActive(true);
        gameOver = true;

        //Time.timeScale = 0f;
        
    }

    //public void InitialsEntered()
    //{
    //    GetComponent<inputfield>().CheckForHighScore(Scoring.score, playerName.text);
    //}

}
