using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlantDetection : MonoBehaviour {


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && DayTimeTracker.daytime == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {

        }
    }
}
