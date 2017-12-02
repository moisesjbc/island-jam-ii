using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {
	public float speed;
	public int direccion = 1; //0:arriba, 1:derecha, 2: abajo, 3: izquierda
	public int ultima_direccion = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (direccion == 0) {
			transform.position = new Vector3 (transform.position.x, transform.position.y + 1 * speed, transform.position.z);
		}
		if (direccion == 1) {
			transform.position = new Vector3 (transform.position.x + 1 * speed, transform.position.y, transform.position.z);
		}
		if (direccion == 2) {
			transform.position = new Vector3 (transform.position.x, transform.position.y - 1 * speed, transform.position.z);
		}
		if (direccion == 3) {
			transform.position = new Vector3 (transform.position.x - 1 * speed, transform.position.y, transform.position.z);
		}
	}

	void OnCollisionEnter2D(Collision2D other) {
		
		direccion = Random.Range (0, 4);
		if (direccion == ultima_direccion) {
			direccion = (direccion + 1) % 4;
		}
		ultima_direccion = direccion;
		Debug.Log (direccion);
	}


}
