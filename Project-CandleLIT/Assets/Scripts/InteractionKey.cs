using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionKey : MonoBehaviour {

    public bool inventory; // If true, can be stored in inventory
    public bool openable;  // If true, door can be opened
    public bool locked;    // If true, door is locked
    public GameObject itemNeeded;  // Key needed to interact with
    public Animator anim;

	public void DoInteraction()
    {
        // Picked up and put in inventory
        gameObject.SetActive(false);
        
    }

    //public void Open()
    //{
        //anim.SetBool("open", true);
    //}
}
