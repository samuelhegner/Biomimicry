using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingEnemy : MonoBehaviour {

    float tick;
    float rnd;

    float jumptimer;
    float jumpHeight = 40;

    public GameObject Queen;
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
        queenStart = Queen.transform.position.y;
        rb = GetComponent<Rigidbody2D>();
        currentstate = BehaviourState.idle;
        startPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
	}


    void Update()
    {
        if (Queen.transform.position.y > queenStart && currentstate != BehaviourState.encouraged)
        {
            currentstate = BehaviourState.encouraged;
        }
        if (currentstate == BehaviourState.idle)
        {
            tickCount = 1;
            Invoke("Timer", 0);
        }
        if (currentstate == BehaviourState.jumping)
        {
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
                currentstate = BehaviourState.jumping;
            }
            tick = 0; 
        }
    }
}
