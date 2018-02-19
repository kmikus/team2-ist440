using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class flashlightHealth : MonoBehaviour
{

    public static float CurrentHealth { get; set; }
    public static float MaxHealth { get; set; }

    public Slider healthbar;


    void Start()
    {
        MaxHealth = 1000f;
        CurrentHealth = MaxHealth;

        healthbar.value = CalculateHealth();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.V))
        if (FlashlightToggle.lightOn)
        {
            DealDamage(2);
        }

    }

    void DealDamage(float damageValue)
    {
        CurrentHealth -= damageValue;
        healthbar.value = CalculateHealth();
        if (CurrentHealth <= 0)
            Die();
    }

    void heal(float healValue)
    {
        CurrentHealth += healValue;
        healthbar.value = CalculateHealth();
        if (CurrentHealth <= 0)
            Die();
    }

    float CalculateHealth()
    {
        return CurrentHealth / MaxHealth;
    }
    void Die()
    {
        CurrentHealth = 0;
    }
}
