using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {
	public float speed;
	public int direccion = 1; //0:arriba, 1:derecha, 2: abajo, 3: izquierda
	public int ultima_direccion = 1;

	public Sprite top;
	public Sprite side;
	public Sprite down;



	// Use this for initialization
	void Start () {
		InvokeRepeating ("Cambiar_direccion", 0f, 5f);
	}
	
	// Update is called once per frame
	void Update () {
		if (direccion == 0) {
			transform.position = new Vector3 (transform.position.x, transform.position.y + 1 * speed*Time.deltaTime, transform.position.z);
			GetComponent<SpriteRenderer> ().sprite = top;
		}
		if (direccion == 1) {
			transform.position = new Vector3 (transform.position.x + 1 * speed*Time.deltaTime, transform.position.y, transform.position.z);
			GetComponent<SpriteRenderer> ().sprite = side;
		}
		if (direccion == 2) {
			transform.position = new Vector3 (transform.position.x, transform.position.y - 1 * speed*Time.deltaTime, transform.position.z);
			GetComponent<SpriteRenderer> ().sprite = down;
		}
		if (direccion == 3) {
			transform.position = new Vector3 (transform.position.x - 1 * speed*Time.deltaTime, transform.position.y, transform.position.z);
			GetComponent<SpriteRenderer> ().sprite = side;
		}
	}

	void OnCollisionEnter2D(Collision2D other) {
		
		Cambiar_direccion ();
	}

	void Cambiar_direccion() {
		
		direccion = Random.Range (0, 4);
		if (direccion == ultima_direccion) {
			direccion = (direccion + 1) % 4;
		}
		ultima_direccion = direccion;

}
}
