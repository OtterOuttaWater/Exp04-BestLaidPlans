using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSpin : MonoBehaviour {


    public Animator anim;

	// Use this for initialization
	void Start () {

        anim = GetComponent<Animator>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        anim.SetTrigger("SpinFloor");

        if (other.tag == "Player")
        {
            other.transform.parent = transform;
        }
    }

    void OnTriggerExit(Collider other)
    {
        anim.enabled = true;
        if(other.tag == "Player")
        {
            other.transform.parent = null;
        }
    }
    
    void pauseAnimationEvent()
    {
        anim.enabled = false;
    }
}
