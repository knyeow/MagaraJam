using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float walkSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform footPos;

    private BoxCollider2D bc;
    private Rigidbody2D rb;
    private Animator anim;

    private float horizontal;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        bc = GetComponent<BoxCollider2D>();

        
    }

    void FixedUpdate()
    {
        horizontal = Input.GetAxis("Horizontal");


        Walk();
        XScale();
        

        if (Input.GetKey(KeyCode.Space)&&IsGrounded())
            Jump();

        anim.SetBool("onAir", !IsGrounded());

        Debug.Log(IsGrounded());
    }


    private bool IsGrounded()
    {
        if (Physics2D.BoxCast((footPos.position), new Vector2(bc.bounds.size.x, 0.1f), 0, Vector2.down, 0.2f, groundLayer))
            return true;
        else
            return false;

    }
    

    private void XScale()
    {

        if (horizontal != 0)
            transform.localScale = new Vector2(Mathf.Sign(horizontal) * Mathf.Abs(transform.localScale.x), transform.localScale.y);

    }

    private void Walk()
    {
        anim.SetBool("Walking", horizontal != 0 ? true : false);
        rb.velocity = new Vector2(horizontal * walkSpeed * Time.fixedDeltaTime, rb.velocity.y);

    }
    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x,jumpForce * Time.fixedDeltaTime);

    }
}
