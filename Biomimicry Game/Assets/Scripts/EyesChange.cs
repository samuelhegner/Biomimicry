using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyesChange : MonoBehaviour {

    public GameObject Body;
    SpriteRenderer spriteRenderer;
    float ability;
    
    Color color;

	// Use this for initialization
	void Start () {
        color = GetComponent<Renderer>().material.color;       
    }
	
	// Update is called once per frame
	void Update () {
        ability = Body.GetComponent<Camouflage>().abilitypower;
        GetComponent<Renderer>().material.SetColor("_Color", color);
        if (Body.tag == "Stealthed")
        {
            print("test");
            if (color.r > 0)
            {
                color.r = ability / 600;
                print(ability / 600);
            }
        }
	}
}
