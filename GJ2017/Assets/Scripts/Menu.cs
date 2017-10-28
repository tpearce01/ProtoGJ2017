using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {
	string sceneName = "tylers_scene";
	string mainMenuScene = "main_menu";

	[SerializeField] List<GameObject> menus = new List<GameObject>();

	void Update(){
		if (Input.GetKeyDown (KeyCode.Escape) || Input.GetKeyDown(KeyCode.P)) {
			menus [(int)MenuPanel.PauseMenu].SetActive (!menus [(int)MenuPanel.PauseMenu].activeSelf);
			if (menus [(int)MenuPanel.PauseMenu].activeSelf) {
				Time.timeScale = 0;
			} else {
				Time.timeScale = 1;
			}
		}
	}

	public void Resume(){
		Time.timeScale = 1;
		CloseAll ();
	}

	public void Restart(){
		//SceneManager.LoadScene (sceneName);
		Rocket.r.Reset();
		CloseAll ();
	}

	public void Shop(){
		CloseAll ();
		Pause ();
		menus [(int)MenuPanel.ShopMenu].SetActive (true);
	}

	public void PauseMenu(){
		CloseAll ();
		Pause ();
		menus [(int)MenuPanel.PauseMenu].SetActive (true);
	}

	public void IntermissionMenu(){
		Pause ();
		menus [(int)MenuPanel.IntermissionMenu].SetActive (true);
	}

	void CloseAll(){
		foreach (GameObject go in menus) {
			go.SetActive (false);
		}
	}

	public void Pause(){
		Time.timeScale = 0;
	}

	public void ExitToMainMenu(){
		SceneManager.LoadScene (mainMenuScene);
	}
}

public enum MenuPanel{
	PauseMenu = 0,
	ShopMenu = 1,
	IntermissionMenu = 2
}
