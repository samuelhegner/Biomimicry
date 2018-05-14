using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlantDetection : MonoBehaviour {

    public GameObject animator;

    public GameObject bloodSplat;

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
        if (collision.tag == "StealthHunter")
        {
            animator.GetComponent<Animator>().SetTrigger("Pressure");
            Destroy(collision.gameObject);
        }
        else
        {

        }
    }

    void ReloadScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void KillPlayer() {
        for (int i = 0; i < player.transform.childCount; i++) {
            if (player.transform.GetChild(i).name != "Main Camera") {
                player.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
        Instantiate(bloodSplat, transform.position, transform.rotation);
        player.GetComponent<Jumping>().enabled = false;
        player.GetComponent<Movement>().enabled = false;
    }
}
