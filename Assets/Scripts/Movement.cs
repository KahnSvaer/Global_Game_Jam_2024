using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] float horizontalSpeed = 3000f;
    [SerializeField] float verticalThrust = 150f;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;

    float horizontalInput;

    bool isVerticalInput;
    

    [SerializeField]bool onGround;
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
        GroundCheck();
    }

    private void LeftRightMovement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        float horizontalVelocity =  horizontalInput * horizontalSpeed;
        rb.velocity = new Vector2(horizontalVelocity, rb.velocity.y);
        if(Mathf.Abs(horizontalInput)>0.2f ){
            if (onGround)
            {
                anim.Play("Walk2");
            }else {
                anim.Play("Idle");
            }
            ChangeDirection(horizontalInput/Mathf.Abs(horizontalInput));
        }else{
            anim.Play("Idle");
        }
    }

    private void Jump()
    {
        isVerticalInput = Input.GetButtonDown("Jump");
        if (isVerticalInput && onGround)
        {
            float forceY =  verticalThrust;
            rb.AddForce(new Vector2(0, forceY));
        }
    }

    void GroundCheck(){
        if(Physics2D.Raycast(groundCheck.position,Vector2.down,0.1f,groundLayer)){
            onGround = true;
        }else{
            onGround = false;
        }

    }
    public void ChangeDirection(float set){
        Vector3 tempScale = transform.localScale ;
        tempScale.x = set;
        transform.localScale = tempScale;

    }
    void OnTriggerEnter2D(Collider2D target){
        if(target.tag == "torso"){
            Debug.Log("0");
        }
        
    }
}
