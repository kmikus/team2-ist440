using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour {

  
    public Text DoorText;
    public Transform TransformDestination;
    public Transform cameraTransform;


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

                    var cameraDestination = cameraTransform.GetComponent<Transform>();
                    var camStartPosition = Camera.main.transform.position;
                    Camera.main.transform.position = cameraDestination.position;
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

                    var cameraDestination = cameraTransform.GetComponent<Transform>();
                    var camStartPosition = Camera.main.transform.position;
                    Camera.main.transform.position = cameraDestination.position;

                    //var moveDelta = player.transform.position - startPosition;
                    //Camera.main.transform.position += moveDelta;
                }
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        DoorText.text = ("");
    }
}
