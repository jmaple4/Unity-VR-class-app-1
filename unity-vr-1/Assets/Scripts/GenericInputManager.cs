using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericInputManager : InputBase {

	[SerializeField] string input = "Fire1";

	protected override void Update () 
	{
		
		pressed = Input.GetButton (input);
		base.Update();
	}

}