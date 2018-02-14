using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseAIMovement : MonoBehaviour {

    private bool moving;
    private bool idle;
    public GameObject Mouse;
    public bool startled;
    float xMovement;
    float rnd = 0;
    float xScale;
    float tick;

    void Start () {
        moving = true;
        xMovement = -0.02f;
        xScale = this.transform.localScale.x;
    }
	
	void Update () {
        StartCoroutine("Timer");
        if (moving == true)
        {
            Mouse.transform.position = transform.position + new Vector3(xMovement,0,0);
            Mouse.transform.localScale = new Vector3(xScale, this.transform.localScale.y, this.transform.localScale.y);
        }
        if (startled == true)
        {
            Mouse.transform.position = transform.position + new Vector3(xMovement*8, 0, 0);
        }
        if (this.tag == "Startled")
        {
            moving = false;
            startled = true;
        }
	}
    void Timer()
    {
        tick += Time.deltaTime;
        if (tick >= 1)
        {
            rnd = Random.Range(0, 4);
            print(rnd);
            if (rnd == 1)
            {
                xMovement = -xMovement;
                xScale = -xScale;
            }
            tick = 0;
        }
    }
}
