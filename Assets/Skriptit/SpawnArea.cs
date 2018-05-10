using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnArea : MonoBehaviour {
	
	public Vector3 size;
	private Vector3 center;
	//private float nextSpawn = 0f;
	private float period = 1f;
	private float randomNumber;
	private float spawnFrequency;
	private int bunnyRandomizer;
	private float lastSpawned;
	private float timeBetweenSpawns;

	public GameObject Red;
	public GameObject Blue;
	public GameObject Yellow;

	// Use this for initialization
	void Start () {
		spawnFrequency = 3f;
		center = this.gameObject.transform.position;
		randomNumber = Random.Range(0f, 4f);
		//InvokeRepeating("SpawnEnemy", 0, spawnFrequency);
	}

	// Update is called once per frame
	void Update () { 

		// Testaukseen - nopeuta spawnaamista
		if (Input.GetKey (KeyCode.Q)) {
			spawnFrequency -= 0.5f;
		}

		if (Time.time - lastSpawned > spawnFrequency){
			lastSpawned = Time.time;
			SpawnEnemy();
		}

	}
	public void SpawnEnemy() {
		Vector3 pos = center + new Vector3 (Random.Range (-size.x / 2 , size.x / 2), 0, Random.Range (-size.z / 2 , size.z / 2));
		bunnyRandomizer = Random.Range(1, 4);

		if (bunnyRandomizer == 1 && GameObject.Find ("TextManager").GetComponent<TextManagerScript> ().playerHealth > 0) {
			Instantiate (Red, pos, Quaternion.identity);
		} 
		else if (bunnyRandomizer == 2 && GameObject.Find ("TextManager").GetComponent<TextManagerScript> ().playerHealth > 0) {
			Instantiate (Blue, pos, Quaternion.identity);
		} 
		else if (GameObject.Find ("TextManager").GetComponent<TextManagerScript> ().playerHealth > 0) {
			Instantiate (Yellow, pos, Quaternion.identity);
		}
		if (spawnFrequency > 1f) {
			spawnFrequency -= 0.1f;
		}

	}

	void OnDrawGizmosSelected () {
		Gizmos.color = Color.red;
		Gizmos.DrawCube (this.gameObject.transform.position, size);
	}
}
