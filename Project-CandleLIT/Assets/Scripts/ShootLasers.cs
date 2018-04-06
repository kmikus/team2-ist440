using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootLasers : MonoBehaviour {

    public Transform spawnPos;
    public GameObject projectilePrefab;
    public float force = 1000f;
    public float drainValue = 100f;

    private Transform playerTransform;
    private float fireTimer = 0f;
    private float direction;
    private Vector3 instantiationPos;
    private Flashlight flashlight;
    private SoundEffects sfx;

	// Use this for initialization
	void Start () {
        playerTransform = GetComponent<Transform>();
        flashlight = GetComponent<Flashlight>();
        sfx = GameObject.Find("SoundManager").GetComponent<SoundEffects>();
	}

    public void FireProjectile()
    {
        if (flashlight.CurrentHealth >= drainValue)
        {
            SoundManager.instance.PlayerLaser(sfx.shootLaser);
            instantiationPos = new Vector3(spawnPos.position.x, spawnPos.position.y, spawnPos.position.z);
            var xScale = playerTransform.localScale.x;
            direction = xScale / Mathf.Abs(xScale);
            var proj = Instantiate(projectilePrefab, instantiationPos, Quaternion.identity);
            var projBody = proj.GetComponent<Rigidbody2D>();
            projBody.AddForce(new Vector2(force * direction, 0));
            flashlight.Drain(drainValue);
        }
    }
}
