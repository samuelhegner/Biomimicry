using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invisible : MonoBehaviour {

    public GameObject Body;
    SpriteRenderer spriteRenderer;
    Color color;
    // Use this for initialization
    void Start () {
        color = GetComponent<Renderer>().material.color;
    }
	
	// Update is called once per frame
	void Update () {
        GetComponent<Renderer>().material.SetColor("_Color", color);
        if (Body.tag == "Stealthed")
        {
            if (color.a > 0)
            {
                color.a -= 0.03f;
            }
        }
        if (Body.tag == "Unstealthed")
        {
            if (color.a <= 1)
            {
                color.a += 0.06f;
            }
        }
    }
}
