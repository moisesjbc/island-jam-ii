using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSCript : MonoBehaviour {

	public float speed= 10f;
	public float last_speed = 10f;
	public GameObject carrito;
	// Use this for initialization
	public GameObject hitSound;
	public AudioClip hit;
	public AudioClip enemySound;


	public Sprite top;
	public Sprite left;
	public Sprite right;
	public Sprite down;

	public float shieldTime=1000f;
	float nextHit=0f;

	void Start () {
		GetComponent<SpriteRenderer> ().sprite = top;
	}
	
	// Update is called once per frame
	void Update () {
		float peso_modif=1;
		//cada objeto elimina un 10% de speed
		peso_modif = 1 - ( carrito.GetComponent<CartManager> ().stuffObjects.Count * 0.1f);
		if (peso_modif < 0.1f) {
			peso_modif = 0.1f;
		}
		Debug.Log ("peso_modif " + peso_modif);
		if (Input.GetKey (KeyCode.UpArrow)) {

			GetComponent<SpriteRenderer> ().sprite = top;
			transform.position = new Vector3(transform.position.x, transform.position.y+(peso_modif*1*speed * Time.deltaTime), transform.position.z);
		}
		if (Input.GetKey (KeyCode.DownArrow)) {

			GetComponent<SpriteRenderer> ().sprite = down;
			transform.position = new Vector3(transform.position.x, transform.position.y-(peso_modif*1*speed * Time.deltaTime), transform.position.z);
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			GetComponent<SpriteRenderer> ().sprite = left;
			transform.position = new Vector3(transform.position.x-(peso_modif*1*speed * Time.deltaTime), transform.position.y, transform.position.z);
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			GetComponent<SpriteRenderer> ().sprite = right;
			transform.position = new Vector3(transform.position.x+(peso_modif*1*speed * Time.deltaTime), transform.position.y, transform.position.z);
		}
	}

	void OnCollisionEnter2D(Collision2D other) {
		Vector2 velocity = GetComponent<Rigidbody2D> ().velocity;
		//GetComponent<Rigidbody2D>().AddForce(new Vector2(-(1+velocity.x),-(1+velocity.y)), ForceMode2D.Impulse);
		//Debug.Log ("HA CHOCADO! " +Time.time + " espera hasta " + nextHit);
		if (other.transform.tag == "Enemigo") {
			if (nextHit < Time.time) {

				nextHit = Time.time + shieldTime;

				hitSound.GetComponent<AudioSource>().PlayOneShot (enemySound,1f);
				Debug.Log ("enemigo tocado! a " + Time.time + " proximo a "+nextHit);
				carrito.GetComponent<CartManager>().Shake(true);
			}
			//carrito.getComponent<Script>.enemigoTocado()
		} else {

			hitSound.GetComponent<AudioSource>().PlayOneShot (hit,0.1f);
		}
		
	}


}
