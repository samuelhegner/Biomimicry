using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PredatorBird : MonoBehaviour
{

    Rigidbody2D Eagle;
    Transform PlayerTransform;
    Transform PlayerBody;


    bool activeBird;
    bool reachedPlayer;

    float EagleX;
    float EagleY;

    int maxRange;

    float timer;
    float rnd;
    float startTime;
    float distCovered;
    float fracJourney;
    float journeyLength;
    float speed;


    Vector3 birdStartPos;
    Vector3 birdEndPos;
    Vector3 UpdatedPlayerPosition;
    Vector3 PlayerRight;
    Vector3 PlayerLeft;

    int tripCount;


    void Start()
    {
        maxRange = 8;
        Eagle = GetComponent<Rigidbody2D>();
        PlayerBody = GameObject.Find("Character Body").GetComponent<Transform>();

        activeBird = false;
        timer = 0;
        speed = 15f;
    }


    void Update()
    {
        GetComponent<Animator>().SetInteger("TripCount", tripCount);
        PlayerTransform = GameObject.Find("Character Eyes").GetComponent<Transform>();

        if (DayTimeTracker.daytime == true && activeBird == false)
        {
            Invoke("Timer", 0);
            Eagle.transform.position = new Vector3(PlayerTransform.position.x, PlayerTransform.position.y + 50f, 0);
        }
        else if (DayTimeTracker.daytime == false)
        {
            Eagle.transform.position = new Vector3(PlayerTransform.position.x, PlayerTransform.position.y + 50f, 0);
        }

        if (activeBird == true)
        {
            if (tripCount == 0)
            {
                transform.position = Vector3.MoveTowards(transform.position, PlayerRight, speed * Time.deltaTime);
                if (Vector3.Distance(transform.position, PlayerRight) < 2f)
                {
                    tripCount++;
                }
            }
            else if (tripCount == 1)
            {
                transform.position = Vector3.MoveTowards(transform.position, PlayerLeft, speed * Time.deltaTime);
                if (Vector3.Distance(transform.position, PlayerLeft) < 2f)
                {
                    tripCount++;
                }
            }
            else if (tripCount == 2)
            {
                transform.position = Vector3.MoveTowards(transform.position, birdEndPos, speed * Time.deltaTime);
                if (Vector3.Distance(transform.position, birdEndPos) < 2f)
                {
                    tripCount++;
                }
            }
            else if (tripCount == 3) {
                activeBird = false;
            }
        }
    }

    void Timer()
    {
        timer += Time.deltaTime;

        if (timer >= 1)
        {
            rnd = Random.Range(0, maxRange);
            if (rnd == 0 && PlayerBody.tag == "Unstealthed")
            {
                activeBird = true;
                Invoke("SetTime", 0);
                Invoke("SetPlayerPosition", 0);
                maxRange = 8;
            }
            else if (rnd != 0 && PlayerBody.tag == "Unstealthed")
            {
                maxRange--;
            }
            timer = 0;
        }
    }

    void SetPlayerPosition()
    {
        tripCount = 0;
        UpdatedPlayerPosition = new Vector3(PlayerTransform.position.x, PlayerTransform.position.y + 2, 0);
        birdStartPos = new Vector3(UpdatedPlayerPosition.x + 30f, UpdatedPlayerPosition.y + 20f, 0);
        birdEndPos = new Vector3(UpdatedPlayerPosition.x - 50f, UpdatedPlayerPosition.y + 50f, 0);
        PlayerRight = new Vector3(UpdatedPlayerPosition.x + 15f, UpdatedPlayerPosition.y + 1f, 0);
        PlayerLeft = new Vector3(UpdatedPlayerPosition.x - 10f, UpdatedPlayerPosition.y, 0);

        transform.position = birdStartPos;
    }

    void SetTime() {
        startTime = Time.time;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Unstealthed")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
