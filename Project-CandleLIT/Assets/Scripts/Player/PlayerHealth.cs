using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public float CurrentHealth { get; set; }
    public float MaxHealth { get; set; }
    public float heartRechargeVal = 20f;
    public Slider healthbar;

    void Start()
    {
        MaxHealth = 100f;
        CurrentHealth = MaxHealth;

        healthbar.value = CalculateHealth();
    }

    // Update is called once per frame
    void Update()
    {
        // FOR TESTING ONLY
        if (Input.GetKeyDown(KeyCode.Z))
        {
            DealDamage(10);
        }

        if (CurrentHealth <= 0)
        {
            gameController.instance.EndGame();
            Time.timeScale = 0;
        }
    }

    public void DealDamage(float damageValue)
    {
        CurrentHealth -= damageValue;
        healthbar.value = CalculateHealth();
        if (CurrentHealth <= 0)
            Die();
    }

    float CalculateHealth()
    {
        return CurrentHealth / MaxHealth;
    }

    public void recharge(float amount)
    {
        if (CurrentHealth < MaxHealth)
        {
            CurrentHealth += amount;
            healthbar.value = CalculateHealth();
        }
        else
        {
            CurrentHealth = MaxHealth;
        }

    }
    void Die()
    {
        CurrentHealth = 0;

    }
}
