using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeballActivation : MonoBehaviour {

    private Animator eyeballAnim;
    public GameObject projectile;
    public Transform spawnPos;
    public float force = 500f;
    public float intervalBetweenFiring = 2f;

    private float fireTimer = 0f;
    private float direction;
    private Transform eyeballTransform;
    private Vector3 instantiationPosition;
    private bool active = false;

    private void Start()
    {
        eyeballAnim = GetComponentInParent<Animator>();
        eyeballTransform = GetComponentInParent<Transform>();
        direction = -eyeballTransform.localScale.x;
        //Debug.Log("Direction of projectile: " + direction);
        //direction is opposite of the way the sprite is facing
        instantiationPosition = new Vector3(spawnPos.position.x, spawnPos.position.y, spawnPos.position.z);
    }

    private void Update()
    {
        //Debug.Log("Active: " + active);
        if (active)
        {
            //Debug.Log(fireTimer);
            fireTimer += Time.deltaTime;
            if (fireTimer > intervalBetweenFiring)
            {
                FireProjectile(projectile);
                fireTimer = 0f;
            }
        }

        active = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            PlayActivationAnimation(eyeballAnim);
            active = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayShutdownAnimation(eyeballAnim);
            active = false;
            fireTimer = 0f;
        }

    }

    private void PlayActivationAnimation(Animator animator)
    {
        animator.SetBool("eyeballIdle", false);
        animator.SetBool("eyeballShutdown", false);
        animator.SetBool("eyeballWake", true);
        animator.SetBool("eyeballStandingIdle", true);
        animator.SetBool("eyeballShooting", true);
    }

    private void PlayShutdownAnimation(Animator animator)
    {
        animator.SetBool("eyeballShooting", false);
        animator.SetBool("eyeballWake", false);
        animator.SetBool("eyeballStandingIdle", false);
        animator.SetBool("eyeballShutdown", true);
        animator.SetBool("eyeballIdle", true);
    }

    private void FireProjectile(GameObject projectile)
    {
        var proj = Instantiate(projectile, instantiationPosition, Quaternion.identity);
        proj.transform.localScale = eyeballTransform.localScale;
        var projBody = proj.GetComponent<Rigidbody2D>();
        projBody.AddForce(new Vector2(force * direction, 0));
    }
}
