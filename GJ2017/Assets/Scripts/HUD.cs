using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

	public static HUD hud;

	[SerializeField] Text metrics;
	[SerializeField] Rocket r;
	[SerializeField] Rigidbody2D rb;

	//HUD Variables
	[SerializeField]Slider fuelMeter;
	[SerializeField]Image fuelMeterFill;
	[SerializeField]Slider shieldMeter;
	[SerializeField]Image shieldMeterFill;

	public float heightOffset;

	void Awake(){
		hud = this;
	}

	void Start(){
		heightOffset = -r.transform.position.y;
	}

	void Update(){
		metrics.text = "Velocity: " + rb.velocity + "\n" +
			"Height: " + (r.transform.position.y + heightOffset).ToString("0.00") + "\n" + 
			"Ammo: " + Rocket.r.currentAmmo;
		SetFuelMeter ();
		SetShieldMeter ();
	}

	/// <summary>
	/// Sets the fuel meter fill value and color
	/// </summary>
	void SetFuelMeter(){
		float fuel = r.GetFuelPercent ();
		fuelMeter.value = fuel;
		fuelMeterFill.color = (fuel>.5f?Color.Lerp (Color.yellow, Color.green, (fuel - .5f) * 2):Color.Lerp(Color.red, Color.yellow, fuel*2));
	}

	void SetShieldMeter(){
		float shield = r.GetShieldPercent ();
		shieldMeter.value = shield;
		shieldMeterFill.color = (shield>.5f?Color.Lerp (Color.yellow, Color.blue, (shield - .5f) * 2):Color.Lerp(Color.white, Color.yellow, shield*2));
	}
}
