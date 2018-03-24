using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDash : MonoBehaviour
{

    public float force;
    public float dashInterval = 3f;
    public float dashTimer = 0f;
    public GameObject dashingEnemy;


    private Vector2 dir = new Vector2(-1, 0);
    private bool active = true;
    private float direction;
    private Transform enemyTransform;


    // Use this for initialization
    void Start()
    {
        enemyTransform = GetComponentInParent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!active)
        {
            dashTimer += Time.deltaTime;
        }

        if (dashTimer > dashInterval)
        {
            active = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && active)
        {
            DashAttack(dashingEnemy);
            active = false;
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
        direction = enemy.transform.localScale.x;
        dashAttack.AddForce(new Vector2(force * direction, 0));
    }
}
