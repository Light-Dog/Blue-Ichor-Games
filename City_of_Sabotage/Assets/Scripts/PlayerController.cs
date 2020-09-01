﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 20f;
    public float jumpSpeed = 25f;

    Rigidbody rb;

    bool jumping = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        walker();

        jumper();
    }

    void walker()
    {
        rb.velocity = new Vector3(0, rb.velocity.y, 0);

        float distance = walkSpeed * Time.deltaTime;

        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(xAxis * distance, 0f, yAxis * distance);
        Vector3 currentPos = transform.position;
        Vector3 newPosition = currentPos + movement;

        rb.MovePosition(newPosition);
    }

    void jumper()
    {
        float jumpAxis = Input.GetAxis("Jump");

        if(jumpAxis > 0f)
        {
            if(!jumping)
            {
                Vector3 jumpVec = new Vector3(0f, jumpSpeed, 0f);

                rb.velocity = rb.velocity + jumpVec;
                jumping = true;
            }


        }
        else
        {
            jumping = false;
        }
    }
}
