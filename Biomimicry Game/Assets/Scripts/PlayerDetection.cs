using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour {


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Unstealthed")
        {
            this.tag = "Startled";
        }
    }
}
