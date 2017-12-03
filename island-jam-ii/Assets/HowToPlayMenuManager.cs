using UnityEngine;
using System.Collections;

public class HowToPlayMenuManager : MonoBehaviour {
	public void GoToMainMenu(){
		Application.LoadLevel ("MainMenu");
	}

	public void GoToHowToPlay2Menu(){
		Application.LoadLevel ("HowToPlay2Menu");
	}
}
