using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingEnemy : MonoBehaviour {

    float tick;
    float rnd;

    float jumptimer;
    float jumpHeight = 40;

    Transform Queen;
    Transform Player;
    float queenStart;

    float tickCount = 1;

<<<<<<< HEAD
	Rigidbody2D rb;
=======
    Rigidbody2D rb;
>>>>>>> ef4244912d41de01c73265d945a4e2e0fe2e82b7

    Vector3 startPosition;

    public enum BehaviourState
    {
        idle,
        encouraged,
        jumping,
    }

    public BehaviourState currentstate;

	void Start () {
<<<<<<< HEAD
        queenStart = Queen.transform.position.y;
=======
        Queen = GameObject.Find("Queen").GetComponent<Transform>();
        Player = GameObject.Find("Character Eyes").GetComponent<Transform>();
        queenStart = Queen.position.y;
>>>>>>> ef4244912d41de01c73265d945a4e2e0fe2e82b7
        rb = GetComponent<Rigidbody2D>();
        currentstate = BehaviourState.idle;
        startPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
	}


    void Update()
    {
        if (Queen.position.y > queenStart && currentstate != BehaviourState.encouraged)
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
            if (rnd == 0 && Player.position.x > rb.transform.position.x + 8 || Player.position.x <rb.transform.position.x - 8)
            {
                currentstate = BehaviourState.jumping;
            }
            tick = 0; 
        }
    }
}
