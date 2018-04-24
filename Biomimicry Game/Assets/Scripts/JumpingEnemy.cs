using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingEnemy : MonoBehaviour {

    float tick;
    float rnd;

    float jumptimer;
    float jumpHeight = 1.2f;
    int maxRange;

    public Transform Queen;
    Transform PlayerTransform;
    Transform PlayerBody;
    float queenStart;
    
    float tickCount = 0.03f;
    Rigidbody2D rb;

    Vector3 startPosition;

    Animator anim;

    public enum BehaviourState
    {
        idle,
        encouraged,
        jumping,
    }

    public BehaviourState currentstate;

	void Start () {
        maxRange = 6;
        queenStart = Queen.position.y;
        PlayerTransform = GameObject.Find("Character Eyes").GetComponent<Transform>();
        PlayerBody = GameObject.Find("Character Body").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        currentstate = BehaviourState.idle;
        startPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
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
        float vSpeed = rb.velocity.y;

        anim.SetFloat("vSpeed", vSpeed);

        if (DayTimeTracker.daytime == false)
        {
            if (Queen.position.y > queenStart + 1 && currentstate != BehaviourState.encouraged)
            {            
                    currentstate = BehaviourState.encouraged;             
            }
            if (currentstate == BehaviourState.idle)
            {
                this.tag = "Untagged";               
                anim.SetBool("Idle", true);
            }
            if (currentstate == BehaviourState.jumping)
            {
                anim.SetBool("Idle", false);

                jumptimer += Time.deltaTime;
                if (jumptimer < 0.6 && jumptimer > 0)
                {
                    rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
                }
                if (jumptimer > 0.6 && jumptimer < 1.3)
                {
                    this.tag = "NPC";
                }
                else if (jumptimer > 1.3)
                {
                    this.tag = "Untagged";
                }
                if (this.transform.position.y <= startPosition.y && jumptimer > 0.6)
                {
                    jumptimer = 0;
                    currentstate = BehaviourState.idle;
                }
            }
            if (currentstate == BehaviourState.encouraged)
            {
                this.tag = "Untagged";
                Invoke("Timer", 0);
                tickCount = 0.05f;
            }
        }
        else if (DayTimeTracker.daytime == true)
        {

        }
    }
    
    void Timer()
    {
        tick += Time.deltaTime;
        if (tick >= tickCount)
        {
            rnd = Random.Range(0, maxRange);
            if (rnd == 0)
            {
                if (PlayerBody.tag == "Unstealthed" && PlayerTransform.position.x > transform.position.x + 8 || PlayerBody.tag == "Unstealthed" && PlayerTransform.position.x < transform.position.x - 8)
                {
                    currentstate = BehaviourState.jumping;
                    maxRange = 6;
                }
                else if (PlayerBody.tag == "Stealthed")
                {
                    currentstate = BehaviourState.jumping;
                    maxRange = 6;
                }
                else if (PlayerBody.tag == "Unstealthed" && PlayerTransform.position.x < transform.position.x + 8 || PlayerTransform.position.x > transform.position.x - 8)
                {
                    currentstate = BehaviourState.encouraged;
                    maxRange = 6;
                }
            }
            else if (rnd > 0 && rnd < 4)
            {
                maxRange--;
            }
            else if (rnd == 4 || rnd == 5)
            {
                currentstate = BehaviourState.idle;
            }
            tick = 0; 
        }
    }
}
