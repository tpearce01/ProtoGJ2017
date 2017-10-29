using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mars : MonoBehaviour {
	public float rotationSpeed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		gameObject.transform.RotateAround (gameObject.transform.position, new Vector3 (0, 0, 1), rotationSpeed);
		gameObject.transform.position = new Vector2(Rocket.r.gameObject.transform.position.x, gameObject.transform.position.y);
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.CompareTag ("Player")) {
			Rocket.r.Win ();
		}
	}
}
