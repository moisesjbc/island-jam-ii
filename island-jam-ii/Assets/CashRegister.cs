using UnityEngine;
using System.Collections;

public class CashRegister : MonoBehaviour {

	public GameObject cart;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.gameObject.name == "Player") {
			Debug.Log ("Collision!!!!");
			cart.GetComponent<StuffGenerator> ().Clear ();
		}
	}
}
