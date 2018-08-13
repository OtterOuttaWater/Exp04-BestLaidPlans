using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS_Controller : MonoBehaviour {


    public float mouseSensitivity = 3f, moveSpeed = 3f;
    public GameObject eyes;


    private float moveFB, moveLR, rotX, rotY, vertVelocity;
    public float jumpForce = 2f;
    private CharacterController player;

    private bool hasJumped;

	// Use this for initialization
	void Start () {

        player = GetComponent<CharacterController>();
        Cursor.visible = false;

    }

    void FixedUpdate()
    {
        if (Input.GetButtonDown("Jump"))
        {
            hasJumped = true;
        }

        ApplyGravity();
    }

    // Update is called once per frame
    void Update ()
    {
        Movement();
	}


    void Movement()
    {
        moveFB = Input.GetAxis("Vertical") * moveSpeed;
        moveLR = Input.GetAxis("Horizontal") * moveSpeed;

        rotX = Input.GetAxis("Mouse X") * mouseSensitivity;
        rotY -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        rotY = Mathf.Clamp(rotY, -60f, 60f);

        Vector3 movement = new Vector3(moveLR, vertVelocity, moveFB);

        transform.Rotate(0, rotX, 0);

        movement = transform.rotation * movement;

        eyes.transform.localRotation = Quaternion.Euler(rotY, 0, 0);

        player.Move(movement * Time.deltaTime);
    }


    private void Jump()
    {
        vertVelocity = jumpForce;
        hasJumped = true;
    }

    private void ApplyGravity()
    {
        if (player.isGrounded == true)
        {
            if (hasJumped == false)
            {
                vertVelocity = Physics.gravity.y;
            }
            else
            {
                vertVelocity = jumpForce;
            }
        }
        else
        {
            vertVelocity += Physics.gravity.y * Time.deltaTime;
            vertVelocity = Mathf.Clamp(vertVelocity, -50f, jumpForce);
            hasJumped = false;
        }
    }
}