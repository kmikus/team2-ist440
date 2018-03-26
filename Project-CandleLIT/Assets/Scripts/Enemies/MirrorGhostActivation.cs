using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorGhostActivation : MonoBehaviour {

    private Animator anim;
    public float resetTime = 20f;
    private bool canAttack = true;
    private float t = 0;

	void Start () {
        anim = GetComponentInParent<Animator>();
	}

    void Update()
    {
        if (!canAttack)
        {
            t += Time.deltaTime;
        }

        if (t > resetTime)
        {
            canAttack = true;
            anim.SetBool("Active", false);
            t = 0;
        }
    }
	
	void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" && canAttack)
        {
            anim.SetBool("Active", true);
            canAttack = false;
        }
    }
}
