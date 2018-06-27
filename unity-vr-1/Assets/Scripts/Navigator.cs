using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Navigator : MonoBehaviour 
{
	[Header ("Ray Casting")]
	[SerializeField] float wallSearchDistance = 5;

	bool _wallHit;
	RaycastHit _wallHitInfo;
	Vector3 _wallHitPosition;

	[Header ("Debug")]
	[SerializeField] bool drawLines = true;

	void Start () 
	{
		
	}
	
	void Update () 
	{

		_wallHit = Physics.Raycast(transform.position, transform.forward, out _wallHitInfo, wallSearchDistance);
		if (_wallHit)
		{
			_wallHitPosition = _wallHitInfo.point;
		}
		else 
		{
			_wallHitPosition = transform.position + transform.forward * wallSearchDistance;
		}

		#if UNITY_EDITOR
		if (drawLines)
		{
			Debug.DrawLine(transform.position, _wallHitPosition, _wallHit ? Color.green : Color.yellow);
			// Debug.DrawRay(transform.position, transform.forward * wallSearchDistance, Color.yellow);
		}
		#endif
	}
}
