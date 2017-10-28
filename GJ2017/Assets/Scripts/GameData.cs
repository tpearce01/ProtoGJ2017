using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour {

	public int playerMoney;
	public float maxHeight;

	void Awake(){
		DontDestroyOnLoad (this);
	}
}
