using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharcoManagerSCript : MonoBehaviour {
	public int numCharcos=4;
	public GameObject[] charcos;
	public GameObject objectToRespawn;
	// Use this for initialization
	void Start () {
		charcos = GameObject.FindGameObjectsWithTag ("Charco");
		//generate Charcos random when start game
		for (int i = 0; i < numCharcos; i++) {
			int pos = Random.Range (0, charcos.Length);
			GameObject objeto = Instantiate(objectToRespawn, charcos[pos].transform.position, charcos[pos].transform.rotation);


		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
