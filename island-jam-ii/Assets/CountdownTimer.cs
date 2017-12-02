using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {
	public float startTime = 60.0f;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		startTime -= Time.deltaTime;
	}
}
