using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsScript : MonoBehaviour {

	public CartManager itemsCart;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		GetComponent<UnityEngine.UI.Text> ().text = "" + itemsCart.stuffObjects.Count;
	}
}
