using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class menuController : MonoBehaviour {

    public void loadLevel1()
    {
        Application.LoadLevel("Level One V2");
        Time.timeScale = 1f;
    }

    public void loadMenu()
    {
        Application.LoadLevel("HighScore");
        Time.timeScale = 1f;
    }

    public void loadSplash()
    {
        Application.LoadLevel("PSUScreen");
        Time.timeScale = 1f;
    }
}
