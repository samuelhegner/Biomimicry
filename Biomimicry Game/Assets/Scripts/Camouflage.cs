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
    public bool inProgress;

    public Text abilityScore;

    private void Start()
    {
        color = GetComponent<Renderer>().material.color;
    }
    private void Update()
    {
        abilityScore.text = "Stealth Left: " + abilitypower;
        if (Input.GetKey(change))
        {
            if (isInvisible == true && inProgress == false)
            {
                isInvisible = false;
                inProgress = true;
            }
            else if (isInvisible == false && inProgress == false && abilitypower > 0)
            {
                isInvisible = true;
                inProgress = true;
            }
        }
        if (isInvisible == true)
        {
            GetComponent<Renderer>().material.SetColor("_Color", color);
            abilitypower -= 1;
            if (color.a >= 0)
            {
                color.a -= 0.03f;
            }
        }
        if (isInvisible == false && color.a <= 1)
        {
            GetComponent<Renderer>().material.SetColor("_Color", color);
            color.a += 0.05f;
        }
        if (color.a >= 0.999 || color.a <= 0.001)
        {
            inProgress = false;
        }
        if (abilitypower <= 0)
        {
            isInvisible = false;
            abilitypower = 0;
        }
    }
}
