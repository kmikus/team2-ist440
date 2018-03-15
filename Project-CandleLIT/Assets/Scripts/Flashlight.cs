using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flashlight : MonoBehaviour {

    public float maxHealth = 2000f;
    public Slider energyBar;
    public Light flLight;
    public float flIntensity = 10f;
    public float drainVal = 5f;
    public float rechargeVal = 0.5f;
    public float batteryRechargeVal = 500f;

    private float currentHealth;
    private bool lightOn = false;

    public float CurrentHealth
    {
        get
        {
            return currentHealth;
        }
    }

    public bool LightOn
    {
        get
        {
            return lightOn;
        }
    }

    private void Start()
    {
        currentHealth = maxHealth;
        energyBar.value = CalcHealth();
    }

    private void Update()
    {

        if (lightOn)
        {
            Drain(drainVal);
            if (currentHealth == 0) { ToggleLight(); }
        } else
        {
            Recharge(rechargeVal);
        }
    }

    public void Recharge(float amount)
    {
        if (currentHealth < maxHealth)
        {
            currentHealth += amount;
            energyBar.value = CalcHealth();
        } else
        {
            currentHealth = maxHealth;
        }

    }

    public void Drain(float amount)
    {
        if(currentHealth > 0)
        {
            currentHealth -= amount;
            energyBar.value = CalcHealth();
        } else
        {
            currentHealth = 0;
        }

    }

    public void ToggleLight()
    {
        lightOn = !lightOn;

        flLight.intensity = lightOn ? flIntensity : 0;
    }

    public float CalcHealth()
    {
        return currentHealth / maxHealth;
    }
}
