using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDash : MonoBehaviour
{

    public float force;
    public float dashInterval = 3f;
    public float dashTimer = 0f;
    public GameObject dashingEnemy;
    private Animator anim;

    private Vector2 dir = new Vector2(-1, 0);
    private bool active = true;
    private float direction;
    private Transform enemyTransform;


    // Use this for initialization
    void Start()
    {
        enemyTransform = GetComponentInParent<Transform>();
        anim = GetComponentInParent<Animator>();
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
            dashTimer = 0f;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && active)
        {
            DashAttack(dashingEnemy);
        }
    }

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        active = false;
    //    }

    //}

    private void DashAttack(GameObject enemy)
    {
        var dashAttack = dashingEnemy.GetComponent<Rigidbody2D>();
        direction = enemy.transform.localScale.x;
        anim.SetBool("Attacking", true);
        dashAttack.AddForce(new Vector2(force * direction, 0));
        active = false;
    }
}
