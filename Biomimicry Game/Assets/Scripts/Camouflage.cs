using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Camouflage: MonoBehaviour
{
    GameObject Portal;
    Color color;
    public KeyCode change;
    public int abilitypower;
    public int neededPrey;
    public bool isInvisible;
    public bool inProgress = false;
    public GameObject player;
    public GameObject Main;
    Animator anim;
    AudioSource BiteSFX;
    int midAir;
    public int enemiesEaten;

    public Text abilityScore;

    void Start()
    {
        Portal = GameObject.Find("EndLevel_SceneChanger");
        enemiesEaten = 0;
        BiteSFX = GetComponent<AudioSource>();
        color = GetComponent<Renderer>().material.color;
        anim = GetComponentInParent<Animator>();
    }
    private void Update()
    {
        neededPrey = Portal.GetComponent<SceneChange>().activateScore;
        midAir = Main.GetComponent<Jumping>().jumpCount;

        abilityScore.text = "Prey Eaten " + enemiesEaten + "/" + neededPrey;
        
        if (Input.GetKeyDown(change) && midAir < 1)
        {
            if (isInvisible == true && inProgress == false)
            {
                inProgress = true;
                isInvisible = false;
            }
            else if (isInvisible == false && inProgress == false)
            {
                if (DayTimeTracker.daytime == true && abilitypower > 0 || DayTimeTracker.daytime == false)
                {
                    inProgress = true;
                    isInvisible = true;
                }
            }
        }
        if (isInvisible == true)
        {
            GetComponent<Renderer>().material.SetColor("_Color", color);
            if (DayTimeTracker.daytime == true)
            {
                abilitypower -= 1;
            }
            player.tag = "Stealthed";
            if (color.a >= 0)
            {
                color.a -= 0.03f;
            }
        }
        if (isInvisible == false && color.a <= 1.05)
        {
            GetComponent<Renderer>().material.SetColor("_Color", color);
            player.tag = "Unstealthed";
			if (color.a <= 1)
			{
				color.a += 0.06f;
			}
        }
        if (color.a >= 1 || color.a <= -0.0)
        {
            inProgress = false;
        }
        if (abilitypower <= 0 && DayTimeTracker.daytime == true)
        {
            isInvisible = false;
            abilitypower = 0;
        }
        if (midAir > 0)
        {
            isInvisible = false;
        }
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "NPC")
        {
            BiteSFX.Play();
            isInvisible = false;
            anim.SetTrigger("Bite");         
            Destroy(collision.gameObject);
            if (abilitypower < 480)
            {
                abilitypower += 120;
            }
            if (abilitypower > 480)
            {
                abilitypower = 600;
            }
            enemiesEaten++;
        }
    }
}
