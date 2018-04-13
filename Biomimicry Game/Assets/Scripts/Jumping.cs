using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour
{
    public bool canJump;
    int jumpAmount = 0;
    int jumpLimit;
    public KeyCode jumpKey;
	public GameObject groundcheck;
    Rigidbody2D rb;
    public float jumpHeight = 200;

    void Start()
    {
        jumpLimit = 0;
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
		canJump = groundcheck.GetComponent<Groundcheck> ().canJump;
        if (Input.GetKeyDown(jumpKey) && canJump == true && Unlock.collectible1 == true && jumpAmount <= jumpLimit)
        {
            rb.AddForce(transform.up * jumpHeight);
            if (Input.GetKeyDown(jumpKey) && jumpAmount < jumpLimit)
            {
                rb.AddForce(transform.up * jumpHeight);
            }
       } 
    }
	
}

