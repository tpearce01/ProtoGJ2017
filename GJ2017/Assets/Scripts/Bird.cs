using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {

    // Use this for initialization


    public float speed = 5f;
    public float range = 30f;
    Vector2 direction;
    GameObject camera;


    void Start () {
        camera = GameObject.FindGameObjectWithTag("MainCamera");
        direction.x = Random.Range(5, -5) * speed;
        
        direction.y = 0;
        if (direction.x == 0)
            direction.x = Random.Range(5, -5) * speed;
        if (direction.x < 0)
        {
            this.GetComponent<SpriteRenderer>().flipX = true;
        }

   


	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        this.GetComponent<SpriteRenderer>().enabled = false;

        this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
        //screenshake

        this.GetComponent<CircleCollider2D>().enabled = false;
        this.GetComponent<ParticleSystem>().Play();

        Destroy(this.gameObject, 2);
    }

    // Update is called once per frame
    void Update () {

        this.GetComponent<Rigidbody2D>().transform.Translate(direction*Time.deltaTime);

        if (Vector3.Distance(this.transform.position, camera.transform.position) >= range)
            Destroy(this.gameObject);
    }
}
