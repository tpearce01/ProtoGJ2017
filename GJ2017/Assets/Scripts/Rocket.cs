using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

	bool hasLaunched = false;
	[SerializeField] Rigidbody2D rocket;
	[SerializeField] GameObject fuelEffect;

	[SerializeField]int maxFuel;
	[SerializeField]float currentFuel;
	[SerializeField]int enginePower;
	[SerializeField]int launchPower;
	[SerializeField]int shield;
	[SerializeField]float drag;
	[SerializeField]int maxAmmo;
	[SerializeField]int currentAmmo;
	[SerializeField]Weapon weapon;

	void Start(){
		Initialize ();
	}

	void Update(){
		if (!hasLaunched && Input.GetKeyDown (KeyCode.Space)) {
			Debug.Log ("Launched");
			hasLaunched = true;
			rocket.AddForce(new Vector2(0, launchPower));
			fuelEffect.SetActive (true);
			fuelEffect.GetComponent<ParticleSystem> ().Play ();
		}
	}

	void FixedUpdate(){
		if (hasLaunched && currentFuel > 0) {
			Debug.Log ("Fueling");
			currentFuel -= 0.1f;
			rocket.AddForce (new Vector2(0, enginePower));
			if (currentFuel <= 0) {
				fuelEffect.GetComponent<ParticleSystem>().Stop();
			}
		}
	}

	public void Initialize(){
		maxFuel = 10;
		currentFuel = 10;
		enginePower = 10;
		launchPower = 1000;
		shield = 10;
		drag = 10;
		maxAmmo = 10;
		currentAmmo = 10;
		weapon = Weapon.Basic;
	}
}

public enum Weapon{
	Basic = 0
}
