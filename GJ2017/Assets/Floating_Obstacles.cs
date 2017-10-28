using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floating_Obstacles : MonoBehaviour {


    public float speed = 5f;
    Vector2 ran;
    Vector3 direction;
    // Use this for initialization
    void Start () {
        ran.x = Random.Range(-1, 1)*speed;
        ran.y = Random.Range(-1, 1)*speed;
        this.GetComponent<Rigidbody2D>().AddForce(ran);
        this.GetComponent<Rigidbody2D>().AddTorque(Random.Range(-50,50));
    }
	
	// Update is called once per frame
	void Update () {

    }
}
