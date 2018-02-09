using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    [SerializeField]
    private Stat health;

    [SerializeField]
    private Stat Energy;


	// Use this for initialization
	private void Awake () {
        health.Initialize();
        Energy.Initialize();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Z))
        {
            health.CurrentVal -= 10;
        }
        if(Input.GetKeyDown(KeyCode.X))
        {
            health.CurrentVal += 10;
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            Energy.CurrentVal -= 10;
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            Energy.CurrentVal += 10;
        }
    }
}
