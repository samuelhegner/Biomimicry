using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PredatorBird : MonoBehaviour
{

    Rigidbody2D Eagle;
    Transform PlayerTransform;
    Transform PlayerBody;


    bool activeBird;
    bool reachedPlayer;

    float EagleX;
    float EagleY;

    float timer;
    float rnd;
    float startTime;
    float distCovered;
    float fracJourney;
    float journeyLength;


    Vector3 birdStartPos;
    Vector3 birdEndPos;
    Vector3 UpdatedPlayerPosition;


    void Start()
    {
        Eagle = GetComponent<Rigidbody2D>();
        PlayerBody = GameObject.Find("Character Body").GetComponent<Transform>();

        activeBird = false;
        timer = 0;
    }


    void Update()
    {

        PlayerTransform = GameObject.Find("Character Eyes").GetComponent<Transform>();

        if (DayTimeTracker.daytime == true && activeBird == false)
        {
            Invoke("Timer", 0);
            Eagle.transform.position = new Vector3(PlayerTransform.position.x, 1000f, 0);
        }
        else if (DayTimeTracker.daytime == false)
        {
            Eagle.transform.position = new Vector3(PlayerTransform.position.x, 1000f, 0);
        }

        print(reachedPlayer);

        if (activeBird == true)
        {
            if (reachedPlayer == false)
            {
                float distCovered = (Time.time - startTime) * 10f;
                float fracJourney = distCovered / journeyLength;
                this.transform.position = Vector3.Slerp(birdStartPos, UpdatedPlayerPosition, fracJourney);
                
                if (this.transform.position == UpdatedPlayerPosition)
                {
                    reachedPlayer = true;
                    Invoke("SetTime", 0);
                }
            }
            else {
                float distCovered = (Time.time - startTime) * 10f;
                float fracJourney = distCovered / journeyLength;
                this.transform.position = Vector3.Lerp(UpdatedPlayerPosition, birdEndPos, fracJourney);

                if (this.transform.position == birdEndPos)
                {
                    reachedPlayer = false;
                    activeBird = false;
                    Invoke("SetTime", 0);
                }
            }
        }
    }

    void Timer()
    {
        timer += Time.deltaTime;

        if (timer >= 1)
        {
            rnd = Random.Range(0, 4);
            if (rnd == 0 && PlayerBody.tag == "Unstealthed")
            {               
                    activeBird = true;
                    Invoke("SetTime", 0);
                    Invoke("SetPlayerPosition", 0);
            }

            timer = 0;
        }
    }

    void SetPlayerPosition()
    {
        UpdatedPlayerPosition = new Vector3(PlayerTransform.position.x, PlayerTransform.position.y + 2, 0);
        birdStartPos = new Vector3(UpdatedPlayerPosition.x + 10f, UpdatedPlayerPosition.y + 10f, 0);
        birdEndPos = new Vector3(UpdatedPlayerPosition.x - 10f, UpdatedPlayerPosition.y + 10f, 0);
        journeyLength = Vector3.Distance(birdStartPos, UpdatedPlayerPosition);
    }

    void SetTime() {
        startTime = Time.time;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Unstealthed")
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }
}
