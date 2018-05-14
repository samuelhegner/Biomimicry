using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public void Return()
    {
        Pause = !Pause;
        Time.timeScale = 1f;
    }

    public void Controls()
    {
        pauseMenu.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
