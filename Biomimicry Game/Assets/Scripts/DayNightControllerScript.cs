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
    public bool duskB, dawnB, down;

    Camera cam;
    SpriteRenderer rend;

    public Sprite dusk, dawn;

    public float startChangeTime = 10f;
    public float changeDuration = 40f;

    public float dayLength = 60f;
    
    float endChangeTime ;


    float startTime;

    public bool daytime;


    void Start()
    {
        cam = mainCam.GetComponent<Camera>();
        cam.clearFlags = CameraClearFlags.SolidColor;

        rend = GetComponent<SpriteRenderer>();

        timer = 0;

        duskB = false;
        dawnB = false;

        down = false;

        endChangeTime = startChangeTime + changeDuration;

        duration = dayLength / 2;
    }

    void Update()
    {
        float t = Mathf.PingPong(Time.time, duration) / duration;
        cam.backgroundColor = Color.Lerp(color1, color2, t);

        timer += Time.deltaTime;

        if (timer >= dayLength)
        {
            timer = 0;
        }

        if (timer > dayLength / 4 && timer < (dayLength / 4) * 3)
        {
            daytime = true;
        }
        else {
            daytime = false;
        }


        if (timer > startChangeTime && timer < endChangeTime)
        {
            duskB = false;
            if (dawnB == false) {
                UpdateTime();
                dawnB = true;
            }

            float progress = Time.time - startTime;
            float newAlpha = 0;

            if (down == false)
            {
                newAlpha = Mathf.Lerp(0f, 1f, progress / (changeDuration/2f));

                if (progress > changeDuration/2)
                {
                    down = true;
                    dawnB = false;
                    print("Switch");
                }
            }
            else if (down == true) {
                newAlpha = Mathf.Lerp(1f, 0f, progress / (changeDuration / 2f));
            }

            spriteAlpha = new Color(1, 1, 1, newAlpha);

            rend.color = spriteAlpha;
            rend.sprite = dawn;
        }

        else if (timer > dayLength - endChangeTime && timer < dayLength - startChangeTime)
        {
            dawnB = false;
            if (duskB == false)
            {
                UpdateTime();
                duskB = true;
            }

            float progress = Time.time - startTime;
            float newAlpha = 0;

            if (down == false)
            {
                newAlpha = Mathf.Lerp(0f, 1f, progress / (changeDuration / 2f));

                if (progress > changeDuration / 2)
                {
                    down = true;
                    duskB = false;
                    print("Switch");
                }
            }
            else if (down == true)
            {
                newAlpha = Mathf.Lerp(1f, 0f, progress / (changeDuration / 2f));
            }

            spriteAlpha = new Color(1, 1, 1, newAlpha);

            rend.color = spriteAlpha;
            rend.sprite = dusk;
        }

        else
        {
            rend.sprite = null;
            down = false;
        }
        
    }

    void UpdateTime() {
        startTime = Time.time;
    } 
}
