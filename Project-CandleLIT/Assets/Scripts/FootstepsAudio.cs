using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepsAudio : MonoBehaviour {
    
    public bool grounded;
    public LayerMask ground;
    
    Collider2D playerCollider;
    
    // Use this for initialization
    void Start () {
        
        playerCollider = GetComponent<Collider2D> ();
        
    }
    
    // Update is called once per frame
    void Update () {
        
        PlayStopFootSteps ();
        
    }
    
    void PlayStopFootSteps()
    {
        grounded = playerCollider.IsTouchingLayers (ground);
        
        if ((Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.RightArrow)) && grounded) {
            
            if (!GetComponent<AudioSource> ().isPlaying)
            GetComponent<AudioSource> ().Play ();
        }
        else
        {
            if (GetComponent<AudioSource> ().isPlaying)
            GetComponent<AudioSource> ().Stop();
        }
        
    }
}

