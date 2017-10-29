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
	[SerializeField] ParticleSystem starEffect;
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
	public int currentAmmo;
	[SerializeField]Weapon weapon;
	public float turnSpeed;
	Quaternion baseRotation;

	//Environmental Variables
	public int orbitHeight;
	public int marsHeight;

	//Game Variables
	bool roundEnd = false;
	public float maxHeight = 0;
	bool isDead = false;

	float timeToRoundEndMaster;
	float timeToRoundEnd;

    //animation
    
    Animator anim;



    void Awake(){
		r = this;
	}

	void Start(){
		Initialize ();
		startPos = gameObject.transform.position;

        anim = GetComponent<Animator>();
//        explode = anim.GetComponent<Animation>();

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag =="obstacle")
        {
			ModifyShield (-6);
            if(currentShield <= 0)
            {
				Kill ();
            }

        }
    }

	void Kill(){
		anim.SetBool("dead", true);
		this.GetComponent<BoxCollider2D>().enabled = false;
		this.GetComponent<ParticleSystem>().Play();
		// anim.SetBool("dead", false);
		//if (!explode.IsPlaying("Normal_Rocket"))

		isDead = true;
	}

    void Update(){
		if (!hasLaunched && !Menu.m.MenuActive()) {
			//Check for launch
			if (Input.GetKeyDown (KeyCode.Space)) {
				Launch ();
			}
		} else {
			if (rocket.transform.position.y > maxHeight) {
				maxHeight = rocket.transform.position.y;
			}
			//If not in space, check for entry into space and adjust gravity accordingly
			if (!inSpace) {
				SetInSpace ();
			} else if (inSpace) {
				ParticleSystem.MainModule mm = starEffect.main;
				if (rocket.velocity.y > 0) {
					mm.gravityModifier = Mathf.Clamp ((rocket.velocity.y / 10), -10f, 10f);
				} else {
					mm.gravityModifier = rocket.velocity.y * 2;
				}
			}

			//Check for end of round
			if(!roundEnd && (rocket.velocity.y < 0 || isDead)){
				if (timeToRoundEnd <= 0) {
					EndRound ();
				} else {
					timeToRoundEnd -= Time.deltaTime;
				}
			}
		}

	}

	/// <summary>
	/// Called at the end of a round
	/// </summary>
	void EndRound(){
		roundEnd = true;
		starEffect.Stop ();
		maxHeight += HUD.hud.heightOffset;
		Shop.s.playerMoney += (int)maxHeight * 2;
		Menu.m.IntermissionMenu ();
        anim.SetBool("dead", false);
        this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        this.GetComponent<BoxCollider2D>().enabled = true;
    }

	void FixedUpdate(){
		if (!isDead) {
			if (hasLaunched && currentFuel > 0 && Input.GetKey (KeyCode.Space)) {
				Propel ();
			} else {
				fuelEffect.Stop ();
			}
			Movement ();
		}
	}

	/// <summary>
	/// Default rocket values
	/// </summary>
	public void Initialize(){
		maxFuel = currentFuel = 10;
		maxAmmo = currentAmmo = 10;
		maxShield = currentShield = 0;
		enginePower = 10;
		launchPower = 1000;
		drag = 1;
		weapon = Weapon.Basic;
		turnSpeed = 1;
		timeToRoundEnd = timeToRoundEndMaster = 1.5f;
		baseRotation = gameObject.transform.rotation;
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
	void SetInSpace(){
		if (gameObject.transform.position.y > orbitHeight) {
			rocket.gravityScale = 0.1f;
			inSpace = true;
			starEffect.gameObject.SetActive (true);
			starEffect.Play ();
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
		rocket.AddForce (transform.up * enginePower);
		if (currentFuel <= 0) {
			fuelEffect.Stop ();
		} else {
			fuelEffect.Play ();
		}
	}

	/// <summary>
	/// Get the fuel as a percentage
	/// </summary>
	/// <returns>The fuel percent.</returns>
	public float GetFuelPercent(){
		return currentFuel / maxFuel;
	}

	public float GetShieldPercent(){
		return currentShield>0?currentShield / maxShield:0;
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
		roundEnd = false;
		rocket.drag = drag;
		maxHeight = 0;
		timeToRoundEnd = timeToRoundEndMaster;
		gameObject.transform.rotation = baseRotation;
		starEffect.gameObject.SetActive (false);
		rocket.angularVelocity = 0;
		isDead = false;
		this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;

	}

	void Movement(){
		if (hasLaunched) {
			if (Input.GetKey (KeyCode.A)) {
				gameObject.transform.Rotate (0, 0, turnSpeed);
			}
			if (Input.GetKey (KeyCode.D)) {
				gameObject.transform.Rotate (0, 0, -turnSpeed);
			}
		}
	}

	/// <summary>
	/// Modifies the shield value.
	/// </summary>
	/// <param name="value">Value.</param>
	public void ModifyShield(int value){
		currentShield = Mathf.Clamp (currentShield + value, -1, maxShield);
	}

	/// <summary>
	/// Modifies the fuel value.
	/// </summary>
	/// <param name="value">Value.</param>
	public void ModifyFuel(int value){
		currentFuel = Mathf.Clamp (currentFuel + value, -1, maxFuel);
	}

	/// <summary>
	/// Modifies the ammo value.
	/// </summary>
	/// <param name="value">Value.</param>
	public void ModifyAmmo(int value){
		currentAmmo = Mathf.Clamp (currentAmmo + value, -1, maxAmmo);
	}

	public void Win(){
		Debug.Log ("You Win The Game!!");
		gameObject.GetComponent<SpriteRenderer> ().enabled = false;
		rocket.velocity = Vector2.zero;
		//Exit to main menu
	}
}
	

public enum Weapon{
	Basic = 0
}
