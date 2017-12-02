using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class StuffGenerator : MonoBehaviour {

	public GameObject stuffPrefab;
	public GameObject leftSpawnPoint;
	public GameObject rightSpawnPoint;

	public List<GameObject> stuffObjects = new List<GameObject>();

	public float shakeForceMinX = 3.0f;
	public float shakeForceMaxX = 7.0f;
	public float shakeForceMinY = 3.0f;
	public float shakeForceMaxY = 7.0f;

	public ScoreManager scoreManager;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			AddObject ();
		} else if (Input.GetKeyDown (KeyCode.D)) {
			Shake ();
		}else if(Input.GetKeyDown (KeyCode.S)){
			Shake (false);
		}else if(Input.GetKeyDown (KeyCode.C)){
			Clear ();
		}
	}

	public void AddObject(){
		// Set a random spawn position.
		float x = Random.Range (leftSpawnPoint.transform.position.x, rightSpawnPoint.transform.position.x);
		Vector3 spawnPoint = new Vector3 (x, leftSpawnPoint.transform.position.y, 0.0f);

		// Set a random spawn rotation.
		float angle = Random.Range (0.0f, 360.0f);
		Quaternion spawnRotation = Quaternion.AngleAxis (angle, Vector3.forward);

		// Instantiate new stuff and add it to the vector.
		GameObject newStuff = Instantiate (stuffPrefab, spawnPoint, spawnRotation) as GameObject;
		newStuff.transform.parent = transform;
		stuffObjects.Add (newStuff);
	}

	public void Shake(bool remove=true, int nStuff = 4) {
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

				//stuffObjects [removeElementIndex].transform.Translate (Vector3.forward);
				Vector2 force = new Vector2(Random.Range (shakeForceMinX, shakeForceMaxX), Random.Range (shakeForceMinY, shakeForceMaxY));

				if(stuffObjects [removeElementIndex] != null && stuffObjects [removeElementIndex].GetComponent<Rigidbody2D>() != null){
					stuffObjects [removeElementIndex].GetComponent<Rigidbody2D>().AddForce (force, ForceMode2D.Impulse);
					if (remove) {
						Destroy (stuffObjects [removeElementIndex].GetComponent <BoxCollider2D> ());
						stuffObjects.RemoveAt (removeElementIndex);
					}
				}
			}
		}
	}

	public int Clear() {
		int nStuff = stuffObjects.Count;
		foreach(GameObject stuffObject in stuffObjects){
			Destroy (stuffObject);
		}
		stuffObjects.Clear ();
		scoreManager.AddScore (nStuff);
		return nStuff;
	}
}
