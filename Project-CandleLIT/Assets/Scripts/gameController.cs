using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameController : MonoBehaviour {

    public static gameController instance;
    public GameObject player1;
    public GameObject player2;
    public GameObject gameover;
    public bool gameOver = false;
    public Scene scene;

    public Text gameoverText;
    public Button restar1t;
    public PlayerHealth ph1;
    public PlayerHealth ph2;

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
        if(ph1 != null && ph1.CurrentHealth <= 0)
        {
            player1.SetActive(false);
            gameover.SetActive(true);
            gameoverText.text = ("Player Two Wins!");
        }

        if(ph2 != null && ph2.CurrentHealth <= 0)
        {
            player2.SetActive(false);
            gameover.SetActive(true);
            gameoverText.text = ("Player One Wins!");
        }
	}

    public void EndGame()
    {
        gameover.SetActive(true);
        gameOver = true;
     
    }

    public void restart()
    {
        Application.LoadLevel("Versus Mode");
        gameover.SetActive(false);
        Time.timeScale = 1f;
    }

}
