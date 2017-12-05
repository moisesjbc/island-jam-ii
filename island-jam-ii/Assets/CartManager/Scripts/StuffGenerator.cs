using UnityEngine;
using System.Collections;

public class StuffGenerator : MonoBehaviour {

	//public GameObject stuffPrefab;
	public GameObject leftSpawnPoint;
	public GameObject rightSpawnPoint;

	//
	public GameObject tv;
	public GameObject tacones;
	public GameObject planta;
	public GameObject pesas;
	public GameObject perfume;
	public GameObject pc;
	public GameObject martillo;
	public GameObject libro;
	public GameObject camara;
	public GameObject balon;
	public GameObject aspiradora;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

	public GameObject GenerateStuff(string type){
		// Set a random spawn position.
		float x = Random.Range (leftSpawnPoint.transform.position.x, rightSpawnPoint.transform.position.x);
		Vector3 spawnPoint = new Vector3 (x, leftSpawnPoint.transform.position.y, 0.0f);

		// Set a random spawn rotation.
		float angle = Random.Range (0.0f, 360.0f);
		Quaternion spawnRotation = Quaternion.AngleAxis (angle, Vector3.forward);

		// Instantiate new stuff and add it to the vector.

		GameObject stuffPrefab=null;

		switch (type) {
		case "TV":
			stuffPrefab = tv;
			break;
		case "TACONES":
			stuffPrefab = tacones;
			break;
		case "PLANTA":
			stuffPrefab = planta;
			break;
		case"PESAS":
			stuffPrefab = pesas;
			break; 
		case"PERFUME":
			stuffPrefab = perfume;
			break; 
		case"PC":
			stuffPrefab = pc;
			break; 
		case "MARTILLO":
			stuffPrefab = martillo;
			break; 
		case "LIBRO":
			stuffPrefab = libro;
			break; 
		case "CAMARA":
			stuffPrefab = camara;
			break; 
		case "BALON":
			stuffPrefab = balon;
			break; 
		case"ASPIRADORA":
			stuffPrefab = aspiradora;
			break;

		}
		GameObject newStuff = Instantiate (stuffPrefab, spawnPoint, spawnRotation) as GameObject;
		newStuff.transform.parent = transform;

		return newStuff;
	}
}
