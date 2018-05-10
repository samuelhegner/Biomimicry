using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlantDetection : MonoBehaviour {

    public GameObject animator;

    GameObject player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            player = collision.gameObject;
            Invoke("KillPlayer", 0.2f);
            Invoke("ReloadScene", 4);
            animator.GetComponent<Animator>().SetTrigger("Pressure");
        }
        else
        {

        }
    }

    void ReloadScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void KillPlayer() {
        Destroy(player.transform.GetChild(0).gameObject);
    }
}
