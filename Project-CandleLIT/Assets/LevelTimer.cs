using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTimer : MonoBehaviour {

    public float amountOfTime = 120f;

    private void Start()
    {
        GameObject.Find("Timer").GetComponent<TimeManager>().UpdateTime(amountOfTime);
    }
}
