using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlaslightDamageEnemy : MonoBehaviour {

    private GameObject enemy;
    private Flashlight fl;
    private float t = 0f;

    public float disableTime = 10f;

	// Use this for initialization
	void Start () {
        fl = GetComponentInParent<Flashlight>();
	}
	
	// Update is called once per frame
	void Update () {
		if (enemy != null && !enemy.activeSelf)
        {
            t += Time.deltaTime;
        }

        if (t > disableTime)
        {
            enemy.SetActive(true);
            t = 0;
        }
	}

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Enemy" && fl.LightOn)
        {
            enemy = collider.gameObject;
            enemy.SetActive(false);
        }
    }
}
