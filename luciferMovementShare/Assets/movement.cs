using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pMovement : MonoBehaviour
{

    public float jumpForce;
    public Rigidbody2D rb;
    public float moveSpeed;
    private bool isjumping = false;
    private bool isRight = false;
    public float dashForce;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.x > 0)
        {
            isRight = true;

        }
        else if (rb.velocity.x < 0)
        {
            isRight = false;
        }


        if (Input.GetKeyDown(KeyCode.Space) && isjumping)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

            isjumping = false;


        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            rb.gravityScale = 8;
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            rb.gravityScale = 1;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {

            if (isRight)
            {
                rb.velocity = new Vector2(rb.velocity.x * dashForce, rb.velocity.y);
            }
            else if (!isRight)
            {
                rb.AddForce(Vector2.left * dashForce, ForceMode2D.Impulse);
            }
        }



    }

    private void FixedUpdate()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            isjumping = true;

        }
        if (collision.gameObject.tag == "bounds")
        {
            transform.position = new Vector2(2, 0);

        }
    }
}
