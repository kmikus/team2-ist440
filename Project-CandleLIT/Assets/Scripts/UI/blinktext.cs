using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class blinktext : MonoBehaviour {

    public float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 0.5)
        {
            if(GetComponent<Button>() != null)
                GetComponent<Button>().enabled = true;
        }

        if(timer >= 1)
        {
            if (GetComponent<Button>() != null)
                GetComponent<Button>().enabled = false;
            timer = 0;
        }
       // Time.timeScale = 1;
    }
}
