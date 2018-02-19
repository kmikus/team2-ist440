using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthbar : MonoBehaviour
{

    public Image currentHealthbar;
    public Text ratioText;

    private float maxhitpoint = 150;
    private float hitpoint = 150;
    // Use this for initialization
    void Start()
    {
        UpdateHealthbar();
    }

    // Update is called once per frame
    void UpdateHealthbar()
    {
        float ratio = hitpoint / maxhitpoint;
        currentHealthbar.rectTransform.localScale = new Vector3(ratio, 1, 1);
        ratioText.text = (ratio * 100).ToString("0") + "%";
    }

    private void TakeDamage(float damage)
    {
        hitpoint -= damage;
        if (hitpoint < 0)
        {
            hitpoint = 0;
            Debug.Log("Dead");
        }

        UpdateHealthbar();
    }

    private void HealDamage(float heal)
    {
        hitpoint += heal;
        if (hitpoint > maxhitpoint)
            hitpoint = maxhitpoint;

        UpdateHealthbar();
    }


}
