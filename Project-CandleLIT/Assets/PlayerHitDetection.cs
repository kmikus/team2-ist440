using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitDetection : MonoBehaviour {

    private PlayerHealth ph;
    private Flashlight fl;
    private SpriteRenderer sr;

    private bool recentlyHit = false;
    private float recentlyHitTimer = 0f;
    public float recentlyHitTimeout = 3f;

    private float flickerTimer = 0f;
    public float flickerInterval = 0.07f;
    private Color transparent = new Color(1f, 1f, 1f, 0f);
    private Color visible = new Color(1f, 1f, 1f, 1f);
    private bool isVisible = true;

    void Start()
    {
        ph = GetComponent<PlayerHealth>();
        fl = GetComponent<Flashlight>();
        sr = GetComponent<SpriteRenderer>();
    }

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

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == 11 && !recentlyHit) // Layer 11 is enemy
        {
            Debug.Log("Player collided with enemy");
            ph.DealDamage(10);
            //TODO Currently this hits both colliders and will deal double damage.
            recentlyHit = true;
        }

        if (col.gameObject.layer == 13) // Layer 13 is battery
        {
            Debug.Log("Collided with battery");
            fl.Recharge(fl.batteryRechargeVal);
            Destroy(col.gameObject);
        }
    }
}
