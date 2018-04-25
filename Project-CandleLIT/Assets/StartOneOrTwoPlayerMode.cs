using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartOneOrTwoPlayerMode : MonoBehaviour
{

    void Update()
    {
        if (Input.GetButtonDown("Start1PlayerKeyboard") || Input.GetButtonDown("Start1PlayerArcade"))
        {
            NumPlayersChecker.setNumPlayers(1);
            SceneManager.LoadScene("Level One V2");
        }
        else if (Input.GetButtonDown("Start2PlayerKeyboard") || Input.GetButtonDown("Start2PlayerArcade"))
        {
            NumPlayersChecker.setNumPlayers(2);
            SceneManager.LoadScene("Level One V2");
        }
    }
}
