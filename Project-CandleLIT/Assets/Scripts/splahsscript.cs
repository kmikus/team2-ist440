using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class splahsscript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(LoadMainMenu());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator LoadMainMenu()
    {
        yield return new WaitForSeconds(3f);

        SceneManager.LoadScene("Menu_Main");
    }
}
