using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlaslightDamageEnemy : MonoBehaviour {

    private List<GameObject> enemies = new List<GameObject>();
    private int enemyIndex=0;
    private Flashlight fl;
    private List<float> t = new List<float>();

    private float particleTimer = 0f;
    private bool particleAdded = false;
    public GameObject respawnParticle;
    public GameObject deathParticle;
    public Transform enemyPosition;
    public float disableTime = 10f;

	// Use this for initialization
	void Start () {
        fl = GetComponentInParent<Flashlight>();
	}
	
	// Update is called once per frame
	void Update () {
        if (enemies.Count > 0)
        {
            for (int i=0; i < enemies.Count; i++)
            {
                if (enemies[i] != null && !enemies[i].activeSelf)
                {
                    t[i] += Time.deltaTime;
                }

                if (t[i] > disableTime)
                {
                    enemyPosition = enemies[i].GetComponent<Transform>();
                    var rp = Instantiate(respawnParticle, new Vector3(enemyPosition.position.x, enemyPosition.position.y + 1, enemyPosition.position.z), Quaternion.identity);
                    enemies[i].SetActive(true);
                    Destroy(rp, 2f);
                    t[i] = 0;
                }
            }
        }

	}

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Enemy" && fl.LightOn)
        {
            var enemy = collider.gameObject;
            enemies.Add(enemy);
            t.Add(0);
            enemyPosition = enemy.GetComponent<Transform>();
            var dp = Instantiate(deathParticle, new Vector3(enemyPosition.position.x, enemyPosition.position.y, enemyPosition.position.z), Quaternion.identity);
            enemy.SetActive(false);
            Destroy(dp, 2f);
        }
    }
}
