using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Renderer))]

public class MaterGradientModifier : MonoBehaviour
{
	Renderer _renderer;

	// public Color myColor;

	[SerializeField] Gradient gradient;

	float _gradientPosition;
	public float gradientPosition 
	{
		get { return _gradientPosition ; }
		set
		{
			if (_gradientPosition != value)
			{
				_gradientPosition = value;
				_renderer.material.color = gradient.Evaluate (_gradientPosition);
			}
		}
	}
	// void SetGradientPosition (float position) {
	// 	if (position == gradientPosition)
	// 	return;

	// 	gradientPosition = position;
	// 	_renderer.material.color = gradient.Evaluate (gradientPosition);
	// }

	void Awake ()
	{
		_renderer = GetComponent<Renderer>();
	}

	// Use this for initialization
	void Start()
	{
		gradientPosition = 0;
		// SetGradientPosition(0);
	}
	
	// Update is called once per frame
	// void Update()
	// {
	// 	// _renderer.material.color = gradient.Evaluate(gradientPosition);
	// 	SetGradientPosition(Mathf.Sin (((Time.time)) * 0.5f) + 0.5f );
	// }
}
