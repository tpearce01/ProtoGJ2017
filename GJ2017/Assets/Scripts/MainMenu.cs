using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
	[SerializeField] string gameSceneName = "Main";

	void Awake(){
		//Screen.SetResolution (1024, 768, false);
	}


	public void StartGame(){
		SoundManager.i.PlaySound (Sound.button_press);
		SceneManager.LoadScene (gameSceneName);
	}

	public void QuitGame(){
		SoundManager.i.PlaySound (Sound.button_press);
		Application.Quit ();
	}
}
