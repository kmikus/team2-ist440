using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightToggle : MonoBehaviour {



    private Light flashlightLight;
    private bool lightOn = false;

    [SerializeField]
    private Stat Energy;

    // Use this for initialization
    void Start () {
        flashlightLight = GetComponent<Light>();
	}

    private void Awake()
    {
        Energy.Initialize();
    }

    // Update is called once per frame
    void Update () {
        if (lightOn)
        {
            flashlightLight.intensity = 40;
            Energy.CurrentVal -= 2;
            if(Energy.CurrentVal == 0)
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
