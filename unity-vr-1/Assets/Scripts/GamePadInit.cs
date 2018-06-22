using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePadInit : MonoBehaviour 
{

	private bool connected = false;

	string[] controllers;

	IEnumerator CheckForControllers () 
	{
		while (true) 
		{
			controllers = Input.GetJoystickNames ();
			if (!connected && controllers.Length > 0) 
			{
				connected = true;
				Debug.Log ("Connected");
			} 
			else if (connected && controllers.Length == 0) 
			{
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

	void OnGUI () 
	{
		GUILayout.Label ("GamePad Connected : " + connected);
		if (connected) {
			for (int i = 0; i < controllers.Length; i++)
				GUILayout.Label (controllers[i]);
		}
	}
}