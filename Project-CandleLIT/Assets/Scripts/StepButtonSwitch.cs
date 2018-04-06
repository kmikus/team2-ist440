using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepButtonSwitch : MonoBehaviour {

    public BarrierDoor door;
    public bool isOpen;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            door.DoorOpens();
            isOpen = true;
        }
        else
        {
            door.DoorCloses();
            isOpen = false;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        door.DoorCloses();
        isOpen = false;
    }


}
