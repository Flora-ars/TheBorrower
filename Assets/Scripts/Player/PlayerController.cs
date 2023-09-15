using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class PlayerController : MonoBehaviour
{
    // movement var
    [SerializeField] float movementSpeed = 3;
    [SerializeField] private float turnSpeed = 50;
    private Rigidbody myRb;

    //animation var
    private Animator _animator;
    private const string SPEED_F = "Speed_f";
    private float valueSpeedF = 0.01f;
    private const string STATIC_B = "Static_b";
    private bool isStatic = true;


    void Start()
    {
        myRb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _animator.SetFloat(SPEED_F, valueSpeedF);
        _animator.SetBool(STATIC_B, isStatic);
    }

    private void Update()
    {
        AnimationPlayer();
    }

    private void FixedUpdate()
    {
        ControlMovement();
    }
    void ControlMovement()
    {

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput);
        myRb.velocity = moveDirection * movementSpeed;

        if (moveDirection != Vector3.zero)
        {
            Quaternion rotateDirection = Quaternion.LookRotation(moveDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotateDirection, turnSpeed);
        }

        /*float rotationAngle = (turnSpeed * horizontalInput * Time.deltaTime);
        Vector3 rotateDirection = Vector3.up * rotationAngle;
        
        transform.rotation = Quaternion.LookRotation(moveDirection) * Quaternion.Euler(rotateDirection);*/

    }

    void AnimationPlayer()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow)
            || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            valueSpeedF = 1.0f;
            _animator.SetFloat(SPEED_F, valueSpeedF);
            isStatic = false;
            _animator.SetBool(STATIC_B, isStatic);
        }
        else
        {
            valueSpeedF = 0.01f;
            _animator.SetFloat(SPEED_F, valueSpeedF);
            isStatic = true;
            _animator.SetBool(STATIC_B, isStatic);
        }
    }
}

