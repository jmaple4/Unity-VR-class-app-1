using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public abstract class InputBase : MonoBehaviour 
{

	[Serializable]
	public class FloatEvent : UnityEvent<float> {}

	[Serializable]
	public class BoolEvent : UnityEvent<bool> {}

	[SerializeField] float delay = 2;

	[SerializeField] BoolEvent onStateChanged;
	[SerializeField] UnityEvent onPressed;
	[SerializeField] UnityEvent onReleased;
	[SerializeField] AnimationCurve timerUpdateCurve;
	[SerializeField] FloatEvent onTimerUpdate;
	[SerializeField] UnityEvent onTimerEnd;

	// float timer;
	
	private bool _pressed;
	public bool pressed
	{
		get { return _pressed; }
		protected set
		{
			if (value != _pressed)
			{
				_pressed = value;

				timer = 0;

				onStateChanged.Invoke (_pressed);

				if (_pressed)
					onPressed.Invoke();
				else
					onReleased.Invoke();
			}
		}
	}

	private float _timer;
	public float timer
	{
		get { return _timer; }
		set
		{
			if (value != _timer)
			{
				_timer = value;

				onTimerUpdate.Invoke (timerUpdateCurve.Evaluate (Mathf.InverseLerp(0, delay, _timer)));
					if (_timer > delay)
						onTimerEnd.Invoke();
			}
		}
	}

	protected virtual void Update ()
	{
		if (pressed)
			timer += Time.deltaTime;
	}

	void OnDisable ()
	{
		if (pressed)
			pressed = false;
	}

}