using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCricketJump : MonoBehaviour {

    Transform Player;
    Transform PlayerBody;
    public Transform QueenTransform;
    public float queenStartY;
    public float jumpHeight;
    float Timer;

    Rigidbody2D rb;
    Animator anim;

    public enum CricketBehaviour
    {
        idle,
        falling,
        jumping,
        encouraged,
    }

    public CricketBehaviour currentBehaviour;

	void Start () {
        rb = GetComponent<Rigidbody2D>();
        Player = GameObject.Find("Player").GetComponent<Transform>();
        PlayerBody = GameObject.Find("Character Body").GetComponent<Transform>();
        currentBehaviour = CricketBehaviour.idle;
        queenStartY = QueenTransform.position.y;
        anim = GetComponent<Animator>();

        int ran = Random.Range(1, 3);

        if (ran == 1)
        {
            Vector3 Scale = new Vector3(this.transform.localScale.x, this.transform.localScale.y, this.transform.localScale.z);
            Scale.x *= -1;
            transform.localScale = Scale;
        }
    }
	
	
	void Update () {
        float vSpeed = rb.velocity.y;

        anim.SetFloat("vSpeed", vSpeed);

        print(rb.velocity.y);
        if (DayTimeTracker.daytime == false)
        {
            if (QueenTransform.position.y > queenStartY && currentBehaviour == CricketBehaviour.idle)
            {
                currentBehaviour = CricketBehaviour.encouraged;
            }
            if (currentBehaviour == CricketBehaviour.encouraged)
            {
                Timer += Time.deltaTime;
                if (Timer > 0.5)
                {
                    Timer = 0;
                    if (PlayerBody.tag == "Unstealthed" && Player.position.x > transform.position.x + 8 || PlayerBody.tag == "Unstealthed" && Player.position.x < transform.position.x - 8)
                    {
                        currentBehaviour = CricketBehaviour.jumping;
                    }
                    else if (PlayerBody.tag == "Stealthed")
                    {
                        currentBehaviour = CricketBehaviour.jumping;
                    }
                    else if (PlayerBody.tag == "Unstealthed" && Player.position.x < transform.position.x + 8 && Player.position.x > transform.position.x - 8)
                    {
                        currentBehaviour = CricketBehaviour.idle;
                    }          
                }
            }
            if (currentBehaviour == CricketBehaviour.idle)
            {
                this.tag = "Untagged";
                anim.SetBool("Idle", true);
            }
            if (currentBehaviour == CricketBehaviour.jumping)
            {
                anim.SetBool("Idle", false);
                rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
                currentBehaviour = CricketBehaviour.falling;
            }
            if (currentBehaviour == CricketBehaviour.falling)
            {
                if (rb.velocity.y < -1 && rb.velocity.y >= -10)
                {
                    this.tag = "NPC";
                }
                else if (rb.velocity.y >= -1 || rb.velocity.y <-10)
                {
                    this.tag = "Untagged";
                }
                if (rb.velocity.y <-17)
                {
                    currentBehaviour = CricketBehaviour.idle;
                }
            }
        }
        if (DayTimeTracker.daytime == false)
        {

        }
	}
}
