using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PredatorBird : MonoBehaviour
{

    Rigidbody2D Eagle;
    Transform PlayerTransform;
    Transform PlayerBody;

    float EagleX;
    float EagleY;

    float timer;
    float rnd;

    Vector3 UpdatedPlayerPosition = new Vector3(0,20,0);

    void Start()
    {
        Eagle = GetComponent<Rigidbody2D>();
        PlayerBody = GameObject.Find("Character Body").GetComponent<Transform>();
        EagleX = PlayerTransform.position.x + 12;
        EagleY = PlayerTransform.position.y + 10;
    }


    void Update()
    {

        PlayerTransform = GameObject.Find("Character Eyes").GetComponent<Transform>();

        if (DayTimeTracker.daytime == true)
        {
            Invoke("Timer", 0);
        }
        if (DayTimeTracker.daytime == false)
        {
            Eagle.transform.position = new Vector3(PlayerTransform.position.x, PlayerTransform.position.y + EagleY, 0);
        }
    }

    void Timer()
    {
        timer += Time.deltaTime;
        if (timer >= 1)
        {
            rnd = Random.Range(0, 4);
            if (rnd == 0)
            {
                Invoke("SetPlayerPosition", 0);
                Eagle.transform.position = new Vector3(UpdatedPlayerPosition.x + 12, UpdatedPlayerPosition.y + 10, 0);
            }
            timer = 0;
        }
    }

    void SetPlayerPosition()
    {
        UpdatedPlayerPosition = PlayerTransform.position;
    }
}
