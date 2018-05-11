using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerTracker : MonoBehaviour {

    Transform PlayerTransform;
    Transform PlayerBody;
    public GameObject Body;
    bool chasing;

    float xMovement;

    void Start () {
        xMovement = 0.1f;
        PlayerTransform = GameObject.Find("Player").GetComponent<Transform>();
        PlayerBody = GameObject.Find("Character Body").GetComponent<Transform>();
    }
	
	
	void Update () {   

        if (PlayerBody.tag == "Stealthed" && PlayerTransform.position.x > transform.position.x -20 && PlayerTransform.position.x <= transform.position.x)
        {
            chasing = true;
            Body.SetActive(true);
            this.transform.position = transform.position + new Vector3(-xMovement, 0, 0);  
        }
        else if (PlayerBody.tag == "Stealthed" && PlayerTransform.position.x >= transform.position.x && PlayerTransform.position.x < transform.position.x + 20)
        {
            chasing = true;
            Body.SetActive(true);
            this.transform.position = transform.position + new Vector3(+xMovement, 0, 0);
        }
        else if (PlayerBody.tag == "Unstealthed")
        {
            chasing = false;
            Body.SetActive(false);
        }
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && chasing == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (collision.tag == "Bird")
        {
            Destroy(this.gameObject);
        }
    }
}
