using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitDetection : MonoBehaviour {

    private GameObject player;
    private SpriteRenderer sr;
    private PlayerHealth ph;
    public float damageAmount = 10f;

    private bool recentlyHit = false;
    private float recentlyHitTimer = 0f;
    public float recentlyHitTimeout = 3f;

    private float flickerTimer = 0f;
    public float flickerInterval = 0.07f;
    private Color transparent = new Color(1f, 1f, 1f, 0f);
    private Color visible = new Color(1f, 1f, 1f, 1f);
    private bool isVisible = true;

    private BoxCollider2D enemyCol;
	// Use this for initialization
	void Start () {
        enemyCol = GetComponent<BoxCollider2D>();
	}

    // Update is called once per frame
    private void Update()
    {
        if (recentlyHit)
        {
            recentlyHitTimer += Time.deltaTime;
            flickerTimer += Time.deltaTime;
        }

        if (flickerTimer > flickerInterval)
        {
            sr.color = isVisible ? transparent : visible;
            isVisible = !isVisible;
            flickerTimer = 0f;
        }

        if (recentlyHitTimer > recentlyHitTimeout)
        {
            recentlyHit = false;
            recentlyHitTimer = 0f;
            sr.color = visible;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" && !recentlyHit)
        {
            player = col.gameObject;
            ph = player.GetComponent<PlayerHealth>();
            sr = player.GetComponent<SpriteRenderer>();

            ph.DealDamage(damageAmount);
            Debug.Log("Enemy collision- Player health: " + ph.CurrentHealth);
            recentlyHit = true;
        }
    }
}
