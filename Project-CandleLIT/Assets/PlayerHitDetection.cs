using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitDetection : MonoBehaviour {

    private PlayerHealth ph;
    private Flashlight fl;
    private bool recentlyHit = false;
    private float recentlyHitTimer = 0f;
    private float recentlyHitTimeout = 5f;

    void Start()
    {
        ph = GetComponent<PlayerHealth>();
        fl = GetComponent<Flashlight>();
    }

    private void Update()
    {
        if (recentlyHit)
        {
            recentlyHitTimer += Time.deltaTime;
        }

        if (recentlyHitTimer > recentlyHitTimeout)
        {
            recentlyHit = false;
            recentlyHitTimer = 0f;
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
