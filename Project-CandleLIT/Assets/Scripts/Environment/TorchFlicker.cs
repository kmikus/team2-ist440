using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchFlicker : MonoBehaviour {

    private Light torchLight;

    public float baseRange = 8f;
    public float rangeFactor = 5f;

    public float baseAngle = 90f;
    public float angleFactor = 20f;

    public float speed = 5f;

    private float randomOffset;

	// Use this for initialization
	void Start () {
        torchLight = GetComponent<Light>();
        randomOffset = Random.Range(0, 10);
	}
	
	// Update is called once per frame
	void Update () {
        torchLight.range = baseRange + (Mathf.Abs(Mathf.Sin(Time.time * speed + randomOffset)) * rangeFactor);
        torchLight.spotAngle = baseAngle - (Mathf.Abs(Mathf.Sin(Time.time * speed + randomOffset)) * angleFactor);

    }
}
