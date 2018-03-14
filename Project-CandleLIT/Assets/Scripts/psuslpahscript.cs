using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class psuslpahscript : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        StartCoroutine(LoadSplashScreen1());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator LoadSplashScreen1()
    {
        yield return new WaitForSeconds(4f);

        SceneManager.LoadScene("SplashScreen1");
    }
}
