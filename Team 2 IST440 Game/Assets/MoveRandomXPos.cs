using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRandomXPos : MonoBehaviour {

    private Transform spawnerTransform;
    public float delay = 2.0f;
    private float t = 0f;
    public float minX = -8.25f;
    public float maxX = 8.25f;

	// Use this for initialization
	void Start () {
        spawnerTransform = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        t += Time.deltaTime;
        if (t >= delay)
        {
            spawnerTransform.SetPositionAndRotation(new Vector3(Random.Range(minX, maxX), spawnerTransform.position.y, 0), Quaternion.identity);
            t = 0;
        }
	}
}
