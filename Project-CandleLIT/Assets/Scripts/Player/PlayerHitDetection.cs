﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitDetection : MonoBehaviour {

    private SoundEffects sfx;
    private GameObject otherCol;
    private SpriteRenderer sr;
    private PlayerHealth ph;
    private Flashlight fl;

    public float damageAmount = 20f;

    private float recentlyHitTimer = 0f;
    public float recentlyHitTimeout = 3f;

    private float flickerTimer = 0f;
    public float flickerInterval = 0.07f;
    private Color transparent = new Color(1f, 1f, 1f, 0f);
    private Color visible = new Color(1f, 1f, 1f, 1f);
    private bool isVisible = true;
    
	bool isCollidingDoor;
	bool isDoorOpened;
	bool isCollidingWithTrapDoor;
	bool isCollidingWithKey;
	bool isCollidingWithHealth;

	AudioSource[] allSource; 

    void Start()
    {
		isCollidingWithHealth = false;
		isCollidingWithKey = false;
		isCollidingWithTrapDoor = false;
		isCollidingDoor = false;
		isDoorOpened = false;

		allSource = GetComponents<AudioSource> ();

        sfx = SoundManager.instance.GetComponent<SoundEffects>();
        sr = GetComponent<SpriteRenderer>();
        ph = GetComponent<PlayerHealth>();
        fl = GetComponent<Flashlight>();
    }

	void Update ()
    {
		keyPickupAudio ();
		playDoorOpenClose ();
		flashLightAudio ();
		healthPickUpAudio ();

        if (PlayerManager.RecentlyHit)
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
            PlayerManager.RecentlyHit = false;
            recentlyHitTimer = 0f;
            sr.color = visible;
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        //Enemy Case
        if (col.gameObject.tag == "Enemy" && !PlayerManager.RecentlyHit)
        {
            if (!PlayerManager.RecentlyHit)
            {
                ph.DealDamage(damageAmount);
                SoundManager.instance.PlaySingle(sfx.hitByEnemy);
            }
            Debug.Log("Enemy collision: " + col.gameObject.ToString() + " Player health: " + ph.CurrentHealth);
            PlayerManager.RecentlyHit = true;
        }

        //Diamond Case
        if (col.gameObject.tag == "Diamond")
        {
            SoundManager.instance.PlaySingle(sfx.diamondPickup);
            Scoring.increaseScore(Scoring.diamondPickupValue);
            Destroy(col.gameObject);
            Debug.Log("Score: " + Scoring.getScore());
        }

        //Battery Case
        if (col.gameObject.tag == "Battery")
        {
            if (!(fl.CurrentHealth == fl.maxHealth))
            {
                SoundManager.instance.PlaySingle(sfx.batteryPickup);
                fl.Recharge(fl.batteryRechargeVal);
                Destroy(col.gameObject);
            }
        }

        //Projectile Case
        if (col.gameObject.tag == "Projectile" && !PlayerManager.RecentlyHit)
        {
            if (!PlayerManager.RecentlyHit)
            {
                ph.DealDamage(damageAmount);
                SoundManager.instance.PlaySingle(sfx.hitByProjectile);
                //check if passthrough, if not destroy the projectile. Checkbox on the projectiles prefab from Projectile Hit Detection Script
                if (!col.gameObject.GetComponent<ProjectileHitDetection>().passthrough) { Destroy(col.gameObject); }
            }
            Debug.Log("Enemy collision: " + col.gameObject.ToString() + " Player health: " + ph.CurrentHealth);
            PlayerManager.RecentlyHit = true;
        }

		if (col.gameObject.tag == "Door") {

			isCollidingDoor = true;
			
		}

		if (col.gameObject.tag == "Trapdoor") {

			isCollidingWithTrapDoor = true;

		}

		if (col.gameObject.tag == "Key") {

			isCollidingWithKey = true;

		}

		if (col.gameObject.tag == "Health") {

			isCollidingWithKey = true;

		}
    }

	void OnTriggerExit2D(Collider2D col)
	{
		if (col.gameObject.tag == "Door") {
		
			isCollidingDoor = false;
		}

		if (col.gameObject.tag == "Trapdoor") {

			isCollidingWithTrapDoor = false;

		}

		if (col.gameObject.tag == "Key") {

			isCollidingWithKey = false;

		}

		if (col.gameObject.tag == "Health") {

			isCollidingWithKey = false;

		}
	}

	void playDoorOpenClose()
	{
		if (isCollidingDoor && Input.GetKeyDown (KeyCode.P)) {
		
			isDoorOpened = true;
			SoundManager.instance.PlaySingle(sfx.OpenDoor);
			
		} else if (!isCollidingDoor && isDoorOpened) {
		   
			isDoorOpened = false;
			SoundManager.instance.PlaySingle(sfx.ExitDoor);
		
		}
			
	}

	void flashLightAudio()
	{
		if ((Input.GetKey (KeyCode.E))) {

			SoundManager.instance.PlaySingle(sfx.FlashLight);

		}
	}

	void trapDoorSound()
	{
		if (isCollidingWithTrapDoor && Input.GetKeyDown (KeyCode.P)) {
		
			SoundManager.instance.PlaySingle(sfx.Trapdoor);
		
		}
	}

	void keyPickupAudio()
	{
		if (isCollidingWithKey && Input.GetKeyDown (KeyCode.P)) {

			SoundManager.instance.PlaySingle(sfx.KeyPickup);

		}
	}

	void healthPickUpAudio()
	{
		if (isCollidingWithHealth && Input.GetKeyDown (KeyCode.P)) {

			SoundManager.instance.PlaySingle(sfx.HealthPickup);

		}
	}
}