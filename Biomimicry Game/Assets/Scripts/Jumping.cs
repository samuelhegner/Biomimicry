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

    bool unlock1 = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
		canJump = groundcheck.GetComponent<Groundcheck> ().canJump;
        if (Input.GetKeyDown(jumpKey) && unlock1 == true && canJump == true)
        {
            rb.AddForce(transform.up * jumpHeight);           
       }
        if (objectiveCounter >= 1)
        {
            unlock1 = true;
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

