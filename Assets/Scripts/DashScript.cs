using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This would be placed on the child of parent on the dashing element
public class DashScript : MonoBehaviour
{
    [SerializeField] float forceConstant = 10;
    [SerializeField] [Range(0.1f,3f)] float dashTime = 0.3f;
    [SerializeField] [Range(0f,100f)] int RechargeTime = 10; 
    [SerializeField] bool isDash = true;
    Rigidbody2D rb;
    private void Start() {
        rb = GetComponentInParent<Rigidbody2D>();
    }

    private void Update() {
        ProcessDash();
    }

    private void ProcessDash()
    {
        if(Input.GetButtonDown("Fire1") && isDash)
        {
            StartCoroutine(DashCoroutine());
        }
    }

    private IEnumerator DashCoroutine()
    {
        Vector2 velocityDirection = rb.velocity.normalized;
        rb.velocity = forceConstant * velocityDirection;
        Debug.Log(velocityDirection.magnitude);
        isDash = false;
        GetComponentInParent<Movement>().enabled = false;
        rb.gravityScale = 0;
        yield return new WaitForSeconds(dashTime);
        GetComponentInParent<Movement>().enabled = true;
        rb.gravityScale = 1;
        yield return new WaitForSeconds(RechargeTime);
        isDash = true;
    }
}
