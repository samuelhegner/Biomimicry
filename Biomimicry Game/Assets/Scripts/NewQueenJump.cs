﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewQueenJump : MonoBehaviour {

    public GameObject Body;
    public Transform PlayerBody;
    Animator anim;
    Rigidbody2D rigid;
    float rnd;
    float Timer = 0;
    public float jumpHeight;
    int maxRange = 5;
    bool PlayerNear;

    public enum QueenBehaviour
    {
        idle,
        jumping,
        falling,
    }

    public QueenBehaviour currentQueenState;

    void Start () {
        PlayerBody = GameObject.Find("Character Body").GetComponent<Transform>();
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentQueenState = QueenBehaviour.idle;

        int ran = Random.Range(1, 3);

        if (ran == 1)
        {
            Vector3 Scale = new Vector3(this.transform.localScale.x, this.transform.localScale.y, this.transform.localScale.z);
            Scale.x *= -1;
            transform.localScale = Scale;
        }
    }
	
	void Update () {
        PlayerNear = Body.GetComponent<Proximity>().Playernear;
        float vSpeed = rigid.velocity.y;

        anim.SetFloat("vSpeed", vSpeed);

        if (currentQueenState == QueenBehaviour.idle)
        {
            Timer += Time.deltaTime;
        }
        if (Timer >= 1 && currentQueenState == QueenBehaviour.idle)
        {
            rnd = Random.Range(1, maxRange);
            Timer = 0;
        }
        if (rnd == 3)
        {
            rnd = 0;
            if (DayTimeTracker.daytime == false)
            {
                if (PlayerNear == false)
                {
                    currentQueenState = QueenBehaviour.jumping;
                }
                else if (PlayerNear = true && PlayerBody.tag == "Stealthed")
                {
                    currentQueenState = QueenBehaviour.jumping;
                }
                else if (PlayerNear = true && PlayerBody.tag == "Unstealthed")
                {
                    currentQueenState = QueenBehaviour.idle;
                }
            }
        }
        
        if (currentQueenState == QueenBehaviour.idle)
        {
            anim.SetBool("Idle", true);
        }
        if (currentQueenState == QueenBehaviour.jumping)
        {
            anim.SetBool("Idle", false);
            rigid.AddForce(transform.up * jumpHeight, ForceMode2D.Impulse);
            currentQueenState = QueenBehaviour.falling;
        }
        if (currentQueenState == QueenBehaviour.falling)
        {
            if (rigid.velocity.y < 0.1)
            {
                Timer = 0;
                currentQueenState = QueenBehaviour.idle;
            }
        }
    }
}
