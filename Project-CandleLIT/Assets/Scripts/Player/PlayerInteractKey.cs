﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteractKey : MonoBehaviour {

    public GameObject currentKey = null;
    public Collider2D collision;
    public InteractionKey currentInterObjScript = null;
    public Inventory inventory;
    public Text DoorWithKeyText;

    void Update()
    {
        if (Input.GetKeyDown("p") && currentKey)
        {
            // Check to see if should be stored in inventory
            if (currentInterObjScript.inventory)
            {
                inventory.AddItem(currentKey);
            }  
            
            // Check to see if door can be opened
            if (currentInterObjScript.openable)
            {
                // Check to see if door is locked
                if (currentInterObjScript.locked)
                {
                    // Check to see if we have key to unlock door
                    // Search inventory for key - if found unlock
                    if (inventory.FindItem(currentInterObjScript.itemNeeded))
                    {
                        // Found item needed now unlock door
                        currentInterObjScript.locked = false;
                        Debug.Log(currentInterObjScript.name + " was unlocked");
                        DoorWithKeyText.text = ("You've unlocked the door! Press [p] to enter");

                        // Remove key from inventory since it was used to unlock door
                        if (currentKey != null)
                        {
                            inventory.RemoveItem(currentKey);
                        }

                        // Transform player and camera to destination
                        
                    }
                    else
                    {
                        Debug.Log(currentInterObjScript.name + " is locked");
                        DoorWithKeyText.text = ("You need a key to unlock the door!");
                    }
                }
                else
                {
                    // Door is not locked  - open it
                    Debug.Log(currentInterObjScript.name + " is unlocked");

                    //currentInterObjScript.Open(); --> add animation for door opening here

                    // Reference script to make player and camera transform once door is unlocked
                    //doorTransform.TransformPlayer();
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Key"))
        {
            Debug.Log(collision.name);
            currentKey = collision.gameObject;
            currentInterObjScript = currentKey.GetComponent<InteractionKey>();
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Key"))
        {
            if (collision.gameObject == currentKey)
            {
                currentKey = null;
            }
        }
    }
}