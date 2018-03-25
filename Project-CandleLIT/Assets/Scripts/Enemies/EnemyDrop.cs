using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDrop : MonoBehaviour
{

    public float force;
    public float dashInterval = 3f;
    public float dashTimer = 0f;
    public GameObject dashingEnemy;    
    private bool active = false;
    private float direction;
    private Transform enemyTransform;
    private SpiderState spiderState;


    // Use this for initialization
    void Start()
    {
        enemyTransform = GetComponentInParent<Transform>();
        direction = enemyTransform.localScale.y;
        spiderState = GetComponentInParent<SpiderState>();
    }

    // Update is called once per frame
    void Update()
    {
        if (active && spiderState.CanAttack && spiderState.Waiting)
        {
            DashAttack(dashingEnemy);
            spiderState.Waiting = false;
            spiderState.Attacking = true;
            spiderState.CanAttack = false;
            
        }

        if (!spiderState.CanAttack)
        {
            dashTimer += Time.deltaTime;
            if (dashTimer > dashInterval)
            {
                spiderState.CanAttack = true;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            active = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            active = false;
        }

    }

    private void DashAttack(GameObject enemy)
    {
        var dashAttack = dashingEnemy.GetComponent<Rigidbody2D>();
        dashAttack.AddForce(new Vector2(0, -(force * direction)));
    }
}

