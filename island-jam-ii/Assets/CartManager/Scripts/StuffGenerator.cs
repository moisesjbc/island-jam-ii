using UnityEngine;
using System.Collections;

public class StuffGenerator : MonoBehaviour {

	public GameObject stuffPrefab;
	public GameObject leftSpawnPoint;
	public GameObject rightSpawnPoint;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

	public GameObject GenerateStuff(){
		// Set a random spawn position.
		float x = Random.Range (leftSpawnPoint.transform.position.x, rightSpawnPoint.transform.position.x);
		Vector3 spawnPoint = new Vector3 (x, leftSpawnPoint.transform.position.y, 0.0f);

		// Set a random spawn rotation.
		float angle = Random.Range (0.0f, 360.0f);
		Quaternion spawnRotation = Quaternion.AngleAxis (angle, Vector3.forward);

		// Instantiate new stuff and add it to the vector.
		GameObject newStuff = Instantiate (stuffPrefab, spawnPoint, spawnRotation) as GameObject;
		newStuff.transform.parent = transform;

		return newStuff;
	}
}
