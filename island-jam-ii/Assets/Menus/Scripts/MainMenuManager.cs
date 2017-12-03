using UnityEngine;
using System.Collections;

public class MainMenuManager : MonoBehaviour {

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
