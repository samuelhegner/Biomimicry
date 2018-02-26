using System.Collections;
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

    public Text abilityScore;

    private void Start()
    {
        color = GetComponent<Renderer>().material.color;
    }
    private void Update()
    {
<<<<<<< HEAD
        abilityScore.text = "Stealth Left: " + (abilitypower + 59) / 60;
=======
        abilityScore.text = "Stealth stored for night: " + (abilitypower + 59) / 60;
>>>>>>> ef4244912d41de01c73265d945a4e2e0fe2e82b7
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
            abilitypower -= 1;
            player.tag = "Stealthed";
            if (color.a >= 0)
            {
                color.a -= 0.03f;
            }
        }
        if (isInvisible == false && color.a <= 1.1)
        {
            GetComponent<Renderer>().material.SetColor("_Color", color);
            player.tag = "Unstealthed";
			if (color.a <= 1)
			{
				color.a += 0.1f;
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "NPC")
        {
            collision.gameObject.SetActive(false);
        }
    }
}
