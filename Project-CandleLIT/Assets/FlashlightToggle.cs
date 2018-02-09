using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightToggle : MonoBehaviour {

    private Light flashlightLight;
    private bool lightOn = false;

	// Use this for initialization
	void Start () {
        flashlightLight = GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
        if (lightOn)
        {
            flashlightLight.intensity = 40;
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
