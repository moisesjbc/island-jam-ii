using UnityEngine;
using System.Collections;

public class RestartMenuManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//GetComponent<UnityEngine.UI.Panel> ().visible = false;
	}
	
	// Update is called once per frame
	public void Open () {
		Debug.Log ("ACTIVE!");
		Time.timeScale = 0.0f;
		gameObject.SetActive (true);
		//GetComponent<UnityEngine.UI.Panel> ().visible = true;
		//Time.timeScale = 0.0f;
	}

	public void Restart() {
		Debug.Log ("Restart");
		Time.timeScale = 1.0f;
		gameObject.SetActive (false);
		Application.LoadLevel(Application.loadedLevel);
	}
}
