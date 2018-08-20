using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltraDoorController : MonoBehaviour {


    public GameObject Door;
    public UltraDoorController Predecessor;
    public bool doorIsOpening;
    public float doorOpenY;
    public bool isLast;

    private bool inRange;

	// Use this for initialization
	void Start ()
    {	
        
	}
	
	// Update is called once per frame
	void Update ()
    {

        if (Predecessor.doorIsOpening == true)
            if (isLast == true)
                if (doorIsOpening == true)
                {
                    Door.transform.Translate(Vector3.up * Time.deltaTime * 5);
                    //if the bool is true, open the door, you dumb shitting program
                }

        if (Door.transform.position.y > doorOpenY)
        {
            doorIsOpening = false;
        }

        if (inRange == true)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                doorIsOpening = true;
            }
        }


    }

    void OnTriggerEnter(Collider other)
    {
        inRange = true;
    }

    void OnTriggerExit(Collider other)
    {
        inRange = false;
    }
}
