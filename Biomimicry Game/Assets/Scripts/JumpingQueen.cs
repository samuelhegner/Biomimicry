using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingQueen: MonoBehaviour {

    float queenTick;
    float random;
    int maxRange;
    int total;
    float queenJumpTimer;
    public float queenJumpHeight = 40;

    int queenJumpFrequency;
	Rigidbody2D rigid;
    Vector3 queenStartPosition;

    Transform PlayerTransform;
    Transform PlayerBody;

    Animator anim;

    public enum QueenBehaviourState
    {
        idle,
        jumping,
    }

    public QueenBehaviourState activestate;

	void Start () {
        total = 7;
        maxRange = total;
        rigid = GetComponent<Rigidbody2D>();
        PlayerTransform = GameObject.Find("Character Eyes").GetComponent<Transform>();
        PlayerBody = GameObject.Find("Character Body").GetComponent<Transform>();
        rigid.GetComponent<Rigidbody2D>();
        activestate = QueenBehaviourState.idle;
        queenStartPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        anim = GetComponent<Animator>();

        int ran = Random.Range(1, 3);

        if (ran == 1)
        {
            Vector3 Scale = new Vector3(this.transform.localScale.x, this.transform.localScale.y, this.transform.localScale.z);
            Scale.x *= -1;
            transform.localScale = Scale;
        }
    }


    void Update()
    {
        float vSpeed = rigid.velocity.y;

        anim.SetFloat("vSpeed", vSpeed);

        if (DayTimeTracker.daytime == false)
        {
            if (activestate == QueenBehaviourState.idle)
            {
                queenJumpFrequency = 10;
                Invoke("Timer", 0);
                anim.SetBool("Idle", true);
            }
            if (activestate == QueenBehaviourState.jumping)
            {
                anim.SetBool("Idle", false);
                queenJumpTimer += Time.deltaTime;
                if (queenJumpTimer < 0.5)
                {
                    rigid.AddForce(transform.up * queenJumpHeight, ForceMode2D.Impulse);
                }
                if (this.transform.position.y <= queenStartPosition.y && queenJumpTimer > 0.5)
                {
                    queenJumpTimer = 0;
                    activestate = QueenBehaviourState.idle;
                }
            }
        }
        if(DayTimeTracker.daytime == true)
        {

        }
    }
    void Timer()
    {
        queenTick += Time.deltaTime;
        if (queenTick >= 1)
        {
            random = Random.Range(0, maxRange);
            print(random);
            if (random == 0)
            {
                activestate = QueenBehaviourState.jumping;
                maxRange = total;               
            }
            if (random > 2)
            {
                maxRange--;
            }
            queenTick = 0; 
        }
    }
}
