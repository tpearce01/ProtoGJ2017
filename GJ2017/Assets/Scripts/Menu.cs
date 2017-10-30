using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {
	public static Menu m;

	int menuActive = -1;

	[SerializeField] List<GameObject> menus = new List<GameObject>();

	void Awake(){
		m = this;
		OpenMenu (MenuPanel.Shop);
	}

	void Start(){
		CloseActiveMenu ();
	}

	void Update(){
		//Allow Pause / Unpause using Escape or P
		if (Input.GetKeyDown (KeyCode.Escape) || Input.GetKeyDown(KeyCode.P)) {
			if (!MenuActive ()) {	//If no active menu, open Pause menu
				PauseMenu ();
			} else if(menuActive == (int)MenuPanel.Pause) {	//If Pause menu active, close it
				Resume ();
			}

		}
	}

	public void PlayButtonAudio(){
		SoundManager.i.PlaySound (Sound.button_press);
	}

	/// <summary>
	/// Close active menu and resume game
	/// </summary>
	public void Resume(){
		Time.timeScale = 1;
		CloseActiveMenu ();
	}

	/// <summary>
	/// Return to game and reset the game
	/// </summary>
	public void Restart(){
		Rocket.r.Reset();
		Resume ();
	}

	/// <summary>
	/// Open the Shop menu
	/// </summary>
	public void Shop(){
		CloseActiveMenu ();
		OpenMenu (MenuPanel.Shop);
	}

	/// <summary>
	/// Pause the game and open the pause menu
	/// </summary>
	public void PauseMenu(){
		Pause ();
		OpenMenu (MenuPanel.Pause);
	}

	/// <summary>
	///  Pause the game and open the intermission menu
	/// </summary>
	public void IntermissionMenu(){
		Pause ();
		OpenMenu (MenuPanel.Intermission);
	}

	/// <summary>
	/// Pause the game
	/// </summary>
	public void Pause(){
		Time.timeScale = 0;
	}

	public void ExitGame(){
		Application.Quit ();
	}

	/// <summary>
	/// Returns true if a menu is currently active
	/// </summary>
	/// <returns><c>true</c>, if active was menued, <c>false</c> otherwise.</returns>
	public bool MenuActive(){
		return !(menuActive == -1);
	}

	/// <summary>
	/// Closes the current menu
	/// </summary>
	void CloseActiveMenu(){
		if(menuActive != -1){
			menus [menuActive].SetActive (false);
			menuActive = -1;
		}
	}

	/// <summary>
	/// Opens the specified menu.
	/// </summary>
	/// <param name="mp">Mp.</param>
	void OpenMenu(MenuPanel mp){
		OpenMenu ((int)mp);
	}

	/// <summary>
	/// Opens the specified menu
	/// </summary>
	/// <param name="i">The index.</param>
	void OpenMenu(int i){
		menus [i].SetActive (true);
		menuActive = i;
	}
		
}

public enum MenuPanel{
	Pause = 0,
	Shop = 1,
	Intermission = 2
}
