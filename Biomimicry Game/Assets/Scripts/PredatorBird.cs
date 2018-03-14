using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PredatorBird : MonoBehaviour {

    Rigidbody2D Eagle;
    Transform PlayerTransform;
    Transform PlayerBody;

    float EagleX;
    float EagleY;

    float timer;
    float rnd;

	void Start () {
        Eagle = GetComponent<Rigidbody2D>();
        PlayerTransform = GameObject.Find("Character Eyes").GetComponent<Transform>();
        PlayerBody = GameObject.Find("Character Body").GetComponent<Transform>();
        EagleX = PlayerTransform.position.x + 40;
        EagleY = PlayerTransform.position.y + 50;
    }
	

	void Update () {
        print(DayTimeTracker.daytime);
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
            Eagle.transform.position = new Vector3(EagleX, EagleY, 0);
          }
         
       }
    }
}
