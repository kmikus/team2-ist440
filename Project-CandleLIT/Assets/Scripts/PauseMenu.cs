using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    public static bool GameIsPaused = false;
    public GameObject mainPanel;
    //public GameObject pauseMenuUI;
    public GameObject controlpanel;
    public GameObject volume;
    //public float timeScale = 1f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape) && mainPanel.active == false)
        {
            mainPanel.SetActive(true);
            controlpanel.SetActive(false);
            volume.SetActive(false);
            Time.timeScale = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && mainPanel.active == true)
        {
            Time.timeScale = 1;
            mainPanel.SetActive(false);
            controlpanel.SetActive(false);
            volume.SetActive(false);
        }
    }

    public void Resume()
   {
      /*  pauseMenuUI.SetActive(false);
        GameIsPaused = false;
        Time.timeScale = timeScale;
        */
        mainPanel.SetActive(false);
        controlpanel.SetActive(false);
        volume.SetActive(false);
        Time.timeScale = 1;

    }

   ///* public void Pause()
   // {
   //     pauseMenuUI.SetActive(true);
   //     Time.timeScale = 0f;
   //     GameIsPaused = true;
   // }*/

   // public void loadMenu()
   // {
   //     Application.LoadLevel("MainMenu");
   //     Time.timeScale = 1f;
   //     GameIsPaused = false;
   // }

   // public void Control()
   // {

   //     mainPanel.SetActive(false);
   //     controlpanel.SetActive(true);
   //     volume.SetActive(false);

   // }
}
