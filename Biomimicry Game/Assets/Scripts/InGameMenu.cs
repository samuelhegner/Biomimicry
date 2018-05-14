using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMenu : MonoBehaviour {

    bool Pause;

    public GameObject pauseMenu;
	
	void Update () {

        if (Pause == true)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }

        if (Pause == false)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause = !Pause;
        }
	}
}
