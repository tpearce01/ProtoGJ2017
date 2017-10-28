﻿using System.Collections;
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
		if (playerMoney > GetCost (fuelLevel)) {
			playerMoney -= GetCost (fuelLevel);
			fuelLevel++;
			Rocket.r.maxFuel += fuelLevel * fuelLevel;
			SetText ();
		}
	}

	public void UpgradeEngine(){
		if (playerMoney > GetCost (engineLevel)) {
			playerMoney -= GetCost (engineLevel);
			engineLevel++;
			Rocket.r.enginePower += Rocket.r.enginePower / 2;
			SetText ();
		}
	}

	public void UpgradeShield(){
		if (playerMoney > GetCost (shieldLevel)) {
			playerMoney -= GetCost (shieldLevel);
			shieldLevel++;
			Rocket.r.maxShield += shieldLevel * 5;
			SetText ();
		}
	}

	public void UpgradeFrame(){
		if (playerMoney > GetCost (frameLevel)) {
			playerMoney -= GetCost (frameLevel);
			frameLevel++;
			Rocket.r.drag /= 1.1f;
			Rocket.r.turnSpeed *= 1.2f;
			SetText ();
		}
	}

	// !! INCOMPLETE !!
	public void UpgradeWeapon(){
		if (playerMoney > GetCost (weaponLevel)) {
			playerMoney -= GetCost (weaponLevel);
			weaponLevel++;
			SetText ();
		}
	}

	public void UpgradeAmmo(){
		if (playerMoney > GetCost (ammoLevel)) {
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
		fuelText.text = "Cost: $" + GetCost (fuelLevel);
		engineText.text = "Cost: $" + GetCost (engineLevel);
		shieldText.text = "Cost: $" + GetCost (shieldLevel);
		frameText.text = "Cost: $" + GetCost (frameLevel);
		weaponText.text = "Cost: $" + GetCost (weaponLevel);
		ammoText.text = "Cost: $" + GetCost (ammoLevel);
		playerMoneyText.text = "Player Money: $" + playerMoney;
	}
}
