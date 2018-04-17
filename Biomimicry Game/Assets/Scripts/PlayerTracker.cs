using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerTracker : MonoBehaviour {

    Transform PlayerTransform;
    Transform PlayerBody;

    Rigidbody2D rb;

    float xMovement;

    void Start () {
        xMovement = 0.1f;
        PlayerTransform = GameObject.Find("Player").GetComponent<Transform>();
        PlayerBody = GameObject.Find("Character Body").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();     
    }
	
	
	void Update () {
        if (PlayerBody.tag == "Stealthed" && PlayerTransform.position.x > transform.position.x -20 && PlayerTransform.position.x <= transform.position.x)
        {
            this.transform.position = transform.position + new Vector3(-xMovement, 0, 0);
        }
        else if (PlayerBody.tag == "Stealthed" && PlayerTransform.position.x >= transform.position.x && PlayerTransform.position.x < transform.position.x + 20)
        {
            this.transform.position = transform.position + new Vector3(+xMovement, 0, 0);
        }
        else if (PlayerBody.tag == "Unstealthed")
        {

        }
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Application.LoadLevel(Application.loadedLevel);
        }
        if (collision.tag == "Bird")
        {
            Destroy(this.gameObject);
        }
    }
}
