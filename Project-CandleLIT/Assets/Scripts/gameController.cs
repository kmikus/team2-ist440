using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameController : MonoBehaviour {

    public static gameController instance;
    public GameObject gameOverText;
    public bool gameOver = false;
    public Scene scene;
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
}
