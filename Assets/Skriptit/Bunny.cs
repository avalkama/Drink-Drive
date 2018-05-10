using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bunny : MonoBehaviour {



	public Transform Player;

	private int MoveSpeed = 2;
	private double MaxDist = 0.7;
	private double MinDist = 0.5;

	void Start() {

	}

	void Update() {
		transform.LookAt(Player);

		if (Vector3.Distance(transform.position, Player.position) >= MinDist) {

			transform.position += transform.forward * MoveSpeed * Time.deltaTime;

			if (Vector3.Distance(transform.position, Player.position) <= MaxDist) {
				// Vähennä elämää
				if (GameObject.Find ("TextManager").GetComponent<TextManagerScript>().playerHealth > 0) {
					//GameObject.Find ("TextManager").GetComponent<TextManagerScript> ().playerHealth -= 1;
					GameObject.Find ("TextManager").GetComponent<TextManagerScript>().DamageAndSound();
				}
				// Tuhoa pupu
				Object.Destroy (this.gameObject);

			}

		}
	}
}
