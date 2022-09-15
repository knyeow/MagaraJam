using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float walkSpeed;

    private Rigidbody2D rb;

    private float horizontal;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        
    }

    void FixedUpdate()
    {
        horizontal = Input.GetAxis("Horizontal");


        Walk();
        XScale();
    }

    private void XScale()
    {

        if (horizontal != 0)
            transform.localScale = new Vector2(Mathf.Sign(horizontal) * Mathf.Abs(transform.localScale.x), transform.localScale.y);

    }

    private void Walk()
    {
        rb.velocity = new Vector2(horizontal * walkSpeed, rb.velocity.y);

    }
}
