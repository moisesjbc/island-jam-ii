using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CartManager : MonoBehaviour {

	public List<GameObject> stuffObjects = new List<GameObject>();
	
	public float shakeForceMinX = 3.0f;
	public float shakeForceMaxX = 7.0f;
	public float shakeForceMinY = 3.0f;
	public float shakeForceMaxY = 7.0f;

	public StuffGenerator stuffGenerator;
	public ScoreManager scoreManager;
	public AudioClip audioShake;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			/*AddObject ();
		} else if (Input.GetKeyDown (KeyCode.D)) {
			Shake ();
		}else if(Input.GetKeyDown (KeyCode.S)){*/
			Shake (false);
		/*}else if(Input.GetKeyDown (KeyCode.C)){
			Clear ();*/
		}
	}

	public void AddObject(string type){
		GameObject newStuff = stuffGenerator.GenerateStuff(type);
		stuffObjects.Add (newStuff);
	}

	public void Shake(bool remove=true, int nStuff = 4) {
		// Check that there is something to remove.
		if (nStuff > 0) {
			GetComponent<AudioSource> ().PlayOneShot (audioShake, 1f);
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
						Debug.Log ("removing " + stuffObjects);
						//Destroy (stuffObjects [removeElementIndex].GetComponent <BoxCollider2D> ());
						Collider2D[] colliders = stuffObjects [removeElementIndex].GetComponentsInChildren<Collider2D>( );
						foreach( Collider2D collider in colliders )
						{
							// remove the collider
							Destroy(collider);
						}
						stuffObjects.RemoveAt (removeElementIndex);
						Debug.Log ("still " + stuffObjects.Count); 
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
		//just to sure the clear
		stuffObjects.Clear ();
		Debug.Log ("emptying the cart");
		/*GameObject[] all_items_carro = GameObject.FindGameObjectsWithTag("item_carro");
		foreach(GameObject stuffObject in all_items_carro){
			Destroy (stuffObject);
		}*/
		scoreManager.AddScore (nStuff);
		return nStuff;
	}
}
