using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sky : MonoBehaviour {

	public static Sky s;

	[SerializeField]SpriteRenderer skySprite;

	// Use this for initialization
	void Start () {
		s = this;
	}

	void Update(){
		SetColor ();
	}	

	public void SetColor(){
		//Lerp(Desired, current, %)
		float height = Rocket.r.gameObject.transform.position.y + HUD.hud.heightOffset;

		if (height < Rocket.r.orbitHeight) {
			skySprite.color = Color.black;
			skySprite.color = Color.Lerp (new Color (156/255f, 239/255f, 255/255f), new Color (90/255f, 165/255f, 255/255f), height / Rocket.r.orbitHeight);
		} else if (height < Rocket.r.orbitHeight * 2) {
			skySprite.color = Color.Lerp (new Color (90/255f, 165/255f, 255/255f), new Color (8/255f, 19/255f, 32/255f), (height - Rocket.r.orbitHeight) / Rocket.r.orbitHeight);
		} else if (height < Rocket.r.marsHeight - Rocket.r.orbitHeight * 2) {
			//Keep near black
			//skySprite.color = new Color (8, 19, 32);
		} else if (height < Rocket.r.marsHeight - Rocket.r.orbitHeight) {
			//blk to DB
			skySprite.color = Color.Lerp (new Color (8/255f, 19/255f, 32/255f), new Color (194/255f, 105/255f, 52/255f), (height - (Rocket.r.marsHeight - (Rocket.r.orbitHeight * 2))) / Rocket.r.orbitHeight);
		} else if (height < Rocket.r.marsHeight) {
			//blk to DB
			skySprite.color = Color.Lerp (new Color (194/255f, 105/255f, 52/255f), new Color (254/255f, 191/255f, 143/255f), (height - (Rocket.r.marsHeight - Rocket.r.orbitHeight)) / Rocket.r.orbitHeight);
		} else {
			Debug.Log ("Not Valid");
		}
	}
}
