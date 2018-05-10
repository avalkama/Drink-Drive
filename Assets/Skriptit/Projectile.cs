using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	public Transform Player;
	//public AudioClip hitSound1;
	//public AudioSource audioSource;
	public AudioSource audio;

    float lifespan = 3.0f;

    // Use this for initialization
    void Start()
    {
        this.gameObject.GetComponent<Rigidbody>().AddTorque(transform.up * 100);
		//audioSource = GetComponent<AudioSource>();
		audio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        lifespan -= Time.deltaTime;

        if (lifespan <= 0)
        {
            Explode();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
			audio.Play();
            Destroy(gameObject);
            Destroy(collision.gameObject);
            Debug.Log("Hello", gameObject);
			//GameObject.Find ("TextManager").GetComponent<TextManagerScript> ().score += 1;
			GameObject.Find ("TextManager").GetComponent<TextManagerScript> ().PointAndSound();
			//audioSource.clip = hitSound1;
			//audioSource.Play();
        }
    }

    void Explode()
    {
        Destroy(gameObject);
    }
}
