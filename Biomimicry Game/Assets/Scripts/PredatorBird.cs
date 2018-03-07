using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PredatorBird : MonoBehaviour {

    Transform PlayerTransform;
    Transform PlayerBody;

	void Start () {
        PlayerTransform = GameObject.Find("Character Eyes").GetComponent<Transform>();
        PlayerBody = GameObject.Find("Character Body").GetComponent<Transform>();
    }
	

	void Update () {
        if (DayTimeTracker.daytime == true)
        {
            this.gameObject.SetActive(true);
            print("1");
        }
        else if (DayTimeTracker.daytime == false)
        {
            this.gameObject.SetActive(false);
            print("0");
        }
	}
}
