using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlaslightDamageEnemy : MonoBehaviour {

    private GameObject enemy;
    private Flashlight fl;
    private float t = 0f;

    private float particleTimer = 0f;
    private bool particleAdded = false;
    public GameObject deathParticle;
    public Transform enemyPosition;
    public float disableTime = 10f;

	// Use this for initialization
	void Start () {
        fl = GetComponentInParent<Flashlight>();
	}
	
	// Update is called once per frame
	void Update () {
		if (enemy != null && !enemy.activeSelf)
        {
            t += Time.deltaTime;
        }

        if (t > disableTime)
        {
            enemy.SetActive(true);
            t = 0;
        }
        if (particleAdded)
        {
            particleTimer += Time.deltaTime;
        }
        if(particleTimer > 2f)
        {
            Destroy(deathParticle);
            particleTimer = 0f;
        }
	}

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Enemy" && fl.LightOn)
        {
            enemy = collider.gameObject;
            enemyPosition = enemy.GetComponent<Transform>();
            Instantiate(deathParticle, new Vector3(enemyPosition.position.x, enemyPosition.position.y, enemyPosition.position.z), Quaternion.identity);
            enemy.SetActive(false);
            particleAdded = true;
        }
    }
}
