using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour
{
    public bool canJump;
    public KeyCode jumpKey;
	public GameObject groundcheck;
    Rigidbody2D rb;
    public float jumpForce = 200;
    int objectiveCounter = 0;
    int jumpCount;
    int jumpMax;
    public float secondJumpDeducter;
    float glideAmount = 3;

    float starterGravityScale;
 
    bool unlock1 = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpCount = 0;
        jumpMax = 1;
        starterGravityScale = rb.gravityScale;
    }
    private void Update()
    {
		canJump = groundcheck.GetComponent<Groundcheck> ().canJump;
        if (canJump) {
            jumpCount = 0;
            glideAmount = 3;
        }

        if (Input.GetKeyDown(jumpKey) && unlock1 == true && jumpCount < jumpMax)
        {
            if (jumpCount == 0 && canJump)
            {
                rb.velocity = new Vector2(rb.velocity.x, 0f);
                rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
                jumpCount++;
                print(jumpCount);

            }else if (jumpCount == 1 && !canJump)
            {
                rb.velocity = new Vector2(rb.velocity.x, 0f);
                rb.AddForce(transform.up * (jumpForce - secondJumpDeducter), ForceMode2D.Impulse);
                jumpCount++;
                print(jumpCount);

            }
        }

        if (jumpCount == 2 && !canJump)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                rb.gravityScale = 0.0f;
                rb.velocity = new Vector2(rb.velocity.x, -4f);
            }
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            rb.gravityScale = starterGravityScale;
        }




        if (objectiveCounter >= 1)
        {
            unlock1 = true;
        }
        if (objectiveCounter >= 2)
        {
            jumpMax = 2;
        }

        if (objectiveCounter >= 3) {
            jumpMax = 3;
        }

        if (objectiveCounter >= 4)
        {
            objectiveCounter = 3;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Objective")
        {
            objectiveCounter++;
            Destroy(collision.gameObject);
        }
    }
}

