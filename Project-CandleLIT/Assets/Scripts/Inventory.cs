using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {


    public GameObject[] inventory = new GameObject[5];
    public Button[] inventorybutton = new Button[5];

    public void AddItem(GameObject item)
    {
        bool itemAdded = false;

        // Find the first open slot in inventory with looping
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == null)
            {
                inventory[i] = item;
                Debug.Log(item.name + "was added");
                inventorybutton[i].image.overrideSprite = item.GetComponent<SpriteRenderer>().sprite;
                itemAdded = true;
                // Do something with object
                item.SendMessage("DoInteraction");
                break;
            }
        }

        // If inventory is full
        if (!itemAdded)
        {
            Debug.Log("Inventory Full - Item not Added");
        }
    }

    public bool FindItem(GameObject item)
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == item)
            {
                // Found item
                return true;
            }
        }

        // Did not find item
        return false;
    }

    public void RemoveItem(GameObject item)
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] = item)
            {
                inventory[i] = null;
                Debug.Log(item.name + " was removed from inventory");

                inventorybutton[i].image.overrideSprite = null;
                break;
            }
        }
    }
}
