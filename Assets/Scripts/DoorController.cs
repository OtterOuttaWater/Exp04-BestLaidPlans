using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour {


    public GameObject Door;
    public bool doorIsOpening;
    public float doorOpenY;

	// Use this for initialization
	void Start ()
    {

		
	}
	
	// Update is called once per frame
	void Update ()
    {

        if (doorIsOpening == true)
        {
            Door.transform.Translate(Vector3.up * Time.deltaTime * 5);
            //if the bool is true, open the door, you dumb shitting program

        }

        if (Door.transform.position.y > doorOpenY)
        {
            doorIsOpening = false;
        }


    }

    void OnMouseDown()
    {
        doorIsOpening = true;
        // if we click on the button, door must start to open???? (Switch this for a 'press f to door'), make the box collider a trigger
    }
}
