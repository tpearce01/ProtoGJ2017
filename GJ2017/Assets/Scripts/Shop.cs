using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour {

	public int playerMoney;

	int fuelLevel;
	int engineLevel;
	int shieldLevel;
	int frameLevel;
	int weaponLevel;
	int ammoLevel;

	Text fuelText;
	Text engineText;
	Text shieldText;
	Text frameText;
	Text weaponText;
	Text ammoText;

	void Start(){
		playerMoney = 1;
	}

	public void UpgradeFuel(){
		if (playerMoney > GetCost (fuelLevel)) {
			playerMoney -= GetCost (fuelLevel);
			fuelLevel++;
			Rocket.r.maxFuel += fuelLevel * fuelLevel;
		}
	}

	public void UpgradeEngine(){
		if (playerMoney > GetCost (engineLevel)) {
			playerMoney -= GetCost (engineLevel);
			engineLevel++;
			Rocket.r.enginePower += Rocket.r.enginePower / 2;
		}
	}

	public void UpgradeShield(){
		if (playerMoney > GetCost (shieldLevel)) {
			playerMoney -= GetCost (shieldLevel);
			shieldLevel++;
			Rocket.r.maxShield += shieldLevel * 5;
		}
	}

	public void UpgradeFrame(){
		if (playerMoney > GetCost (frameLevel)) {
			playerMoney -= GetCost (frameLevel);
			frameLevel++;
			Rocket.r.drag /= 2;
		}
	}

	// !! INCOMPLETE !!
	public void UpgradeWeapon(){
		if (playerMoney > GetCost (weaponLevel)) {
			playerMoney -= GetCost (weaponLevel);
			weaponLevel++;
		}
	}

	public void UpgradeAmmo(){
		if (playerMoney > GetCost (ammoLevel)) {
			playerMoney -= GetCost (ammoLevel);
			ammoLevel++;
			Rocket.r.maxAmmo += 5;
		}
	}

	public int GetCost(int level){
			return 100 * level * level;
	}

	public void SetText(){

	}
}
