using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileHitDetection : MonoBehaviour
{
    public bool passthrough;

    private void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.gameObject.tag == "Ground")
        {
            Destroy(this.gameObject);
        }
    }

}
