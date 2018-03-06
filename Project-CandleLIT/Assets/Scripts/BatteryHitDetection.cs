using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryHitDetection : MonoBehaviour
{
    private GameObject player;
    private Flashlight fl;

    public float rechargeAmount = 500f;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            player = col.gameObject;
            fl = player.GetComponent<Flashlight>();
            Debug.Log("Battery collision- Battery energy old: " + fl.CurrentHealth);
            if (fl.CurrentHealth == fl.maxHealth) { return; }
            fl.Recharge(rechargeAmount);
            Destroy(this.gameObject);
            Debug.Log("New energy: " + fl.CurrentHealth);
        }
    }


}
