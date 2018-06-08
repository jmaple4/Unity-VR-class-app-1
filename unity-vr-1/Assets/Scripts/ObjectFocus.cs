using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class ObjectFocus : MonoBehaviour
{
	[Serializable]
	public class FloatEvent : UnityEvent<float> {}
	[SerializeField] Transform reference;

	[SerializeField] float minAngle = 10;
	[SerializeField] float maxAngle = 30;

	[SerializeField] UnityEvent valueChanged;

	private float _fadeAmount = -1;
	public float fadeAmount
	{
		get { return _fadeAmount; }
		set
		{
			if (value != _fadeAmount)
			{
				_fadeAmount = value;
				valueChanged.Invoke (_fadeAmount);
			}
		}
	}
	private float _delta = -1;
	public float delta
	{
		get { return _delta; }
		set
		{
			if (value != _delta)
			{
				_delta = value;
				// TODO: update fade amount
				fadeAmount = Mathf.InverseLerp (maxAngle, minAngle, _delta);
			}
		}
	}
	void Fade () {
		
		// Debug.DrawLine (reference.position, transform.position, Color.yellow);

		Vector3 d = (transform.position - reference.position).normalized;
		
		Debug.DrawRay (reference.position, d, Color.yellow);
		Debug.DrawRay (reference.position, reference.forward, Color.cyan);
		
		delta = Vector3.Angle (d.normalized, reference.forward);
	}
	void Awake ()
	{
		// reference = GameObject.FindGameObjectWithTag ("MainCamera").transform;
		if (!reference)
			reference = Camera.main.transform;
	}

	void Update ()
	{
		Fade ();
	}

	#if DEBUG
	void OnGUI()
	{
		GUILayout.Label ("delta : " + delta.ToString());
		GUILayout.Label ("fadeAmount : " + fadeAmount.ToString());
	}
	#endif
}
