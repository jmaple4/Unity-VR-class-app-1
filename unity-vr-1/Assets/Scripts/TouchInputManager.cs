// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;

public class TouchInputManager : InputBase 
{
	protected override void Update () 
	{
		pressed = (Input.touchCount > 0);
		base.Update();
	}
}
