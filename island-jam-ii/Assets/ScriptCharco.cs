using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptCharco : MonoBehaviour {
	public AudioClip charcoSound;
	// Use this for initialization
	void Start () {

	}
	void OnTriggerEnter2D(Collider2D jugador) {
		if (!GetComponent<AudioSource> ().isPlaying) {
			GetComponent<AudioSource> ().PlayOneShot (charcoSound, 2f);
		}
		jugador.gameObject.GetComponent<playerSCript>().speed = 2f;
		Debug.Log ("Has resbalado");
	}
	void OnTriggerExit2D(Collider2D jugador) {
		jugador.gameObject.GetComponent<playerSCript>().speed = jugador.gameObject.GetComponent<playerSCript>().last_speed;
		Debug.Log ("saliendo charco");
		}

	// Update is called once per frame
	void Update () {

	}
}