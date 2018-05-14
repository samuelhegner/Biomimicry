using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour {

    AudioSource audioSource;
    int levelNumber;
    int score;
    public int activateScore;
    public GameObject PlayerBody;
    bool canPlay;
    public AudioClip portal;
   
	// Use this for initialization
	void Start () { 
        levelNumber = SceneManager.GetActiveScene().buildIndex;
        audioSource = GetComponent<AudioSource>();
        activateScore = (levelNumber + 1);
	}
	
	// Update is called once per frame
	void Update () {
        print("Score" + score);
        print("LevelIndex" + levelNumber);
        score = PlayerBody.GetComponent<Camouflage>().enemiesEaten;
        if (score >= activateScore)
        {
            print("Ready");
            audioSource.PlayOneShot(portal);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && score >= activateScore)
        {
            SceneManager.LoadScene(levelNumber + 1);
        }
    }
}
