using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour {

	[SerializeField]GameObject target;		//Target to follow
	[SerializeField]float lerpSpeed;		//Follow speed
	[SerializeField]float maxXDistance;		//Max difference between gameobject and target on x axis
	[SerializeField]float maxYDistanceUp; 	//Max difference between gameobject and target on y axis to north
	[SerializeField]float maxYDistanceDown; //Max difference between gameobject and target on y axis to south
	[SerializeField]Vector2 offset;			//Base offset
	[SerializeField]float zValue;			//set z value for gameObject

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector2 destination = Vector2.Lerp (gameObject.transform.position, target.transform.position + (Vector3)offset, lerpSpeed);
		gameObject.transform.position = new Vector3(
			Mathf.Clamp(destination.x, target.transform.position.x - maxXDistance, target.transform.position.x + maxXDistance), 
			Mathf.Clamp(destination.y, target.transform.position.y - maxYDistanceUp, target.transform.position.y + maxYDistanceDown), 
			zValue);
	}

	void Update(){
		gameObject.transform.position = new Vector3(
			Mathf.Clamp(gameObject.transform.position.x, target.transform.position.x - maxXDistance, target.transform.position.x + maxXDistance), 
			Mathf.Clamp(gameObject.transform.position.y, target.transform.position.y - maxYDistanceUp, target.transform.position.y + maxYDistanceDown), 
			zValue);
	}
}
