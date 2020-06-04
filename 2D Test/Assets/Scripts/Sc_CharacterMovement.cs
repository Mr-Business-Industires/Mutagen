﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_CharacterMovement : MonoBehaviour
{
    Rigidbody2D body;

    public bool controlled = false;
    GameObject parasiteRef;

    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;
    float runSpeed = 7.0f;
    public float smlSpeed = 30.0f;
    public float medSpeed = 30.0f;
    public float bigSpeed = 30.0f;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (controlled)
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");
            parasiteRef.transform.position = transform.position;
        }

    }

    private void FixedUpdate()
    {
        if (controlled)
        {
            if (horizontal != 0 && vertical != 0) // Check for diagonal movement
            {
                // limit movement speed diagonally, so you move at 70% speed
                horizontal *= moveLimiter;
                vertical *= moveLimiter;
            }
            body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
        }
    }


    public void StartControl (GameObject parasite)
    {
        controlled = true;
        parasiteRef = parasite;
    }

}