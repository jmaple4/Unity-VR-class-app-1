using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePadInputManager : InputBase {

	[SerializeField] KeyCode keycode = KeyCode.Joystick1Button14;

	private bool connected = false;

	string[] controllers;

	IEnumerator CheckForControllers () 
	{
		while (true) {
			controllers = Input.GetJoystickNames ();
			if (!connected && controllers.Length > 0) {
				connected = true;
				Debug.Log ("Connected");
			} else if (connected && controllers.Length == 0) {
				connected = false;
				Debug.Log ("Disconnected");
			}
			yield return new WaitForSeconds (1f);
		}
	}

	void Awake () 
	{
		StartCoroutine (CheckForControllers ());
	}


	protected override void Update () 
	{
		
		pressed = Input.GetKey (keycode);
		base.Update();
	}



	void OnGUI ()
	{
		GUILayout.Label ("GamePad Connected : " + connected);
		if (connected)
		{
			for (int i = 0 ; i< controllers.Length ; i++)
				GUILayout.Label (controllers[i]);
		}
	}
}