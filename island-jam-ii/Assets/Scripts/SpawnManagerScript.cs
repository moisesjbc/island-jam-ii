using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerScript : MonoBehaviour {

	public AudioClip audioObjeto;
	public GameObject[] respawns;
	public List<int> usedRespawns;
	public GameObject stuffManager;
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
	public string[] types = {"TV","TACONES","PLANTA","PESAS","PERFUME","PC","MARTILLO","LIBRO","CAMARA","BALON","ASPIRADORA"};

	public float start = 5.0f;
	public float spawnTimer = 1.0f;
	// Use this for initialization
	void Start () {
		respawns = GameObject.FindGameObjectsWithTag ("Respawn");
		usedRespawns =new List<int>();
		InvokeRepeating ("Spawn", start, spawnTimer);

	}

	// Update is called once per frame
	void Update () {



	}

	void Spawn()
	{
		int pos = 0;
		if (usedRespawns.Count == respawns.Length) {
			return;
		}
		//do {
		pos = Random.Range (0, respawns.Length);
		//} while (usedRespawns.IndexOf(pos) > -1 ); //<--- descomentar bucle para obligar a que genere objeto
		if (usedRespawns.IndexOf (pos) == -1) {
			//objeto a instanciar es generado aleatoriamente ahora
			GameObject objectToRespawn = null;
			var typeObject = Random.Range(0, types.Length);
			switch (types[typeObject]) {
			case "TV":
				objectToRespawn = tv;
				break;
			case "TACONES":
				objectToRespawn = tacones;
				break;
			case "PLANTA":
				objectToRespawn = planta;
				break; 
			case"PESAS":
				objectToRespawn = pesas;
				break; 
			case"PERFUME":
				objectToRespawn = perfume;
				break; 
			case"PC":
				objectToRespawn = pc;
				break; 
			case "MARTILLO":
				objectToRespawn = martillo;
				break; 
			case "LIBRO":
				objectToRespawn = libro;
				break; 
			case "CAMARA":
				objectToRespawn = camara;
				break; 
			case "BALON":
				objectToRespawn = balon;
				break; 
			case"ASPIRADORA":
				objectToRespawn = aspiradora;
				break;

			}

			GameObject objeto = Instantiate(objectToRespawn, respawns[pos].transform.position, respawns[pos].transform.rotation);
			objeto.GetComponent<objetoScript>().id = pos;
			objeto.GetComponent<objetoScript>().spawnManager = this.gameObject;
			objeto.GetComponent<objetoScript> ().stuffManager = this.stuffManager;
			objeto.GetComponent<objetoScript> ().objectType = types [typeObject];
			objeto.GetComponent<objetoScript> ().audio = this.audioObjeto;
			usedRespawns.Add (pos);
		}
	}

	public void emptySpawn(int posToDestroy){
		if (usedRespawns.IndexOf (posToDestroy) > -1) {
			//the object position exist and was busy
			usedRespawns.RemoveAt(usedRespawns.IndexOf (posToDestroy));
		} else {
			Debug.Log("no lib");
		}
	}

	public void playSound() {
		GetComponent<AudioSource> ().PlayOneShot (audioObjeto, 1f);
	}
}
