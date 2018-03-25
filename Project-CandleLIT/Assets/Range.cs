using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Range : MonoBehaviour
{

    private EnemyFollow ef;

    private void Start()
    {
        ef = GetComponentInParent<EnemyFollow>();
    }

    private void OnTriggerStay2D(Collider2D col)

    {
        if (col.gameObject.tag == "Player")
        {
            ef.Target = col.gameObject.transform;
        }

    }

    private void OnTriggerExit2D(Collider2D col)
    {
        ef.Target = null;
    }

}