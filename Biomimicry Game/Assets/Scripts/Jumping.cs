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
    public int jumpCount;
    int jumpMax;
    public float secondJumpDeducter;
    float glideAmount = 3;

    public GameObject leg1, leg2, wing;

    float starterGravityScale;

    public GameObject smokePuff;
 
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
        GetComponent<Animator>().SetInteger("Upgrade", objectiveCounter);
        GetComponent<Animator>().SetBool("Grounded", canJump);

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
                GetComponent<Animator>().SetTrigger("Jump");

            }else if (jumpCount == 1 && !canJump)
            {
                rb.velocity = new Vector2(rb.velocity.x, 0f);
                rb.AddForce(transform.up * (jumpForce - secondJumpDeducter), ForceMode2D.Impulse);
                jumpCount++;
                GetComponent<Animator>().SetTrigger("Jump");
            }
        }

        if (jumpCount == 2 && !canJump)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                rb.gravityScale = 0.0f;
                rb.velocity = new Vector2(rb.velocity.x, -4f);
                GetComponent<Animator>().SetBool("Glide", true);
            }
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            rb.gravityScale = starterGravityScale;
            GetComponent<Animator>().SetBool("Glide", false);
        }




        if (objectiveCounter >= 1)
        {
            unlock1 = true;
            leg1.SetActive(true);
            leg2.SetActive(true);
        }
        if (objectiveCounter >= 2)
        {
            jumpMax = 2;
            wing.SetActive(true);
        }

        if (objectiveCounter >= 3) {
            jumpMax = 3;
        }

        if (objectiveCounter >= 4)
        {
            objectiveCounter = 3;
        }

        GetComponent<Animator>().SetInteger("JumpCount", jumpCount);

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Objective")
        {
            objectiveCounter++;
            Destroy(collision.gameObject);
            Instantiate(smokePuff, transform.position, transform.rotation);
        }
    }
}

