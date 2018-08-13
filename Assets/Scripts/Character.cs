 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float Speed = 5f;
    public float JumpHeight = 2f;
    public float Gravity = -9.81f;
    public float GroundDistance = 0.2f;
    public float sensitivity = 2f;

    public LayerMask Ground;
    public Vector3 Drag;

    public GameObject eyes;

    private CharacterController _controller;
    private Vector3 _velocity;
    private bool _isGrounded = true;
    private Transform _groundChecker;

    private float _rotX;
    private float _rotY;



    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _groundChecker = transform.GetChild(0);
        Cursor.visible = false;
    }

    void Update()
    {
        _isGrounded = Physics.CheckSphere(_groundChecker.position, GroundDistance, Ground, QueryTriggerInteraction.Ignore);
        if (_isGrounded && _velocity.y < 0)
            _velocity.y = 0f;

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        _controller.Move(move * Time.deltaTime * Speed);
        //if (move != Vector3.zero)
        //transform.forward = move;

        _rotX = Input.GetAxis("Mouse X") * sensitivity;
        _rotY -= Input.GetAxis("Mouse Y") * sensitivity;
        _rotY = Mathf.Clamp(_rotY, -60f, 60f);   //Keeps you from going upside down

        transform.Rotate(0, _rotX, 0);
        eyes.transform.localRotation = Quaternion.Euler(_rotY, 0, 0);

        if (Input.GetButtonDown("Jump") && _isGrounded)
            _velocity.y += Mathf.Sqrt(JumpHeight * -2f * Gravity);


        _velocity.y += Gravity * Time.deltaTime;

        _velocity.x /= 1 + Drag.x * Time.deltaTime;
        _velocity.y /= 1 + Drag.y * Time.deltaTime;
        _velocity.z /= 1 + Drag.z * Time.deltaTime;

        _controller.Move(_velocity * Time.deltaTime);
    }

}
