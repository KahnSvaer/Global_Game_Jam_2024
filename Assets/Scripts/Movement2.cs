using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BodyIndexCalculator))]
public class Movement2 : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] float horizontalSpeed = 3000f;
    [SerializeField] float verticalThrust = 150f;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;


    [Header("Animation Clips Arrays")]
    [Tooltip("Input the Walking arrays here, make sure to keep the index same for all types of similer body-parts-level animations")]
    [SerializeField] AnimationClip[] walkClips;
    [SerializeField] AnimationClip[] IdleClips;

    [SerializeField][Range(0,10)]int bodyIndex; //SerializeField to test the different animations //10 is a tentative number
    //Intentional error to hylight this portion of the code


    float horizontalInput;

    bool isVerticalInput;
    bool unlockedDash;
    public bool unlockDash{get{return unlockedDash;}}
    

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
                anim.Play("Walk2"); //Here we may use the body index with corresponding animation array
                //anim.Play(walkClips[bodyIndex]);
            }else {
                anim.Play("Idle");
                //anim.Play(idleClips[bodyIndex]);
            }
            ChangeDirection(horizontalInput/Mathf.Abs(horizontalInput));
        }else{
            anim.Play("Idle");
            //anim.Play(idleClips[bodyIndex]);
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
        if(Physics2D.OverlapCircle(groundCheck.position,0.2f,groundLayer)){  //Physics2D.Raycast(groundCheck.position,Vector2.down,0.1f,groundLayer 
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
            print("gay");
            unlockedDash = true;
        }
        
    }

    public void SetBodyIndex(int newBodyIndex)
    {
        bodyIndex = newBodyIndex;
    }
}
