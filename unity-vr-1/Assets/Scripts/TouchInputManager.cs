﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class TouchInputManager : MonoBehaviour 
{

	[Serializable]
	public class FloatEvent : UnityEvent<float> {}

	[SerializeField] float delay = 2;

	[SerializeField] UnityEvent onTouch;
	[SerializeField] UnityEvent onTouchCancel;
	[SerializeField] AnimationCurve timerUpdateCurve;
	[SerializeField] FloatEvent onTouchTimerUpdate;
	[SerializeField] UnityEvent onTouchTimerEnd;

	float timer;
	
	void Update () 
	{
		if (Input.touchCount > 0)
		{
			switch (Input.touches[0].phase)
			{
				case TouchPhase.Began:
					timer = 0;
					onTouch.Invoke();
					break;
				case TouchPhase.Ended:
					onTouchCancel.Invoke();
					break;
				default:
					timer += Time.deltaTime;
					onTouchTimerUpdate.Invoke (timerUpdateCurve.Evaluate (Mathf.InverseLerp(0, delay, timer)));
					if (timer > delay)
						onTouchTimerEnd.Invoke();
					break;
			}
		}
	}
}