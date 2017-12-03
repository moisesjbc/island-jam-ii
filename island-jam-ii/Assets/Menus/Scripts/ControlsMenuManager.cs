using UnityEngine;
using System.Collections;

public class ControlsMenuManager : MonoBehaviour {
	public string gameSceneName = "";

	public void GoToHowToPlay2Menu(){
		Application.LoadLevel ("HowToPlay2Menu");
	}

	public void GoToGame(){
		Application.LoadLevel (gameSceneName);
	}
}
