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

        if (canJump) {
            jumpCount = 0;
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
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Objective")
        {
            objectiveCounter++;
        }
    }
}

