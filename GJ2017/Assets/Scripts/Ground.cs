using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.position = new Vector2 (Rocket.r.gameObject.transform.position.x, gameObject.transform.position.y);
	}
}
