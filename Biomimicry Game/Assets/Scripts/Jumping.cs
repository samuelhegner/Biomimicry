using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour
{
    public bool canJump;
    public KeyCode jumpKey;
	public GameObject groundcheck;
    Rigidbody2D rb;
    public float jumpHeight = 200;
    int objectiveCounter = 0;
    int jumpCount;
    int jumpMax;
    float glideAmount = 3;

    bool unlock1 = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpCount = 0;
        jumpMax = 1;
    }
    private void Update()
    {
		canJump = groundcheck.GetComponent<Groundcheck> ().canJump;
        print(glideAmount);
        if (canJump) {
            jumpCount = 0;
            glideAmount = 3;
        }

        if (Input.GetKeyDown(jumpKey) && unlock1 == true)
        {
            if (canJump == true || jumpCount < jumpMax)
            {
                rb.AddForce(transform.up * jumpHeight);
                jumpCount++;
            }
        }
        if (objectiveCounter >= 1)
        {
            unlock1 = true;
        }
        if (objectiveCounter >= 2)
        {
            jumpMax = 2;
        }
        if (objectiveCounter == 3 && jumpCount == 2 && Input.GetKey(jumpKey))
        {
            rb.AddForce(transform.up * glideAmount);
            if (glideAmount < 40)
            {
                glideAmount += 0.32f;
            }
        }
        if (objectiveCounter >= 4)
        {
            objectiveCounter = 3;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Objective")
        {
            objectiveCounter++;
            Destroy(collision.gameObject);
        }
    }
}

