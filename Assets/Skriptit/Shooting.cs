using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public GameObject Pacifier1;
    public float bulletImpulse = 50f;

    void Start()
    {

    }

    
    void Update()
    {


		if (Input.GetButtonDown("Fire1") && GameObject.Find ("TextManager").GetComponent<TextManagerScript> ().playerHealth > 0)
        {
            Camera cam = Camera.main;
            GameObject thebullet = Instantiate(Pacifier1, cam.transform.position + cam.transform.forward, transform.rotation);
            thebullet.GetComponent<Rigidbody>().AddForce(cam.transform.forward * bulletImpulse, ForceMode.Impulse);
        }
    }
}
