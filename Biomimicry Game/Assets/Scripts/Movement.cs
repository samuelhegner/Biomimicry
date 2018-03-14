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
    
    void Start()
    {
        halfspeed = maxSpeed / 3;
        fullspeed = maxSpeed;
    }

    void FixedUpdate()
    {
        
        if (body.tag == "Stealthed")
        {
            maxSpeed = halfspeed;
        }
        else if (body.tag != "Stealthed")
        {
            maxSpeed = fullspeed;
        }
        float move = Input.GetAxis("Horizontal");

        var move1 = new Vector3(Input.GetAxis("Horizontal"), 0);

        transform.position += move1 * maxSpeed * Time.deltaTime;

        currentSpeed = move * accelerationSpeed;
    }
}