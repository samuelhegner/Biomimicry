using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float maxSpeed;
    public float accelerationSpeed;
    public float currentSpeed;
   
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");

        var move1 = new Vector3(Input.GetAxis("Horizontal"), 0);

        transform.position += move1 * maxSpeed * Time.deltaTime;

        currentSpeed = move * accelerationSpeed;
    }
}