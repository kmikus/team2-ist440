using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPlayerLocation : MonoBehaviour {

    private Transform[] startTransforms;
	// Use this for initialization
	void Start () {
        startTransforms = GetComponentsInChildren<Transform>();

        foreach (var startTransform in startTransforms)
        {
            if (startTransform.gameObject.name == "Player1Start")
            {
                var p1 = GameObject.Find("Player1");
                p1.transform.position = startTransform.position;
            } else if (startTransform.gameObject.name == "Player2Start")
            {
                var p2 = GameObject.Find("Player2");
                if (p2 != null)
                    p2.transform.position = startTransform.position;
            }
        }
	}
}
