using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderState : MonoBehaviour {

    private bool waiting = true;
    private bool attacking = false;
    private bool retracting = false;
    private bool canAttack = true;

    public float attackTime = 4f;

    public bool Waiting
    {
        get
        {
            return waiting;
        }

        set
        {
            waiting = value;
        }
    }

    public bool Attacking
    {
        get
        {
            return attacking;
        }

        set
        {
            attacking = value;
        }
    }

    public bool Retracting
    {
        get
        {
            return retracting;
        }

        set
        {
            retracting = value;
        }
    }

    public bool CanAttack
    {
        get
        {
            return canAttack;
        }

        set
        {
            canAttack = value;
        }
    }
}
