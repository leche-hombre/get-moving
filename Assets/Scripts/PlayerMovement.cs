﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed;
    public float gravity = -10f;
    public float jumpHeight = 3f;
    public CharacterController characterController;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public int maxJumpCount = 2;

    private Vector3 velocity;
    private bool isGrounded;
    private int jumpCount = 0;
    private float baseSpeed;

    private void Start()
    {
        baseSpeed = speed;
    }


    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2.0f;
            jumpCount = 0;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Add arbitrary limitation to speed so diagonal movement isn't faster
        speed = AdjustSpeed(x, z, baseSpeed);

        // Apply x and z transformations to player
        Vector3 move = transform.right * x + transform.forward * z;
        characterController.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && jumpCount < maxJumpCount)
        {
            Jump();
            jumpCount++;
        }

        // Apply constant gravity over time
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }

    void Jump()
    {
        velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
    }

    
    private float AdjustSpeed(float horizontalSpeed, float verticalSpeed, float _baseSpeed)
    {
        bool isDiagonalMovement = horizontalSpeed > 0 && verticalSpeed > 0;
        return isDiagonalMovement ? _baseSpeed / 2 : _baseSpeed;
    }
}
