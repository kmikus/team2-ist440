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


    // Use this for initialization
    void Start()
    {
        enemyTransform = GetComponentInParent<Transform>();
        direction = enemyTransform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            DashAttack(dashingEnemy);
            dashTimer = 0f;
            dashTimer += Time.deltaTime;
            if (dashTimer > dashInterval)
            {
                DashAttack(dashingEnemy);
                dashTimer = 0f;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
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

