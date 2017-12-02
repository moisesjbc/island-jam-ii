using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			transform.Translate(Vector2.up);
		}
		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			transform.Translate(Vector2.down);
		}
	}
}
