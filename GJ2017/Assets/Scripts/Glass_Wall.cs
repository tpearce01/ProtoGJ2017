using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glass_Wall : MonoBehaviour {


    Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            anim.SetBool("Shatter", true);
            this.GetComponent<BoxCollider2D>().enabled = false;
      
   
        }
       

    }
    // Update is called once per frame


    void Update () {
        gameObject.transform.position = new Vector2(Rocket.r.gameObject.transform.position.x, gameObject.transform.position.y);
    }
}
