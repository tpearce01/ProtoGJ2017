using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
	[SerializeField] string gameSceneName = "tylers_scene";

	void Awake(){
		Screen.SetResolution (1024, 768, false);
	}


	public void StartGame(){
		SceneManager.LoadScene (gameSceneName);
	}

	public void QuitGame(){
		Application.Quit ();
	}
}
