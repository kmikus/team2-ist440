using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private Rigidbody2D body2d;
    private Animator animator;

    public float xVelocity = 0.2f;

	// Use this for initialization
	void Start () {
        body2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        var direction = Input.GetAxis("Horizontal");

        if (direction != 0)
        {
            if (direction > 0)
            {
                body2d.transform.Translate(new Vector3(direction * xVelocity * Time.deltaTime,0,0));
                body2d.transform.Rotate(0, 0, 0);
            }

            if (direction < 0)
            {
                body2d.transform.Translate(new Vector3(direction * xVelocity * Time.deltaTime,0,0));
                
                if (body2d.transform.localRotation.y == 0)
                {
                    body2d.transform.Rotate(0, 180, 0);
                }
            }

            animator.SetBool("Walking", true);

        } else
        {
            animator.SetBool("Walking", false);
        }
    }
}
