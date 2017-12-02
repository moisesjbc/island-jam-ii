using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSCript : MonoBehaviour {

	public float speed= 0.2f;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.UpArrow)) {
			transform.position = new Vector3(transform.position.x, transform.position.y+(1*speed), transform.position.z);
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			transform.position = new Vector3(transform.position.x, transform.position.y-(1*speed), transform.position.z);
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.position = new Vector3(transform.position.x-(1*speed), transform.position.y, transform.position.z);
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			transform.position = new Vector3(transform.position.x+(1*speed), transform.position.y, transform.position.z);
		}
	}

	void OnCollisionEnter2D(Collision2D other) {
		Vector2 velocity = GetComponent<Rigidbody2D> ().velocity;
		GetComponent<Rigidbody2D>().AddForce(new Vector2(-(50+velocity.x),-(50+velocity.y)), ForceMode2D.Impulse);
		Debug.Log ("HA CHOCADO!");
		if (other.transform.tag == "Enemigo") {
			
		} else {
		
		}
		
	}


}
