﻿using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {

	public int score = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void AddScore(int scoreDelta) {
		score += scoreDelta;
		GetComponent<UnityEngine.UI.Text> ().text = "" + score;
	}
}
