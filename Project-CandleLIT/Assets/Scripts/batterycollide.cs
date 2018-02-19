using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class batterycollide : MonoBehaviour
{

    flashlightHealth flashlighthealth;

    public float boost = 50f;

    void Awake()
    {
        flashlighthealth = FindObjectOfType<flashlightHealth>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (flashlightHealth.CurrentHealth < flashlightHealth.MaxHealth)
        {
            flashlightHealth.CurrentHealth = flashlightHealth.CurrentHealth + boost;
        }
        Destroy(this.gameObject);
    }


}
