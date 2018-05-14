using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LastSceneChange : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        int levelNumber = 0;

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(levelNumber);
        }
    }
}
