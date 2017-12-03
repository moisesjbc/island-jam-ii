using UnityEngine;
using System.Collections;

public class HowToPlay2MenuManager : MonoBehaviour {
	public void GoToHowPlayMenu(){
		Application.LoadLevel ("HowToPlayMenu");
	}

	public void GoToControlsMenu(){
		Application.LoadLevel ("ControlsMenu");
	}
}
