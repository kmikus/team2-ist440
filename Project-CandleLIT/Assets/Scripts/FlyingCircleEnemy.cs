using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingCircleEnemy : MonoBehaviour
{

    float timeCounter = 0;

    float speed;
    float width;
    float height;

    void Start()
    {
        speed = 2;
        width = 2;
        height = 2;
    }

    void Update()
    {
        timeCounter += Time.deltaTime * speed;

        float x = Mathf.Cos(timeCounter) * width;
        float y = Mathf.Sin(timeCounter) * height;
        float z = 0;

        Debug.Log(x + " " + y + " " + z);
        gameObject.transform.position = new Vector3(x, y, z);
    }
}
