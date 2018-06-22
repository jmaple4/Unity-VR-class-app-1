﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePadInputManager : InputBase {

	[SerializeField] KeyCode keycode = KeyCode.Joystick1Button14;

	protected override void Update () 
	{
		
		pressed = Input.GetKey (keycode);
		base.Update();
	}

}