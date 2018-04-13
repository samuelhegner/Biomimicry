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
    Animator anim;

    public Text abilityScore;

    private void Start()
    {
        color = GetComponent<Renderer>().material.color;
        anim = GetComponentInParent<Animator>();
    }
    private void Update()
    {
        if (DayTimeTracker.daytime == true)
        {
            abilityScore.text = "Stealth Left: " + (abilitypower + 59) / 60;
        }
        if (DayTimeTracker.daytime == false)
        {
            abilityScore.text = "Stealth stored for day: " + (abilitypower + 59) / 60;
        }
        if (Input.GetKeyDown(change))
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
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "NPC")
        {
            isInvisible = false;
            anim.SetTrigger("Bite");
            collision.gameObject.SetActive(false);
            abilitypower += 60;
        }
    }
}
