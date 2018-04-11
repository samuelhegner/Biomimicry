using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseAIMovement : MonoBehaviour {


    float xMovement;
    float displacement = 0.2f;
    float rnd = 0;
    float rnd2 = 0;
    float tick;
    float tick2;
    Transform playerTransform;
    float mousetimer1 = 0;
    float mousetimer2 = 0;
    Animator anim;



    public enum BehaviourState
    {
        moving,
        idle,
        startled,
    }

    public BehaviourState currentState;

    void Start () {
        currentState = BehaviourState.moving;
        xMovement = 0.02f;
        Invoke("Timer", 0);
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
        anim = GetComponent<Animator>();
    }
	
	void Update () {

        if (xMovement < 0)
        {
            anim.SetBool("FacingRight", false);
        }
        else if (xMovement > 0) {
            anim.SetBool("FacingRight", true);
        }

        if (DayTimeTracker.daytime == false)
        {
            if (this.tag == "Startled")
            {
                currentState = BehaviourState.startled;
            }
            if (currentState == BehaviourState.moving)
            {
                Invoke("Timer", 0);
                this.transform.position = transform.position + new Vector3(xMovement, 0, 0);
                anim.SetBool("Walking", true);
                anim.SetBool("Running", false);
            }
            if (currentState == BehaviourState.startled)
            {

                if (this.transform.position.x < playerTransform.position.x)
                {

                    if (mousetimer1 <= 0.5)
                    {
                        xMovement = -0.2f;
                        this.transform.position = transform.position + new Vector3(xMovement, 0, 0);
                        anim.SetBool("Running", true);
                        anim.SetBool("Walking", false);

                    }
                    if (mousetimer1 > 0.5)
                    {
                        currentState = BehaviourState.idle;
                        mousetimer1 = 0;
                        this.tag = "NPC";
                    }
                }
                else if (this.transform.position.x > playerTransform.position.x)
                {
                    if (mousetimer1 <= 0.5)
                    {
                        xMovement = 0.2f;
                        this.transform.position = transform.position + new Vector3(xMovement, 0, 0);
                        anim.SetBool("Running", true);
                        anim.SetBool("Walking", false);

                    }
                    if (mousetimer1 > 0.5)
                    {
                        currentState = BehaviourState.idle;
                        mousetimer1 = 0;
                        this.tag = "NPC";
                    }
                }
                mousetimer1 += Time.deltaTime;
            }

            if (currentState == BehaviourState.idle)
            {
                Idle();
                anim.SetBool("Walking", false);
                anim.SetBool("Running", false);
            }
        }
        if(DayTimeTracker.daytime == true)
        {
            this.gameObject.SetActive(false);
        }
	}
    void Timer()
    {
        tick += Time.deltaTime;
        if (tick >= 1)
        {
            rnd = Random.Range(0, 6);
            if (rnd >= 4)
            {
                xMovement = -xMovement;
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
        if (xMovement > 0)
        {
            xMovement = 0.02f;
        }
        else if (xMovement < 0) {
            xMovement = -0.02f;
        }
        tick2 += Time.deltaTime;
        if(tick2 >= 1)
        {
            rnd2 = Random.Range(0, 4);
            if (rnd2 == 3)
            {
                currentState = BehaviourState.moving;         
            }
            tick2 = 0;
        }
    }
}
