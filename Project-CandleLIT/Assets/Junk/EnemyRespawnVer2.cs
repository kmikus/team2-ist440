using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRespawnVer2 : MonoBehaviour {

    public float respawnTime = 20f;
    private float t = 0;
	
	// Update is called once per frame
	void Update () {
        if (!gameObject.activeSelf) {
            t += Time.deltaTime;
            Debug.Log("t: " + t);

            if (t > respawnTime) {
                gameObject.SetActive(true);
            }
        }
	}
}
