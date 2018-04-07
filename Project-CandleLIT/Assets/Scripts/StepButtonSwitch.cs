using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepButtonSwitch : MonoBehaviour {

    public BarrierDoor door;
    public bool isOpen;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            door.DoorOpens();
            isOpen = true;
            anim.SetBool("steppedOn", true);
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
        anim.SetBool("steppedOn", false);
    }


}
