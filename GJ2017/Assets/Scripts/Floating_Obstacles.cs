using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floating_Obstacles : MonoBehaviour {


    public float speed = 5f;
    Vector2 ran;

    GameObject camera;
    float destory_distance = 30f;
    // Use this for initialization
    void Start () {

        camera = GameObject.FindGameObjectWithTag("MainCamera");

        //start floating at a random direction and spinning randomly
        ran.x = Random.Range(-1, 1)*speed;
        ran.y = Random.Range(-1, 1)*speed;
        this.GetComponent<Rigidbody2D>().AddForce(ran);
        this.GetComponent<Rigidbody2D>().AddTorque(Random.Range(-50,50));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //hide the obstacle for now
        this.GetComponent<SpriteRenderer>().enabled = false;
      
        //stop the obstacle from moving
        this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
        
        //something screenshake
        //something screenshake


        //shut the collider to prevent exploding effect twice
        this.GetComponent<PolygonCollider2D>().enabled = false;

        //destory object
        this.GetComponent<ParticleSystem>().Play();
       
        Destroy(this.gameObject,2);
    }   
    // Update is called once per frame
    void Update () {

        if (Vector3.Distance(this.transform.position, camera.transform.position) >= destory_distance) 
        {
            Destroy(this.gameObject);
        }
        
    }
}
