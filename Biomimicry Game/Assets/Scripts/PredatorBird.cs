using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PredatorBird : MonoBehaviour
{

    Rigidbody2D Eagle;
    Transform PlayerTransform;
    Transform PlayerBody;

    AudioSource audioSource;

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
    Vector3 PlayerFirst;
    Vector3 PlayerSecond;

    Vector3 rotateRight;
    Vector3 rotateLeft;

    int tripCount;


    void Start()
    {
        maxRange = 8;
        Eagle = GetComponent<Rigidbody2D>();
        PlayerBody = GameObject.Find("Character Body").GetComponent<Transform>();

        audioSource = GetComponent<AudioSource>();

        activeBird = false;
        timer = 0;
        speed = 15f;

        rotateRight = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
        rotateLeft = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);

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
        else if (DayTimeTracker.daytime == false && activeBird == false)
        {
            Eagle.transform.position = new Vector3(PlayerTransform.position.x, PlayerTransform.position.y + 50f, 0);
        }

        if (activeBird == true)
        {
            if (tripCount == 0)
            {
                transform.position = Vector3.MoveTowards(transform.position, PlayerFirst, speed * Time.deltaTime);
                if (Vector3.Distance(transform.position, PlayerFirst) < 2f)
                {
                    tripCount++;
                }
            }
            else if (tripCount == 1)
            {
                transform.position = Vector3.MoveTowards(transform.position, PlayerSecond, speed * Time.deltaTime);
                if (Vector3.Distance(transform.position, PlayerSecond) < 2f)
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
        bool right;
        int _ran = Random.Range(1, 3);

        if (_ran == 1)
        {
            right = true;
        }
        else {
            right = false;
        }

        tripCount = 0;
        UpdatedPlayerPosition = new Vector3(PlayerTransform.position.x, PlayerTransform.position.y + 2, 0);

        if (right)
        {
            transform.localScale = rotateRight;

            birdStartPos = new Vector3(UpdatedPlayerPosition.x + 30f, UpdatedPlayerPosition.y + 20f, 0);
            birdEndPos = new Vector3(UpdatedPlayerPosition.x - 50f, UpdatedPlayerPosition.y + 50f, 0);
            PlayerFirst = new Vector3(UpdatedPlayerPosition.x + 15f, UpdatedPlayerPosition.y + 1f, 0);
            PlayerSecond = new Vector3(UpdatedPlayerPosition.x - 10f, UpdatedPlayerPosition.y, 0);
        }
        else {
            transform.localScale = rotateLeft;

            birdStartPos = new Vector3(UpdatedPlayerPosition.x - 30f, UpdatedPlayerPosition.y + 20f, 0);
            birdEndPos = new Vector3(UpdatedPlayerPosition.x + 50f, UpdatedPlayerPosition.y + 50f, 0);
            PlayerSecond = new Vector3(UpdatedPlayerPosition.x + 10f, UpdatedPlayerPosition.y , 0);
            PlayerFirst = new Vector3(UpdatedPlayerPosition.x - 15f, UpdatedPlayerPosition.y + 1f, 0);
        }
        

        transform.position = birdStartPos;
        audioSource.Play();
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
