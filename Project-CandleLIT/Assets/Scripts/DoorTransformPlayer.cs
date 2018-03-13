using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTransformPlayer : MonoBehaviour
{

    public Transform TransformDestination; // Where player will transform to
    public Transform cameraTransform; // Where camera will transform to
    public static PlayerInteractKey PlayerInteractScript; // Reference to Player Interact Script
   

    public void TransformPlayer()
    {
        PlayerInteractScript.GetComponent<PlayerInteractKey>();

        if (Input.GetKeyDown("p") && PlayerInteractScript.currentKey != null)
        {
            var player = GameObject.FindGameObjectWithTag("Player");
            

            if (TransformDestination != null)
            {
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
    


