using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    [SerializeField] float horizontalSpeed = 3000f;
    [SerializeField] float verticalSpeed = 50f;

    float horizontalInput;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        LeftRightMovement();
        Jump();
    }

    private void LeftRightMovement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        float horizontalVelocity =  horizontalInput * Time.deltaTime * horizontalSpeed;
        rb.velocity = new Vector2(horizontalVelocity ,rb.velocity.y);
    }

    private void Jump()
    {
        
    }
}
