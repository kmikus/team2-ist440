using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour {

  
    public Text DoorText;
    public Transform TransformDestination;

  

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            DoorText.text = ("[t] to enter");

            if (Input.GetKeyDown("t"))
            {
                
                var player = GameObject.Find("CharacterRobotBoy");

                if (TransformDestination != null) {
                    var destination = TransformDestination.GetComponent<Transform>();
                    var startPosition = player.transform.position;
                    player.transform.position = destination.position;


                    var moveDelta = player.transform.position - startPosition;
                    Camera.main.transform.position += moveDelta;
                }

            }
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Input.GetKeyDown("t"))
            {

                var player = GameObject.Find("CharacterRobotBoy");

                if (TransformDestination != null)
                {
                    var destination = TransformDestination.GetComponent<Transform>();
                    var startPosition = player.transform.position;
                    player.transform.position = destination.position;


                    var moveDelta = player.transform.position - startPosition;
                    Camera.main.transform.position += moveDelta;
                }
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        DoorText.text = ("");
    }
}
