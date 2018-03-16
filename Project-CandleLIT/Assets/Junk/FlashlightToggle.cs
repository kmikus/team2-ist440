using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightToggle : MonoBehaviour {



    public static Light flashlightLight;
    public static bool lightOn = false;


    // Use this for initialization
    void Start () {
        flashlightLight = GetComponent<Light>();
	}



    // Update is called once per frame
    void Update () {
        if (lightOn)
        {
            flashlightLight.intensity = 40;
            if (flashlightHealth.CurrentHealth <= 0)
            {
                flashlightLight.intensity = 0;
            }
        } else
        {
            flashlightLight.intensity = 0;
        }

        if (Input.GetKeyDown("e"))
        {
            lightOn = !lightOn;
        }

    }
}
