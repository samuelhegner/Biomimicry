using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proximity : MonoBehaviour {

    public bool Playernear;
    AudioSource cricketChirps;
    // Use this for initialization
    void Start () {
        cricketChirps = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            cricketChirps.Play();
            Playernear = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            cricketChirps.Pause();
            Playernear = false;
        }
    }
}
