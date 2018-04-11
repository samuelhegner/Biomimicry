using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameCollectible : MonoBehaviour {


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Untagged")
        {
            this.gameObject.SetActive(false);
        }
    }
}
