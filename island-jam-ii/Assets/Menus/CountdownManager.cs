using UnityEngine;
using System.Collections;

public class CountdownManager : MonoBehaviour {
	public float remainingTime = 60.0f;
	public RestartMenuManager restartMenuManager;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		// Update remaining time.
		remainingTime -= Time.deltaTime;

		// Display remaining time as mm:ss
		int seconds = (int)(remainingTime);
		int minutes = seconds / 60;
		seconds = seconds % 60;
		GetComponent<UnityEngine.UI.Text> ().text = "" + minutes.ToString("00") + ":" + seconds.ToString("00");

		if (minutes == 0 && seconds == 0) {
			remainingTime = 5.0f;
			restartMenuManager.Open();
		}
	}
}
