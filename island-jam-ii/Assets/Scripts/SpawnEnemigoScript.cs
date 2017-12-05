using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemigoScript : MonoBehaviour {

	public int numEnemigos = 5;
	public GameObject enemigoEstatico;
	public GameObject enemigoRapido;


	public Sprite top_1;
	public Sprite side_1;
	public Sprite down_1;

	public Sprite top_2;
	public Sprite side_2;
	public Sprite down_2;
	public GameObject[] respawns;
	// Use this for initialization
	void Start () {
		respawns = GameObject.FindGameObjectsWithTag ("SpawnEnemigo");
		for (int i = 0; i < numEnemigos; i++) {
			int pos = Random.Range (0, respawns.Length);
			int typeEnemy = Random.Range (0, 2);
			if (typeEnemy == 0) {
				GameObject objeto = Instantiate(enemigoEstatico, respawns[pos].transform.position, respawns[pos].transform.rotation);
				objeto.GetComponent<EnemyScript> ().top = top_1;
				objeto.GetComponent<EnemyScript> ().side = side_1;
				objeto.GetComponent<EnemyScript> ().down = down_1;

			} else if (typeEnemy == 1) {
				GameObject objeto = Instantiate(enemigoRapido, respawns[pos].transform.position, respawns[pos].transform.rotation);
				objeto.GetComponent<EnemyScript> ().top = top_2;
				objeto.GetComponent<EnemyScript> ().side = side_2;
				objeto.GetComponent<EnemyScript> ().down = down_2;

			}
				
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
