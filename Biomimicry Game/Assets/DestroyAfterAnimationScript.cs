using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterAnimationScript : MonoBehaviour {
    Animator anim;
    // Update is called once per frame
    void Start()
    {
        anim = GetComponent<Animator>();
    }

 

	void Update () {
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Puff"))
        {
            Destroy(gameObject);
        }
	}
}
