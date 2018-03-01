﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingQueen: MonoBehaviour {

    float queenTick;
    float random;

    float queenJumpTimer;
    float queenJumpHeight = 40;

    int queenJumpFrequency;
	Rigidbody2D rigid;
    Vector3 queenStartPosition;

    Transform PlayerTransform;
    Transform PlayerBody;

    public enum QueenBehaviourState
    {
        idle,
        jumping,
    }

    public QueenBehaviourState activestate;

	void Start () {
        rigid = GetComponent<Rigidbody2D>();
        PlayerTransform = GameObject.Find("Character Eyes").GetComponent<Transform>();
        PlayerBody = GameObject.Find("Character Body").GetComponent<Transform>();
        rigid.GetComponent<Rigidbody2D>();
        activestate = QueenBehaviourState.idle;
        queenStartPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
	}


    void Update()
    {


        if (activestate == QueenBehaviourState.idle)
        {
            queenJumpFrequency = 10;
            Invoke("Timer", 0);
        }
        if (activestate == QueenBehaviourState.jumping)
        {
            queenJumpTimer += Time.deltaTime;
            if (queenJumpTimer < 0.5)
            {
                rigid.AddForce(transform.up * queenJumpHeight);
            }
            if (this.transform.position.y <= queenStartPosition.y && queenJumpTimer > 0.5)
            {
                queenJumpTimer = 0;
                activestate = QueenBehaviourState.idle;
            }
        }


    }
    void Timer()
    {
        queenTick += Time.deltaTime;
        if (queenTick >= 1)
        {
            random = Random.Range(0, 10);
            if (random == 0)
            {
                if (PlayerBody.tag == "Unstealthed" && PlayerTransform.position.x > rigid.transform.position.x + 8 || PlayerTransform.position.x < rigid.transform.position.x - 8)
                {
                    activestate = QueenBehaviourState.jumping;
                }
                else if (PlayerBody.tag == "Stealthed")
                {
                    activestate = QueenBehaviourState.jumping;
                }
                else if (PlayerBody.tag == "Unstealthed" && PlayerTransform.position.x < rigid.transform.position.x + 8 || PlayerTransform.position.x > rigid.transform.position.x - 8)
                {
                    activestate = QueenBehaviourState.idle;
                }
            }
            queenTick = 0; 
        }
    }
}
