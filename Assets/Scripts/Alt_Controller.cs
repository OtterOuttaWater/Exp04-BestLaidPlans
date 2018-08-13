using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alt_Controller : MonoBehaviour {


    public float speed = 2f;
    public float sensitivity = 2f;
    CharacterController player;

    public GameObject eyes;

    float movefB;
    float moveLR;

    float rotX;
    float rotY;

	// Use this for initialization
	void Start () {

        player = GetComponent<CharacterController>();
        Cursor.visible = false;

    }
	
	// Update is called once per frame
	void Update () {

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        player.Move(move * Time.deltaTime * speed);
        /*movefB = Input.GetAxis("Vertical") * speed;
        moveLR = Input.GetAxis("Horizontal") * speed;
        */
        rotX = Input.GetAxis("Mouse X") * sensitivity;
        rotY -= Input.GetAxis("Mouse Y") * sensitivity;
        rotY = Mathf.Clamp(rotY, -60f, 60f);   //Keeps you from going upside down


        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        player.Move(move * Time.deltaTime * speed);
            if (move != Vector3.zero)
                transform.forward = move;

        transform.Rotate(0, rotX, 0);
        eyes.transform.localRotation = Quaternion.Euler(rotY, 0, 0);


        movement = transform.rotation * movement;
        player.Move(movement * Time.deltaTime);


	}
}
