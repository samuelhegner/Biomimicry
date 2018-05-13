﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Camouflage: MonoBehaviour
{
    Color color;
    public KeyCode change;
    public int abilitypower;
    public bool isInvisible;
    public bool inProgress = false;
    public GameObject player;
    public GameObject Main;
    Animator anim;
    AudioSource BiteSFX;
    int midAir;

    public Text abilityScore;

    void Start()
    {
        BiteSFX = GetComponent<AudioSource>();
        color = GetComponent<Renderer>().material.color;
        anim = GetComponentInParent<Animator>();
    }
    private void Update()
    {
        midAir = Main.GetComponent<Jumping>().jumpCount;
        if (DayTimeTracker.daytime == true)
        {
            abilityScore.text = "Stealth Left: " + (abilitypower + 59) / 60;
        }
        if (DayTimeTracker.daytime == false)
        {
            abilityScore.text = "Stealth stored for day: " + (abilitypower + 59) / 60;
        }
        if (Input.GetKeyDown(change) && midAir < 1)
        {
            if (isInvisible == true && inProgress == false)
            {
                inProgress = true;
                isInvisible = false;
            }
            else if (isInvisible == false && inProgress == false && abilitypower > 0)
            {
                inProgress = true;
                isInvisible = true;
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
        if (abilitypower <= 0)
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
        }
    }
}
