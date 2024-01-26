using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    [SerializeField] float horizontalSpeed = 3000f;
    [SerializeField] float verticalThrust = 150f;

    float horizontalInput;
    public float HorizontalInput{get{return horizontalInput;}}

    bool isVerticalInput;
    public bool IsVerticalInput{get{return isVerticalInput;}}

    bool onGround;
    public bool OnGround{get{return onGround;}}
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
        rb.velocity = new Vector2(horizontalVelocity, rb.velocity.y);
    }

    private void Jump()
    {
        isVerticalInput = Input.GetButtonDown("Jump");
        if (isVerticalInput && onGround)
        {
            float forceY =  verticalThrust;
            rb.AddForce(new Vector2(0, forceY));
            onGround = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        onGround = true;
    }
}
