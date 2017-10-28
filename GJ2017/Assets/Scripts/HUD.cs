using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

	[SerializeField] Text metrics;
	[SerializeField] Rocket r;
	[SerializeField] Rigidbody2D rb;

	void Update(){
		metrics.text = "Velocity: " + rb.velocity + "\n" +
		"Height: " + r.transform.position.y;
	}
}
