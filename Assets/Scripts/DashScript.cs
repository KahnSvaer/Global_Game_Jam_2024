// using System;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// //This would be placed on the child of parent on the dashing element
// public class DashScript : MonoBehaviour
// {
//     [SerializeField] float forceConstant = 10;
//     [SerializeField] [Range(0.1f,3f)] float dashTime = 0.3f;
//     // [SerializeField] [Range(0f,100f)] int RechargeTime = 10; 
//     [SerializeField] bool isDash = true;

//     [SerializeField] Animator anime;

//     Rigidbody2D rb;
//     private void Start() {
//         rb = GetComponentInParent<Rigidbody2D>();
//     }

//     private void Update() {
//         ProcessDash();
//         if(GetComponentInParent<Movement>().OnGround)
//         {
//             isDash = true;
//         }
//     }

//     private void ProcessDash()
//     {
//         if(Input.GetButtonDown("Fire1") && isDash)
//         {
//             StartCoroutine(DashCoroutine());
//         }
//     }

//     private IEnumerator DashCoroutine()
//     {
//         Vector2 velocityDirection = rb.velocity.normalized;
//         rb.velocity = forceConstant * velocityDirection;
//         Debug.Log(velocityDirection.magnitude);
//         GetComponentInParent<Movement>().enabled = false;
//         isDash = false;
//         anime.Play("Idle");
//         rb.gravityScale = 0;
//         yield return new WaitForSeconds(dashTime);
//         GetComponentInParent<Movement>().enabled = true;
//         rb.gravityScale = 1;
//         // yield return new WaitForSeconds(RechargeTime);
//         // isDash = true;
//     }
// }
using System.Collections;
using UnityEngine;

public class DashScript : MonoBehaviour
{
    [SerializeField] float forceConstant = 10;
    [SerializeField] [Range(0.1f, 3f)] float dashTime = 0.3f;
    [SerializeField] bool isDash = true;
    [SerializeField] Animator anime;

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponentInParent<Rigidbody2D>();
    }

    private void Update()
    {
        ProcessDash();
        if (GetComponentInParent<Movement>().OnGround)
        {
            isDash = true;
        }
    }

    private void ProcessDash()
    {

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (Input.GetButtonDown("Fire1") && isDash)
        {
            StartCoroutine(DashCoroutine(horizontalInput, verticalInput));
        }
    }

    private IEnumerator DashCoroutine(float horizontalInput, float verticalInput)
    {

        Vector2 dashDirection = new Vector2(horizontalInput, verticalInput).normalized;


        if (dashDirection == Vector2.zero)
        {
            dashDirection = rb.velocity.normalized;
        }


        rb.velocity = forceConstant * dashDirection;

        GetComponentInParent<Movement>().enabled = false;
        isDash = false;
        anime.Play("Idle");
        rb.gravityScale = 0;

        yield return new WaitForSeconds(dashTime);

        GetComponentInParent<Movement>().enabled = true;
        rb.gravityScale = 1.69f;

    }
}
