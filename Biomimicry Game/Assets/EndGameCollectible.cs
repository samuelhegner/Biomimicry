using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameCollectible : MonoBehaviour {


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Untagged")
        {
            collision.gameObject.GetComponent<Movement>().score++;
            print(collision.gameObject.GetComponent<Movement>().score);
            this.gameObject.SetActive(false);
        }
    }
}
