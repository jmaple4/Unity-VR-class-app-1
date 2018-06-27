using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Navigator : MonoBehaviour 
{
	[Header ("Ray Casting")]
	[SerializeField] float wallSearchDistance = 5;

	[Header ("Debug")]
	[SerializeField] bool drawLines = true;

	void Start () 
	{
		
	}
	
	void Update () 
	{
		#if UNITY_EDITOR
		if (drawLines)
		{
			Debug.DrawRay(transform.position, transform.forward * wallSearchDistance, Color.yellow);
		}
		#endif
	}
}
