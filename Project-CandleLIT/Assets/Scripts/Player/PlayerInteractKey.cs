using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerInteractKey : MonoBehaviour {

    public GameObject currentKey = null;
    public InteractionKey currentInterObjScript = null;
    public Inventory inventory;
    public Text DoorWithKeyText;
    public int LevelToLoad = 5;
    private Animator doorAnim;
    private float doorTextResetTimer = 0f;
    private bool startDoorTextResetTimer = false;
    public float amountOfTimeToDisplayYouNeedKeyText = 2.5f;

	void Update()
    {
        if (startDoorTextResetTimer) {
            doorTextResetTimer += Time.deltaTime;

            if (doorTextResetTimer > amountOfTimeToDisplayYouNeedKeyText) {
                DoorWithKeyText.text = "";
                doorTextResetTimer = 0f;
                startDoorTextResetTimer = false;
            }
        }

        if (Input.GetButtonDown("KeyPickup") && currentKey)
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
                        doorAnim = GameObject.Find("doorForTestingKey").GetComponent<Animator>();
                        doorAnim.SetBool("Open", true);
                        currentInterObjScript.locked = false;
                        Debug.Log(currentInterObjScript.name + " was unlocked");
                        DoorWithKeyText.text = ("ENTER LEVEL " + (LevelToLoad - 3));

                        // Remove key from inventory since it was used to unlock door
                        if (currentKey != null)
                        {
                            inventory.RemoveItem(currentKey);
                        }

                        
                    }
                    else
                    {
                        Debug.Log(currentInterObjScript.name + " is locked");
                        DoorWithKeyText.text = ("You need a key to unlock the door!");
                        startDoorTextResetTimer = true;
                    }
                }
                else
                {
                    //TODO fix this
                    // Door is not locked  - open it
                    // for score and time bonuses
                    var levelTimer = GameObject.Find("LevelTimer");
                    var bonus = levelTimer.GetComponent<ScoreBonus>();
                    bonus.addRemainingTimeBonus();
                    bonus.addLevelCompletionBonus();
                    Debug.Log(currentInterObjScript.name + " is unlocked");
                    SceneManager.LoadScene(LevelToLoad);
                    //doorAnim.SetBool("Open", false);
                    DoorWithKeyText.text = "";
                    LevelToLoad++;
                    //next level's timer
                    levelTimer = GameObject.Find("LevelTimer");
                    if (levelTimer != null)
                    {
                        var newTime = levelTimer.GetComponent<LevelTimer>().amountOfTime;
                        GameObject.Find("Timer").GetComponent<TimeManager>().UpdateTime(newTime);
                    }


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
