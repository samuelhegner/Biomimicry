using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public float maxSpeed;
    public float accelerationSpeed;
    public float currentSpeed;
    public float halfspeed;
    public float fullspeed;
    public GameObject body;

    Animator anim;

    void Start()
    {
        halfspeed = maxSpeed / 3;
        fullspeed = maxSpeed;
        anim = GetComponentInChildren<Animator>();
    }

    void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");

        
        if (move > 0)
        {
            anim.SetBool("FacingRight", true);
        }
        else if (move < 0)
        {
            anim.SetBool("FacingRight", false);
        }


        if (body.tag == "Stealthed")
        {
            maxSpeed = halfspeed;
            GetComponent<Animator>().SetBool("Camo", true);
        }
        else if (body.tag != "Stealthed")
        {
            maxSpeed = fullspeed;
            GetComponent<Animator>().SetBool("Camo", false);
        }

        var move1 = new Vector3(Input.GetAxis("Horizontal"), 0);

        transform.position += move1 * maxSpeed * Time.deltaTime;

        currentSpeed = move * accelerationSpeed;

        anim.SetFloat("Speed", (currentSpeed + move));

    }
}