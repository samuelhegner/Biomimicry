using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerTracker : MonoBehaviour {

    Color color;
    Transform PlayerTransform;
    Transform PlayerBody;

    float xMovement;

    void Start () {
        color = GetComponent<SpriteRenderer>().material.color;
        xMovement = 0.1f;
        PlayerTransform = GameObject.Find("Player").GetComponent<Transform>();
        PlayerBody = GameObject.Find("Character Body").GetComponent<Transform>();
    }
	
	
	void Update () {
     
        if (PlayerBody.tag == "Stealthed" && PlayerTransform.position.x > transform.position.x -20 && PlayerTransform.position.x <= transform.position.x)
        {
            GetComponent<Renderer>().material.SetColor("_Color", color);
            this.transform.position = transform.position + new Vector3(-xMovement, 0, 0);
            color.a = 0.8f;
        }
        else if (PlayerBody.tag == "Stealthed" && PlayerTransform.position.x >= transform.position.x && PlayerTransform.position.x < transform.position.x + 20)
        {
            GetComponent<Renderer>().material.SetColor("_Color", color);
            this.transform.position = transform.position + new Vector3(+xMovement, 0, 0);
            color.a = 0.8f;
        }
        else if (PlayerBody.tag == "Unstealthed")
        {
            GetComponent<Renderer>().material.SetColor("_Color", color);
            color.a = 0f;          
        }
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && color.a != 0f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (collision.tag == "Bird")
        {
            Destroy(this.gameObject);
        }
    }
}
