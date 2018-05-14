using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burrow : MonoBehaviour {

    int maxTotal;
    float tick;
    public bool PlayerPresent;
    public Transform mouse;
    Vector3 spawn;
    int rnd;
    AudioSource MiceSqueaking;

	void Start () {
        MiceSqueaking = GetComponent<AudioSource>();
        spawn = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        rnd = Random.Range(4, 8);       
	}
	
	void Update () {
		if(PlayerPresent == false && DayTimeTracker.daytime == false)
        {
            Invoke("Timer", 0);
        }
	}

    void Timer()
    {
        tick += Time.deltaTime;
        if (tick >= 3)
        {
            if (maxTotal <= rnd)
            {
                Instantiate(mouse, spawn, Quaternion.identity);
                maxTotal ++;
            }
            tick = 0;
        }  
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (DayTimeTracker.daytime == true && collision.tag == "Mouse")
        {
            maxTotal = 0;
        }
        if (collision.tag == "Player")
        {
            MiceSqueaking.Play();
        }   
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerPresent = true;
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerPresent = false;
            MiceSqueaking.Pause();
        }
    }
}
