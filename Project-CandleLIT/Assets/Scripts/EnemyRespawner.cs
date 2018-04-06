using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRespawner : MonoBehaviour
{
    private List<Enemy> enemies;
    private SoundEffects sfx;

    public float respawnTimer = 30f;
    public GameObject respawnParticles;

    void Start()
    {
        enemies = new List<Enemy>();
        sfx = SoundManager.instance.GetComponent<SoundEffects>();

        foreach (Transform t in transform) {
            if (t.parent == transform)
            {
                Enemy enemy = new Enemy(t.gameObject);
                enemies.Add(enemy);
            }
        }

        foreach (Enemy enemy in enemies) {
            Debug.Log(enemy.getEnemyGameObject());
        }
    }

    void Update()
    {
        foreach (Enemy enemy in enemies) {
            if (!enemy.getEnemyGameObject().activeSelf) {
                enemy.increaseTimer(Time.deltaTime);

                if (enemy.getRespawnTimer() > respawnTimer) {
                    SoundManager.instance.PlaySingle(sfx.enemyRespawned);
                    enemy.getEnemyGameObject().SetActive(true);
                    var pos = enemy.getEnemyGameObject().transform.position;
                    var rp = Instantiate(respawnParticles, new Vector3(pos.x, pos.y, pos.z), Quaternion.identity);
                    Destroy(rp, 2f);
                    enemy.resetTimer();
                }
            }
        }
    }

}