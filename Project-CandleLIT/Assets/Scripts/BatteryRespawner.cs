using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryRespawner : MonoBehaviour {

    private bool active = true;
    public float respawnTimer = 15f;
    public float timer = 0f;

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		if(active == false)
        {
            timer = Time.deltaTime;
            if(timer > respawnTimer)
            {
                gameObject.SetActive(true);
                active = true;
                timer = 0f;
            }
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            active = false;
            gameObject.SetActive(false);
        }
    }
}
