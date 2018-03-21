using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlantDetection : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Unstealthed" && DayTimeTracker.daytime == true)
        {
            Application.LoadLevel(Application.loadedLevel);
        }
        else
        {

        }
    }
}
