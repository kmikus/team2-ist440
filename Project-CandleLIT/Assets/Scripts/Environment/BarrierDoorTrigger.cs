using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierDoorTrigger : MonoBehaviour {

    public BarrierDoor door;
    public StepButtonSwitch button;
    
    
    void OnTriggerExit2D(Collider2D collision)
    {
       
        if (collision.tag == "Player")
        {
            door.DoorCloses();
        }
    }
}
