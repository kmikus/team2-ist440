using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    public static float laserDamageAmount = 1f;

    public float startingHealth = 5f;
    private float health;

	private void Start()
	{
        health = startingHealth;
	}

	private void Update()
	{
        if (health <= 0) {
            gameObject.SetActive(false);
        }
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
        if (collision.gameObject.tag == "PlayerLaser") {
            health -= laserDamageAmount;
            Destroy(collision.gameObject);
        }
	}

    public void ResetHealth() {
        health = startingHealth;
    }
}
