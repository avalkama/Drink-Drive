using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManagerScript : MonoBehaviour {
	public Text scoreText;
	public Text healthText;
	public int playerHealth;
	public int score;

	public AudioSource sceneMusic;

	public AudioSource audio;
	public AudioSource deathAudio;

	public AudioClip hitSound1;
	public AudioClip hitSound2;
	public AudioClip damageSound1;
	public AudioClip damageSound2;
	public AudioClip damageSound3;
	public AudioClip damageSound4;

	public AudioClip deathSound;
	private bool playerDied;



	// Use this for initialization
	void Start () {
		playerHealth = 3;
		score = 0;
		audio = GetComponent<AudioSource>();
		playerDied = false;
	}
	
	// Update is called once per frame
	void Update () {
		scoreText.text = "Score: " + score;
		healthText.text = "Health: " + playerHealth;

		if (playerHealth == 0 && playerDied == false) {
			sceneMusic.clip = deathSound;
			sceneMusic.loop = false;
			sceneMusic.Play();
			playerDied = true;
		}
	}

	public void PointAndSound() {
		score++;

		if (Random.Range(0, 2) == 1) {
			audio.clip = hitSound1;
		} 
		else {
			audio.clip = hitSound2;
		}
		audio.Play();
	}
	public void DamageAndSound() {
		playerHealth--;
		int randomizer = Random.Range(0, 4);

		if (randomizer == 0) {
			audio.clip = damageSound1;
		} 
		else if (randomizer == 1) {
			audio.clip = damageSound2;
		}
		else if (randomizer == 2) {
			audio.clip = damageSound3;
		}
		else if (randomizer == 3) {
			audio.clip = damageSound4;
		}
		audio.Play();
	}
}
