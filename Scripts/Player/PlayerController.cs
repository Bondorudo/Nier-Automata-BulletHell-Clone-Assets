﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody myRigidbody;
    private Camera mainCamera;
    [SerializeField] private ParticleSystem movementParticles;
    [SerializeField] private float moveSpeed;

    private Vector3 moveInput;
    private Vector3 moveVelocity;
    

    void Start()
    {
        mainCamera = FindObjectOfType<Camera>();
        myRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Rotation();


        if (myRigidbody.velocity != Vector3.zero)
        {
            if (!movementParticles.isPlaying) movementParticles.Play();
        }
        else
        {
            if (movementParticles.isPlaying) movementParticles.Stop();
        }
    }

    private void FixedUpdate()
    {
        myRigidbody.velocity = moveVelocity;
    }

    public void Movement()
    {
        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * moveSpeed;
    }

    public void Rotation()
    {
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if (groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);

            transform.Rotate(0f, 45f, 0f, Space.World);
            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }
    }
}
    
