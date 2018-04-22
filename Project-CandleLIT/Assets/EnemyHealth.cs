using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    public static float laserDamageAmount = 1f;

    public float startingHealth = 5f;
    public GameObject deathParticlePrefab;

    private float health;
    private SoundEffects sfx;

	private void Start()
	{
        sfx = SoundManager.instance.GetComponent<SoundEffects>();
        health = startingHealth;
	}

	private void Update()
	{
        if (health <= 0) {
            SoundManager.instance.PlaySingle(sfx.enemyKilled);
            var dp = Instantiate(deathParticlePrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            Destroy(dp, 2f);
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
