using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputWASDExample : MonoBehaviour {

	void Update ()
	{
		UseIJKL();
		UseWASD();
	}


	private void UseWASD()
	{
		float vertical = Input.GetAxis("Vertical");
		if (vertical != 0f ) {
			transform.Translate (Vector3.forward * (vertical * 5f * Time.deltaTime));
		}

		float horizontal = Input.GetAxis ("Horizontal");
		if (horizontal != 0f) {
			transform.Rotate (Vector3.up, 50f * Time.deltaTime * horizontal);
		}

		if ( Input.GetButtonDown ("Jump") ) { // teleport
			transform.Translate (Vector3.forward * 3f);
		}
	}

	private void UseIJKL()
	{
		float vertical = Input.GetAxis("MyVertical");

		if (vertical != 0f ) {
			transform.Translate (Vector3.forward * (vertical * 5f * Time.deltaTime));
		}

		float horizontal = Input.GetAxis ("MyHorizontal");
		if (horizontal != 0f) {
			transform.Rotate (Vector3.up, 50f * Time.deltaTime * horizontal);
		}

		if ( Input.GetButtonDown ("Jump") ) { // teleport
			transform.Translate (Vector3.forward * 3f);
		}
	}
	
}
