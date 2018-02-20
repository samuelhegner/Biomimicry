using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour
{
    public bool canJump;
    public KeyCode jumpKey;
    Rigidbody2D rb;
    public float jumpHeight = 200;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        canJump = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(jumpKey) && canJump == true)
        {
            rb.AddForce(transform.up * jumpHeight);
       } 
    }
	
}
