using UnityEngine;
using System.Collections;

public class MainMenuManager : MonoBehaviour {
	public string gameSceneName = "mapa1";

	public void GoToGame(){
		Application.LoadLevel (gameSceneName);
	}

	public void GoToCreditsMenu(){
		Application.LoadLevel ("CreditsMenu");
	}

	public void GoToHowToPlayMenu(){
		Application.LoadLevel ("HowToPlayMenu");
	}

	public void Exit(){
		Application.Quit();
	}
}
