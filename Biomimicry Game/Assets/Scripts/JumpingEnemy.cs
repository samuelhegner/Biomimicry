using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingEnemy : MonoBehaviour {

    float tick;
    float rnd;

    float jumptimer;
    float jumpHeight = 40;

    Transform Queen;
    Transform PlayerTransform;
    Transform PlayerBody;
    float queenStart;
    
    float tickCount = 1;
    Rigidbody2D rb;

    Vector3 startPosition;

    public enum BehaviourState
    {
        idle,
        encouraged,
        jumping,
    }

    public BehaviourState currentstate;

	void Start () {
        Queen = GameObject.Find("Queen").GetComponent<Transform>();
        PlayerTransform = GameObject.Find("Character Eyes").GetComponent<Transform>();
        PlayerBody = GameObject.Find("Character Body").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        currentstate = BehaviourState.idle;
        startPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
	}


    void Update()
    {
        print(PlayerTransform.tag);
        if (Queen.position.y > queenStart && currentstate != BehaviourState.encouraged)
        {
            currentstate = BehaviourState.encouraged;
        }
        if (currentstate == BehaviourState.idle)
        {
            this.tag = "Untagged";
            tickCount = 1;
            Invoke("Timer", 0);
        }
        if (currentstate == BehaviourState.jumping)
        {
            this.tag = "NPC";
            jumptimer += Time.deltaTime;
            if (jumptimer < 0.5)
            {
                rb.AddForce(transform.up * jumpHeight);
            }
            if (this.transform.position.y <= startPosition.y && jumptimer > 0.5)
            {
                jumptimer = 0;
                currentstate = BehaviourState.idle;
            }
        }
        if (currentstate == BehaviourState.encouraged)
        {
            this.tag = "Untagged";
            Invoke("Timer", 0);
            tickCount = 0.03f;
        }
    }
    
    void Timer()
    {
        tick += Time.deltaTime;
        if (tick >= tickCount)
        {
            rnd = Random.Range(0, 7);
            if (rnd == 0)
            {
                if (PlayerBody.tag == "Unstealthed" && PlayerTransform.position.x > rb.transform.position.x + 8 || PlayerTransform.position.x < rb.transform.position.x - 8)
                {
                    currentstate = BehaviourState.jumping;
                }
                else if (PlayerBody.tag == "Stealthed")
                {
                    currentstate = BehaviourState.jumping;
                }
                else if (PlayerBody.tag == "Unstealthed" && PlayerTransform.position.x < rb.transform.position.x + 8 || PlayerTransform.position.x > rb.transform.position.x - 8)
                {
                    currentstate = BehaviourState.idle;
                }
            }
            tick = 0; 
        }
    }
}
