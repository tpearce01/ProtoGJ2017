using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntermissionMenu : MonoBehaviour {
	[SerializeField] Text heightText;
	[SerializeField] Text moneyText;


	void OnEnable(){
		SetText ();
	}

	public void SetText(){
		heightText.text = Rocket.r.maxHeight.ToString("0.0") + "km.";
		moneyText.text = "$" + (int)(Rocket.r.maxHeight * 2);
	}

}
