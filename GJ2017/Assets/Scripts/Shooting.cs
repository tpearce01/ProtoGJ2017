using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

    Vector3 target;
    public GameObject bullet;
    public float speed = 3f;
    
	// Use this for initialization
	void Start () {

        target = transform.position;
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButton(0))
        {
            //...setting shoot direction
            Vector3 shootDirection;
            shootDirection = Input.mousePosition;
            shootDirection.z = 0.0f;
            shootDirection = Camera.main.ScreenToWorldPoint(shootDirection);
            shootDirection = shootDirection - transform.position;
            //...instantiating the rocket
            Rigidbody2D bulletInstance = Instantiate(bullet.GetComponent<Rigidbody2D>(), transform.position, Quaternion.Euler(new Vector3(0, 0, shootDirection.z))) as Rigidbody2D;
            
            bulletInstance.velocity = new Vector2(shootDirection.x * speed, shootDirection.y * speed);

        }


    }


}
