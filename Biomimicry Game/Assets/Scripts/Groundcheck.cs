using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Groundcheck : Jumping {

    private void OnTriggerStay2D(Collider2D collision)
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
