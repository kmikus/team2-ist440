﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinalDoor : MonoBehaviour {

    public Text DoorText;
    public int LevelToLoad;
    public GameObject gamewon;


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            DoorText.text = ("[t] to enter");

            if (Input.GetKeyDown("t"))
            {
                gamewon.SetActive(true);
            }
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            DoorText.text = ("[t] to enter");

            if (Input.GetKeyDown("t"))
            {
                gamewon.SetActive(true);
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        DoorText.text = ("");
    }

}
