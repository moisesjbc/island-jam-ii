using UnityEngine;
using System.Collections;

public class CashRegister : MonoBehaviour {

	public CartManager cartManager;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.gameObject.name == "Player") {
			Debug.Log ("Collision!!!!");
			cartManager.Clear ();
		}
	}
}
