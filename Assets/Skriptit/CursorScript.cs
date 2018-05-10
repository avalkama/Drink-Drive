using UnityEngine;
using System.Collections;

public class CursorScript : MonoBehaviour
{
	CursorLockMode wantedMode;
    // Use this for initialization
    void Start()
    {
        //Set Cursor to not be visible
        Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
		//Cursor.visible = (CursorLockMode.Locked != wantedMode);
    }
	void Update() {
		if (GameObject.Find ("TextManager").GetComponent<TextManagerScript> ().playerHealth == 0) {
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}
		else if (Application.isFocused) {
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;
		}
	}
}