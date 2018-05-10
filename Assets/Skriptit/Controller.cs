using System;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public float mouseSensitivity = 80.0f;
    public float clampAngle = 80.0f;

    private float rotY = 0.0f; // rotation around the y axis
    private float rotX = 0.0f; // rotation around the x axis

    void Start()
    {
        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = -Input.GetAxis("Mouse Y");

        rotY += mouseX * mouseSensitivity / 2.5f * Time.deltaTime;
        rotX += mouseY * mouseSensitivity / 2.5f * Time.deltaTime;

        rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);
        rotY = Mathf.Clamp(rotY, 0, 180);

        Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
		if (GameObject.Find ("TextManager").GetComponent<TextManagerScript> ().playerHealth > 0) {
			transform.rotation = localRotation;
		}
    }
}