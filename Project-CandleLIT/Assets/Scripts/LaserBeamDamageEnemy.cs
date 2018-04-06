using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeamDamageEnemy : MonoBehaviour {

    private float particleTimer = 0f;
    private bool particleAdded = false;
    private GameObject respawnParticle;
    private SoundEffects sfx;

    public GameObject deathParticle;

	private void Start()
	{
        sfx = SoundManager.instance.GetComponent<SoundEffects>();
	}

	public void OnTriggerEnter2D(Collider2D collision)
	{
        if (collision.gameObject.tag == "Ground") {
            Destroy(this.gameObject);
        }

        if (collision.gameObject.tag == "Enemy") {
            SoundManager.instance.PlaySingle(sfx.enemyKilled);
            var enemy = collision.gameObject;
            var enemyPosition = enemy.GetComponent<Transform>();
            var dp = Instantiate(deathParticle, new Vector3(enemyPosition.position.x, enemyPosition.position.y, enemyPosition.position.z), Quaternion.identity);
            enemy.SetActive(false);
            Destroy(dp, 2f);
            Destroy(gameObject);
        }
	}
}
