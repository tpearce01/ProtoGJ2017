using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_script : MonoBehaviour {
    BoxCollider2D self;
    // Use this for initialization
    void Start () {
        self = this.GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag =="Rocket" ||collision.gameObject.tag =="Bullet")
            Physics2D.IgnoreCollision(collision.collider, self);
        else
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update () {
        Destroy(this.gameObject, 0.5f);   
    }
}
