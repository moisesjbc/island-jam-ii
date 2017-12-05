using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript : MonoBehaviour {

	static bool audioBegin = false;
	public AudioClip menuMusic;
	// Use this for initialization

	void Start() {
		
	}
	void Awake () {
		if (!audioBegin) {
		
			GetComponent<AudioSource> ().loop = true;
			GetComponent<AudioSource> ().Play();
			DontDestroyOnLoad (gameObject);
			audioBegin = true;
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Application.loadedLevelName == "mapa1") {
			GetComponent<AudioSource> ().Stop ();
			audioBegin = false;
		}
	}
}
