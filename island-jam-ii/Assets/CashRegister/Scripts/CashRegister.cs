using UnityEngine;
using System.Collections;

public class CashRegister : MonoBehaviour {

	public CartManager cartManager;
	public AudioSource caja;
	public AudioClip sonido_caja;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.gameObject.tag == "Player") {
			Debug.Log ("Collision!!!!");
			caja.PlayOneShot (sonido_caja, 1f);
			cartManager.Clear ();
		}
	}
}
