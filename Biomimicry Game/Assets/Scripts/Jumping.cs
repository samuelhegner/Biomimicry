using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jumping : MonoBehaviour
{
    public bool canJump;
    public KeyCode jumpKey;
	public GameObject groundcheck;
    Rigidbody2D rb;
    public float jumpForce = 200;
    public int objectiveCounter = 0;
    public int jumpCount;
    int jumpMax;
    public float secondJumpDeducter;
    AudioSource audioSource;
    public AudioClip glide;
    public AudioClip jumpSound;
    public bool audioReady;

    public GameObject leg1, leg2, wing;

    float starterGravityScale;

    public GameObject smokePuff;
 
    bool unlock1 = false;

    void Start()
    {
        objectiveCounter = SceneManager.GetActiveScene().buildIndex - 1;
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        jumpCount = 0;
        jumpMax = 1;
        starterGravityScale = rb.gravityScale;
        audioReady = true;
    }
    private void Update()
    {
        GetComponent<Animator>().SetInteger("Upgrade", objectiveCounter);
        GetComponent<Animator>().SetBool("Grounded", canJump);

        canJump = groundcheck.GetComponent<Groundcheck> ().canJump;
        if (canJump) {
            jumpCount = 0;
        }

        if (Input.GetKeyDown(jumpKey) && unlock1 == true && jumpCount < jumpMax)
        {
            if (jumpCount == 0 && canJump)
            {
                audioSource.clip = jumpSound;
                audioSource.Play();
                rb.velocity = new Vector2(rb.velocity.x, 0f);
                rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
                jumpCount++;
                GetComponent<Animator>().SetTrigger("Jump");

            }else if (jumpCount == 1 && !canJump)
            {
                audioSource.clip = jumpSound;
                audioSource.Play();
                rb.velocity = new Vector2(rb.velocity.x, 0f);
                rb.AddForce(transform.up * (jumpForce - secondJumpDeducter), ForceMode2D.Impulse);
                jumpCount++;
                GetComponent<Animator>().SetTrigger("Jump");
            }
        }

        if (jumpCount >= 1 && !canJump && objectiveCounter >= 3)
        {
            if (Input.GetKey(KeyCode.LeftShift) && !canJump)
            {
                audioSource.clip = glide;
                if (audioReady == true)
                {
                    audioSource.Play();
                    audioReady = false;
                }
                rb.gravityScale = 0.0f;
                rb.velocity = new Vector2(rb.velocity.x, -4f);
                GetComponent<Animator>().SetBool("Glide", true);
            }
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            rb.gravityScale = starterGravityScale;
            GetComponent<Animator>().SetBool("Glide", false);
            audioReady = true;
            audioSource.Pause();
        }




        if (objectiveCounter >= 1)
        {
            unlock1 = true;
            leg1.SetActive(true);
            leg2.SetActive(true);
        }
        if (objectiveCounter >= 2)
        {
            jumpMax = 2;
            wing.SetActive(true);
        }

        if (objectiveCounter >= 3) {
            jumpMax = 3;
        }

        if (objectiveCounter >= 4)
        {
            objectiveCounter = 3;
        }

        GetComponent<Animator>().SetInteger("JumpCount", jumpCount);

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Objective")
        {
            objectiveCounter++;
            Destroy(collision.gameObject);
            Instantiate(smokePuff, transform.position, transform.rotation);
        }
    }
}

