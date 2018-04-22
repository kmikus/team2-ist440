using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameoverSkip : MonoBehaviour {

    private float t = 0f;
    public float delayTime = 2f;

	// Update is called once per frame
	void Update()
    {
        t += Time.fixedUnscaledDeltaTime;
        Debug.Log("t: " + t);
        if (Input.GetButtonDown("Submit") && t > delayTime)
            {
            SceneManager.LoadScene("Highscore");
        }
    }
}
