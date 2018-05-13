using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightControllerScript : MonoBehaviour
{

    public GameObject mainCam;

    public Color color1 = Color.red;
    public Color color2 = Color.blue;
    Color spriteAlpha;
    float duration = 3.0F;

    float timer;
    public bool down, day;

    Camera cam;
    SpriteRenderer rend;

    public Sprite dusk, dawn;

    float changeDuration;

    public float dayLength = 60f;

    float startTime;
    float spriteStartTime;

    GameObject player;

    public float speed = 0.2f;

    void Start()
    {
        cam = mainCam.GetComponent<Camera>();
        cam.clearFlags = CameraClearFlags.SolidColor;

        rend = GetComponent<SpriteRenderer>();

        timer = 0;


        changeDuration = dayLength / 4;

        player = GameObject.Find("Player");
        day = false;
        cam.backgroundColor = color1;
    }

    void Update()
    {
        Vector3 newLocation = new Vector3(player.transform.position.x, this.transform.position.y, this.transform.position.z);

        this.transform.position = newLocation;

        timer += Time.deltaTime;

        if (timer > dayLength) {
            timer = 0;
            day = !day;
            ChangeColor();
        }
    }

    void UpdateTime() {
        startTime = Time.time;
    }
    void UpdateSpriteTime() {
        spriteStartTime = Time.time;
    }

    void ChangeColor() {
        if (day == false) {
            down = false;
            UpdateTime();
            UpdateSpriteTime();
            StartCoroutine(ChangeToNight());
            DayTimeTracker.ChangeNight();
        }
        else if(day == true) {
            down = false;
            UpdateTime();
            UpdateSpriteTime();
            StartCoroutine(ChangeToDay());
            DayTimeTracker.ChangeDay();
        }

    }

    IEnumerator ChangeToDay() {
        while (cam.backgroundColor != color2) {
            cam.backgroundColor = Color.Lerp(color1, color2, (Time.time - startTime) /changeDuration);

            float newAlpha;

            if (down == false)
            {
                newAlpha = Mathf.Lerp(0, 1, (Time.time - spriteStartTime) / (changeDuration / 2));
                spriteAlpha = new Color(1, 1, 1, newAlpha);

                if ((Time.time - spriteStartTime) > changeDuration / 2) {
                    down = true;
                    UpdateSpriteTime();
                }
            }
            else if(down == true) {
                newAlpha = Mathf.Lerp(1, 0, (Time.time - spriteStartTime) / (changeDuration / 2));
                spriteAlpha = new Color(1, 1, 1, newAlpha);
            }



            rend.color = spriteAlpha;
            rend.sprite = dawn;

            yield return null;
        }
    }

    IEnumerator ChangeToNight()
    {
        while (cam.backgroundColor != color1)
        {
            cam.backgroundColor = Color.Lerp(color2, color1, (Time.time - startTime) / changeDuration);

            float newAlpha;

            if (down == false)
            {
                newAlpha = Mathf.Lerp(0, 1, (Time.time - spriteStartTime) / (changeDuration / 2));
                spriteAlpha = new Color(1, 1, 1, newAlpha);

                if ((Time.time - spriteStartTime) > changeDuration / 2)
                {
                    down = true;
                    UpdateSpriteTime();
                }
            }
            else if (down == true)
            {
                newAlpha = Mathf.Lerp(1, 0, (Time.time - spriteStartTime) / (changeDuration / 2));
                spriteAlpha = new Color(1, 1, 1, newAlpha);
            }



            rend.color = spriteAlpha;
            rend.sprite = dusk;

            yield return null;
        }
    }
}





public static class DayTimeTracker {

    public static bool daytime;


    public static void ChangeDay() {
        daytime = true;
    }


    public static void ChangeNight()
    {
        daytime = false;
    }

}

