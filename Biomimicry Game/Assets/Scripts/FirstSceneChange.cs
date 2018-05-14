using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstSceneChange : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        int levelNumber = SceneManager.GetActiveScene().buildIndex;

        if (Input.GetKeyDown(KeyCode.Space)) {
            SceneManager.LoadScene(levelNumber + 1);
        }
	}
}
