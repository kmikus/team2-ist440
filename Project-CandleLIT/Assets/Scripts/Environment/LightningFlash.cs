using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningFlash : MonoBehaviour {

    private Light lightning;
    private float activeTimer;
    private float lerpTimer;
    private bool active = false;
    private float randomTimeAdded;

    public float activeResetTime = 30f;
    public float randomRange = 30f;
    public float intensity = 2f;
    public float fadeSpeed = 2f;
	// Use this for initialization
	void Start () {
        lightning = GetComponent<Light>();
        lightning.intensity = 0;
        randomTimeAdded = Random.Range(0, randomRange);
    }
	
	// Update is called once per frame
	void Update () {

        activeTimer += Time.deltaTime;

		if (activeTimer > activeResetTime + randomTimeAdded && !active)
        {
            active = true;
        }

        if (active)
        {
            lerpTimer += Time.deltaTime * fadeSpeed;
            lightning.intensity = Mathf.Lerp(intensity, 0, lerpTimer);

            if (lerpTimer > 1)
            {
                active = false;
                activeTimer = 0;
                lerpTimer = 0f;
                randomTimeAdded = Random.Range(0, randomRange);
            }
        }

	}
}
