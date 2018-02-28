using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Groundcheck : MonoBehaviour {
	public bool canJump;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "NPC" || collision.tag == "Ground")
        {
            canJump = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "NPC" || collision.tag == "Ground")
        {
            canJump = false;
        }
    }
}
