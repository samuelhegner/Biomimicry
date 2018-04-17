using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameCollectible : MonoBehaviour {

    public GameObject Player;
    private void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            this.gameObject.SetActive(false);
            Unlock.collectible1 = true;
        }
    }
}
public static class Unlock {
    public static bool collectible1 = false;
}

