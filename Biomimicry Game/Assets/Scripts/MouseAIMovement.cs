using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseAIMovement : MonoBehaviour {

    public GameObject Mouse;
    float speed = 0.02f;
    float xMovement;
    float rnd = 0;
    float rnd2 = 0;
    float xScale;
    float tick;
    float tick2;

    public enum BehaviourState
    {
        moving,
        idle,
        startled,
    }

    public BehaviourState currentState;

    void Start () {
        currentState = BehaviourState.moving;
        xMovement = speed;
        xScale = this.transform.localScale.x;
    }
	
	void Update () {
        StartCoroutine("Timer");
        if (currentState == BehaviourState.moving)
        {
            speed = 0.02f;
            Mouse.transform.position = transform.position + new Vector3(xMovement,0,0);
            Mouse.transform.localScale = new Vector3(-xScale, this.transform.localScale.y, this.transform.localScale.z);
        }
        if (currentState == BehaviourState.startled)
        {
            Mouse.transform.position = transform.position + new Vector3(xMovement*8, 0, 0);
        }
        if (currentState == BehaviourState.idle)
        {
            StopCoroutine("Timer");
            StartCoroutine("Idle");
            speed = 0;
        }
        if (this.tag == "Startled")
        {
            currentState = BehaviourState.startled;
        }
	}
    void Timer()
    {
        tick += Time.deltaTime;
        if (tick >= 1)
        {
            rnd = Random.Range(0, 6);
            print(rnd);
            if (rnd >= 4)
            {
                xMovement = -xMovement;
                xScale = -xScale;
            }
            if (rnd == 2)
            {
                currentState = BehaviourState.idle;
            }
            tick = 0;
        }
    }
    void Idle()
    {
        tick2 += Time.deltaTime;
        if(tick2 >= 1)
        {
            rnd2 = Random.Range(0, 4);
            print(rnd2);
            if (rnd == 3)
            {
                currentState = BehaviourState.moving;
                StartCoroutine("Timer");
                StopCoroutine("Idle");          
            }
            if (rnd < 3)
            {
                print("nope");
            }
            tick = 0;
        }
    }
}
