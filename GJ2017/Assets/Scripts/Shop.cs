using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour {

	public static Shop s;

	public int playerMoney = 0;

	int fuelLevel = 1;
	int engineLevel = 1;
	int shieldLevel = 1;
	int frameLevel = 1;
	int weaponLevel = 1;
	int ammoLevel = 1;

	[SerializeField] Text fuelText;
	[SerializeField] Text engineText;
	[SerializeField] Text shieldText;
	[SerializeField] Text frameText;
	[SerializeField] Text weaponText;
	[SerializeField] Text ammoText;
	[SerializeField] Text playerMoneyText;

	void Awake(){
		s = this;
	}

	void OnEnable(){
		SetText ();
	}

	public void UpgradeFuel(){
		SoundManager.i.PlaySound (Sound.button_press);
		if (playerMoney >= GetCost (fuelLevel)) {
			playerMoney -= GetCost (fuelLevel);
			fuelLevel++;
			Rocket.r.maxFuel += fuelLevel * fuelLevel;
			SetText ();
		}
	}

	public void UpgradeEngine(){
		SoundManager.i.PlaySound (Sound.button_press);
		if (playerMoney >= GetCost (engineLevel)) {
			playerMoney -= GetCost (engineLevel);
			engineLevel++;
			Rocket.r.enginePower += Rocket.r.enginePower / 2;
			SetText ();
		}
	}

	public void UpgradeShield(){
		SoundManager.i.PlaySound (Sound.button_press);
		if (playerMoney >= GetCost (shieldLevel)) {
			playerMoney -= GetCost (shieldLevel);
			shieldLevel++;
			Rocket.r.maxShield += shieldLevel * 5;
			SetText ();
		}
	}

	public void UpgradeFrame(){
		SoundManager.i.PlaySound (Sound.button_press);
		if (playerMoney >= GetCost (frameLevel)) {
			playerMoney -= GetCost (frameLevel);
			frameLevel++;
			Rocket.r.drag /= 1.1f;
			Rocket.r.turnSpeed *= 1.2f;
			SetText ();
		}
	}

	public void UpgradeAmmo(){
		SoundManager.i.PlaySound (Sound.button_press);
		if (playerMoney >= GetCost (ammoLevel)) {
			playerMoney -= GetCost (ammoLevel);
			ammoLevel++;
			Rocket.r.maxAmmo += 5;
			SetText ();
		}
	}

	public int GetCost(int level){
		return 25 * Mathf.Max((level * level * level)/2, 1);
	}

	public void SetText(){
		fuelText.text = "Cost: $" + GetCost (fuelLevel) + "k\nLevel: " + fuelLevel;
		engineText.text = "Cost: $" + GetCost (engineLevel) + "k\nLevel: " + engineLevel;
		shieldText.text = "Cost: $" + GetCost (shieldLevel) + "k\nLevel: " + shieldLevel;
		frameText.text = "Cost: $" + GetCost (frameLevel) + "k\nLevel: " + frameLevel;
		ammoText.text = "Cost: $" + GetCost (ammoLevel) + "k\nLevel: " + ammoLevel;
		playerMoneyText.text = "Player Money: $" + playerMoney + "k";
	}
}
