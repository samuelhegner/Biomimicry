using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvolveAudio : MonoBehaviour {

    AudioSource audioSource;
    bool canPlay;
	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        canPlay = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (canPlay == true)
        {
            StartCoroutine(PlayAudio());
        }
    }
    IEnumerator PlayAudio()
    {
        audioSource.Play();
        canPlay = false;
        yield return new WaitForSeconds(audioSource.clip.length);
        Destroy(this.gameObject);
    }
}
