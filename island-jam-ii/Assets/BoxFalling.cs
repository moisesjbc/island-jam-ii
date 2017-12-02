using UnityEngine;
using System.Collections;

public class BoxFalling : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y < -10.0) {
			Destroy (gameObject);
		}
	}
}
