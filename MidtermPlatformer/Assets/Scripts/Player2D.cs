using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2D : MonoBehaviour
{
    public float speed = 10f;
    public float jumpForce = 10f;
    Rigidbody2D rb;

    [Header("Grounding")]
    public LayerMask groundMask;
    public float groundRayLength = 0.1f;
    public float groundRaySpread = 0.1f;

    public bool grounded = true; //return to this! false


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //UpdateGrounding(); //come back to this

       // Vector3 dir = transform.position;
        //dir.x = Input.GetAxis("Horizontal") + speed * Time.deltaTime;
        // transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
        //transform.position = dir * speed;
        
        Vector2 vel = rb.velocity;

        vel.x = Input.GetAxis("Horizontal") * speed;

        if (Input.GetButtonDown("Jump") ) //&& grounded
        {
            //rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            vel.y = jumpForce;
        }

        rb.velocity = vel;

    }

    void UpdateGrounding()
    {

        Vector3 rayStart = transform.position + Vector3.up * groundRayLength;
        Vector3 rayStartLeft = transform.position + Vector3.up * groundRayLength + Vector3.left * groundRaySpread;
        Vector3 rayStartRight = transform.position + Vector3.up * groundRayLength + Vector3.right * groundRaySpread;


        RaycastHit2D hit = Physics2D.Raycast(rayStart, Vector3.down, groundRayLength * 2, groundMask);
        RaycastHit2D hitLeft = Physics2D.Raycast(rayStartLeft, Vector3.down, groundRayLength * 2, groundMask);
        RaycastHit2D hitRight = Physics2D.Raycast(rayStartRight, Vector3.down, groundRayLength * 2, groundMask);

        Debug.DrawLine(rayStart, rayStart + Vector3.down * 0.1f, Color.red);
        Debug.DrawLine(rayStartLeft, rayStartLeft + Vector3.down * 0.1f, Color.red);
        Debug.DrawLine(rayStartRight, rayStartRight + Vector3.down * 0.1f, Color.red);

        if (hit.collider != null || hitLeft.collider != null || hitRight.collider != null) {
            grounded = true;
        } else
        {
            grounded = false; //change to false
        }
    }
}
