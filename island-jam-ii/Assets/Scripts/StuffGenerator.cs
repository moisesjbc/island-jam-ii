﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class StuffGenerator : MonoBehaviour {

	public GameObject stuffPrefab;
	public GameObject leftSpawnPoint;
	public GameObject rightSpawnPoint;

	public List<GameObject> stuffObjects = new List<GameObject>();

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown (KeyCode.Space)){
			AddObject ();
		}else if(Input.GetKeyDown (KeyCode.S)){
			Shake ();
		}else if(Input.GetKeyDown (KeyCode.C)){
			Clear ();
		}
	}

	void AddObject(){
		// Set a random spawn position.
		float x = Random.Range (leftSpawnPoint.transform.position.x, rightSpawnPoint.transform.position.x);
		Vector3 spawnPoint = new Vector3 (x, leftSpawnPoint.transform.position.y, 0.0f);

		// Set a random spawn rotation.
		float angle = Random.Range (0.0f, 360.0f);
		Quaternion spawnRotation = Quaternion.AngleAxis (angle, Vector3.forward);

		// Instantiate new stuff and add it to the vector.
		GameObject newStuff = Instantiate (stuffPrefab, spawnPoint, spawnRotation) as GameObject;
		stuffObjects.Add (newStuff);
	}

	void Shake(int nStuff = 4) {
		// Check that there is something to remove.
		if (nStuff > 0) {
			// If we try to remove more stuff than we have we 
			// clamp the number.
			if (nStuff > stuffObjects.Count) {
				nStuff = stuffObjects.Count;
			}
			// Remove stuff.
			for (int i=0; i<nStuff; i++) {
				int removeElementIndex = Random.Range (0, stuffObjects.Count);
				Debug.Log (stuffObjects [0].transform.position);
				Destroy (stuffObjects [removeElementIndex].GetComponent <BoxCollider2D> ());
				stuffObjects [removeElementIndex].transform.Translate (Vector3.forward);
				stuffObjects.RemoveAt (removeElementIndex);
			}
		}
	}

	int Clear() {
		int nStuff = stuffObjects.Count;
		foreach(GameObject stuffObject in stuffObjects){
			Destroy (stuffObject);
		}
		stuffObjects.Clear ();
		return nStuff;
	}
}
