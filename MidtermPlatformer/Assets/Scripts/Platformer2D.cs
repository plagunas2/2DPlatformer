using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Platformer2D : MonoBehaviour
{
    public float speed = 8;
    public float jumpForce = 24;    
    public Transform groundCheck;
    public bool isFacingRight = true;
    Rigidbody2D rb;
    float horizontal;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        //Flip();
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    bool IsGrounded()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, 0.2f);
        if (colliders.Length > 1) // my collider and ground collider
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void Flip()
    {
        if (isFacingRight == true && horizontal < 0f || isFacingRight == false && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }
    }
}

