using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objetoScript : MonoBehaviour {


	public GameObject spawnManager;
	public GameObject stuffManager;
	public AudioClip audio;
	public string objectType; //identifica el tipo de objeto que es "TV","PC",...
	public int id;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log ("RECOGER");
		if (other.transform.tag == "Player") {
			Debug.Log ("OBJETO RECOGIDO liberando "+id);
			//Call Add to Cart function
			//carrito.getComponent<Script>().addToCart();
			//empty the position to a new respawn
			spawnManager.GetComponent<SpawnManagerScript>().emptySpawn(id);
			stuffManager.GetComponent<CartManager> ().AddObject (this.objectType);
			spawnManager.GetComponent<SpawnManagerScript>().playSound();
			Debug.Log ("reproduciendo " + audio);
			Destroy (this.gameObject);
		}
	}
}
