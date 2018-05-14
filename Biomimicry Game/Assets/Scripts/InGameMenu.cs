using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour {

    bool Pause;
    bool Control;
    int controlScore;

    public GameObject pauseMenu;
    public GameObject controlMenu;
    public GameObject Player;

    public GameObject control1;
    public GameObject control2;
    public GameObject control3;
    public GameObject control4;


    void Update () {

        controlScore = Player.GetComponent<Jumping>().objectiveCounter;
        
        if (Pause == true)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }

        if (Pause == false && Control == false)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
        }
        if (Input.GetKeyDown(KeyCode.Escape) && Control == false)
        {
            Pause = !Pause;
        }
        if (Input.GetKeyDown(KeyCode.Escape) && Control == true)
        {
            Control = false;
            Pause = true;
        }


        if (Control == true)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 0f;
            controlMenu.SetActive(true);
        }
        if (Control == false)
        {
            controlMenu.SetActive(false);
        }
        if (controlScore == 0)
        {
            control1.SetActive(true);
            control2.SetActive(false);
            control3.SetActive(false);
            control4.SetActive(false);
        }
        if (controlScore == 1)
        {
            control1.SetActive(false);
            control2.SetActive(true);
            control3.SetActive(false);
            control4.SetActive(false);
        }
        if (controlScore == 2)
        {
            control1.SetActive(false);
            control2.SetActive(false);
            control3.SetActive(true);
            control4.SetActive(false);
        }
        if (controlScore == 3)
        {
            control1.SetActive(false);
            control2.SetActive(false);
            control3.SetActive(false);
            control4.SetActive(true);
        }
    }
    public void Return()
    {
        Pause = false;
        Control = false;
        Time.timeScale = 1f;
    }

    public void Controls()
    {
        Pause = false;
        Control = true;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
