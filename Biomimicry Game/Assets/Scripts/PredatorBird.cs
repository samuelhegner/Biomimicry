using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PredatorBird : MonoBehaviour {

    Rigidbody2D Eagle;
    Transform PlayerTransform;
    Transform PlayerBody;

	void Start () {
        Eagle = GetComponent<Rigidbody2D>();
        PlayerTransform = GameObject.Find("Character Eyes").GetComponent<Transform>();
        PlayerBody = GameObject.Find("Character Body").GetComponent<Transform>();
    }
	

	void Update () {
        print(DayTimeTracker.daytime);
        if (DayTimeTracker.daytime == true)
        {
            Eagle.transform.localScale;
        }
        if (DayTimeTracker.daytime == false)
        {
            Eagle.AddForce(transform.up * 40);
        }
	}
}
