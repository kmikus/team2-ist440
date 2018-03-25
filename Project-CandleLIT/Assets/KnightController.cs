using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightController : MonoBehaviour {

    public BoxCollider2D stopCollider;
    public Transform leftPosition;
    private Rigidbody2D body2d;
    private Transform knightTransform;
    private Transform stopColPosition;
    private Vector3 stopColVector;

    private bool waiting = true;
    private bool isFlipped = false;

    private void Start()
    {
        body2d = GetComponent<Rigidbody2D>();
        knightTransform = GetComponent<Transform>();
        stopColPosition = stopCollider.gameObject.transform;
        stopColVector = new Vector3(stopColPosition.position.x, stopColPosition.position.y, stopColPosition.position.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == stopCollider && !isFlipped)
        {
            body2d.velocity = Vector2.zero;
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            var newPosition = new Vector3(leftPosition.position.x, leftPosition.position.y, leftPosition.position.z);
            stopCollider.gameObject.transform.SetPositionAndRotation(newPosition, Quaternion.identity);
            isFlipped = !isFlipped;
        } else if (collision == stopCollider && isFlipped)
        {
            body2d.velocity = Vector2.zero;
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            var newPosition = stopColVector;
            stopCollider.gameObject.transform.SetPositionAndRotation(newPosition, Quaternion.identity);
            isFlipped = !isFlipped;
        }

    }
}
