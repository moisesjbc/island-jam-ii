using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RestartMenuManager : MonoBehaviour {
	public InputField nameInputField;
	public ScoreManager scoreManager;
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

	IEnumerator WaitForWWW(WWW www) {
		yield return www;
		Debug.Log (www.text);
	}

	public void SendName() {
		var name = nameInputField.text;
		var score = scoreManager.score;

		WWW www;
		Hashtable postHeader = new Hashtable ();
		postHeader.Add ("Content-Type", "application/json");
		var formData = System.Text.Encoding.UTF8.GetBytes ("{'name':'" + name + "', 'score':"+score+"}");
		www = new WWW ("https://black-friday-ludum.appspot.com/_ah/api/ludumdarefriday/v1/login", formData, postHeader);
		//StartCoroutine (WaitForRequest (www));
		Debug.Log("send post");
		StartCoroutine(WaitForWWW(www));
	}

	public void seeScore() {
		Application.OpenURL ("https://black-friday-ludum.appspot.com");
	}

	public void goToMenu(){
		Time.timeScale = 1.0f;
		Application.LoadLevel ("MainMenu");
	}

	public void exitGame() {
		Application.Quit ();
	}
}
