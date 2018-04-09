using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour {

	public float speed;
	public float stoppingDistance;

    private Vector3 startingPosition;
	private Transform target;

    public Transform Target
    {
        get
        {
            return target;
        }

        set
        {
            target = value;
        }
    }

    // Use this for initialization
    void Start () {
        startingPosition = GetComponent<Transform>().position;
	}
	
	// Update is called once per frame
	void Update () {

        if (target != null)
        {
            if (Vector2.Distance(transform.position, Target.position) > stoppingDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, Target.position, speed * Time.deltaTime);
            }
        } else
        {
            if (Vector2.Distance(transform.position, startingPosition) > stoppingDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, startingPosition, speed * Time.deltaTime);
            }
        }
		
	}
}
