using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondHitDetection : MonoBehaviour {

    public float pointAmount = 50f;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
			FindObjectOfType<CollectDiamond> ().playDiamondCollect ();
            Scoring.increaseScore(pointAmount);
			Invoke ("destroyObject",1);
            //Destroy(this.gameObject);
            Debug.Log("Score: " + Scoring.getScore());
        }
    }

	void destroyObject()
	{
		Destroy (this.gameObject);
	}
}
