using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitDetection : MonoBehaviour {

    private PlayerHealth ph;

    void Start()
    {
        ph = GetComponent<PlayerHealth>();
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == 11) // Layer 11 is enemy
        {
            Debug.Log("Player collided with enemy");
            ph.DealDamage(10);
            //TODO Currently this hits both colliders and will deal double damage.
        }
    }
}
