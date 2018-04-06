using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveOnPlatform : MonoBehaviour
{
    private GameObject platform = null;
    private Vector3 offset;

    void Start()
{
        platform = null;
}

    void OnTriggerStay2D(Collider2D col)
    {
        platform = col.gameObject;
        offset = platform.transform.position - transform.position;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        platform = null;
    }

    void LateUpdate()
    {
       if (platform != null)
        {
            platform.transform.position = transform.position + offset;
        } 
    }
}
