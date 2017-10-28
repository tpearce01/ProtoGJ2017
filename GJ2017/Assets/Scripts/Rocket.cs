using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rocket : MonoBehaviour {

	public static Rocket r;

	//Ship Variables
	[SerializeField] bool hasLaunched = false;
	[SerializeField] bool inSpace = false;
	[SerializeField] Rigidbody2D rocket;
	[SerializeField] ParticleSystem fuelEffect;
	Vector2 startPos;

	//Stat Variables
	public float maxFuel;
	[SerializeField]float currentFuel;
	public int enginePower;
	public int launchPower;
	public float maxShield;
	[SerializeField]float currentShield;
	public float drag;
	public int maxAmmo;
	[SerializeField]int currentAmmo;
	[SerializeField]Weapon weapon;

	//Environmental Variables
	[SerializeField]int orbitHeight;

	void Awake(){
		r = this;
	}

	void Start(){
		Initialize ();
		startPos = gameObject.transform.position;
	}

	void Update(){
		if (!hasLaunched) {
			//Check for launch
			if (Input.GetKeyDown (KeyCode.Space)) {
				Launch ();
			}
		} else {
			//If not in space, check for entry into space and adjust gravity accordingly
			if (!inSpace) {
				SetGravity ();
			}
		}
	}

	void FixedUpdate(){
		if (hasLaunched && currentFuel > 0) {
			Propel ();
		}
	}

	/// <summary>
	/// Default rocket values
	/// </summary>
	public void Initialize(){
		maxFuel = currentFuel = 10;
		maxAmmo = currentAmmo = 10;
		maxShield = currentShield = 10;
		enginePower = 10;
		launchPower = 1000;
		drag = 10;
		weapon = Weapon.Basic;
	}

	/// <summary>
	/// Reset stats to max value
	/// </summary>
	public void ResetStats(){
		currentFuel = maxFuel;
		currentAmmo = maxAmmo;
		currentShield = maxShield;
	}

	/// <summary>
	/// Sets gravity to 0 if the rocket reaches orbit
	/// </summary>
	void SetGravity(){
		if (gameObject.transform.position.y > orbitHeight) {
			rocket.gravityScale = 0;
			inSpace = true;
		}
	}

	/// <summary>
	/// Launches the rocket with a high force
	/// </summary>
	void Launch(){
		Debug.Log ("Launched");
		hasLaunched = true;
		rocket.AddForce (new Vector2 (0, launchPower));
		fuelEffect.gameObject.SetActive (true);
		fuelEffect.Play ();
	}

	/// <summary>
	/// Consumes fuel to add force to the rocket
	/// </summary>
	void Propel(){
		Debug.Log ("Fueling");
		currentFuel -= 0.1f;
		rocket.AddForce (new Vector2(0, enginePower));
		if (currentFuel <= 0) {
			fuelEffect.Stop();
		}
	}

	/// <summary>
	/// Get the fuel as a percentage
	/// </summary>
	/// <returns>The fuel percent.</returns>
	public float GetFuelPercent(){
		return currentFuel / maxFuel;
	}

	/// <summary>
	/// Reset rocket for new launch
	/// </summary>
	public void Reset(){
		rocket.velocity = Vector2.zero;
		hasLaunched = false;
		inSpace = false;
		rocket.gravityScale = 1;
		ResetStats ();
		gameObject.transform.position = startPos;
		fuelEffect.Stop ();
		fuelEffect.gameObject.SetActive (false);
	}

}

public enum Weapon{
	Basic = 0
}
