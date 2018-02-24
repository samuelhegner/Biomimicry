using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseAIMovement : MonoBehaviour {

    float speed = 0.02f;
    float xMovement;
    float displacement = 0.2f;
    float rnd = 0;
    float rnd2 = 0;
    float xScale;
    float tick;
    float tick2;
    Transform playerTransform;
    float mousetimer1 = 0;
    float mousetimer2 = 0;


    bool right;

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
        Invoke("Timer", 0);
        right = false;
        playerTransform = GameObject.Find("Character Body").GetComponent<Transform>();
    }
	
	void Update () {

        Vector3 facingRight = new Vector3(-0.15f, this.transform.localScale.y, this.transform.localScale.z);
        Vector3 facingLeft = new Vector3(0.15f, this.transform.localScale.y, this.transform.localScale.z);

        if (right == true)
        {
            this.transform.localScale = facingRight;
        }
        else if (right == false)
        {
            this.transform.localScale = facingLeft;
        }


    
        if (this.tag == "Startled")
        {
            currentState = BehaviourState.startled;
        }
        if (currentState == BehaviourState.moving)
        {
            Invoke("Timer", 0);
            speed = 0.02f;
            this.transform.position = transform.position + new Vector3(xMovement,0,0);
            this.transform.localScale = new Vector3(-xScale, this.transform.localScale.y, this.transform.localScale.z);
        }
        if (currentState == BehaviourState.startled)
        {

            if (this.transform.position.x < playerTransform.position.x)
            {
                right = false;
                if (mousetimer1 <= 0.5)
                {
                    this.transform.position = transform.position + new Vector3(-displacement, 0, 0);
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
                right = true;

                if (mousetimer1 <= 0.5)
                {
                    this.transform.position = transform.position + new Vector3(displacement, 0, 0);
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
            Invoke("Idle", 0);
            speed = 0;
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
            if (rnd2 == 3)
            {
                currentState = BehaviourState.moving;         
            }
            tick2 = 0;
        }
    }
}
