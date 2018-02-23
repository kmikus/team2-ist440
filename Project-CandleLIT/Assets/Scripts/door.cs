using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour {

  
    public Text DoorText;
    public Vector3 tempPos;
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Door"))
        {
            DoorText.text = ("[t] to enter");

            if (Input.GetKeyDown("t"))
            {
                
                tempPos = transform.position;
                tempPos = new Vector3(-39.7f, 13.1f, 0f);
                transform.position = tempPos;

            }
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Door"))
        {
            if (Input.GetKeyDown("t"))
            {
                tempPos = transform.position;
                tempPos = new Vector3(-39.7f, 13.1f, 0f);
                transform.position = tempPos;
            }
    }
        }

    void OnTriggerExit2D(Collider2D collision)
    {
        DoorText.text = ("");
    }
}
