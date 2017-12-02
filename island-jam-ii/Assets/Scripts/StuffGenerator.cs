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

		if(Input.GetKeyDown (KeyCode.Space)){
			float x = Random.Range (leftSpawnPoint.transform.position.x, rightSpawnPoint.transform.position.x);
			Vector3 spawnPoint = new Vector3 (x, leftSpawnPoint.transform.position.y, 0.0f);
			
			float angle = Random.Range (0.0f, 360.0f);
			Debug.Log (angle);
			Quaternion spawnRotation = Quaternion.AngleAxis (angle, Vector3.forward);
			Instantiate (stuffPrefab, spawnPoint, spawnRotation);
		}
	}
}
