using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Navigator : MonoBehaviour 
{
	[Header ("Ray Casting")]
	[SerializeField] float wallSearchDistance = 5;
	[SerializeField] float offWallDistance = .5f;


	[SerializeField] LayerMask cullingMask = -5;
	[SerializeField] QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.Ignore;

	bool _wallHit;
	RaycastHit _wallHitInfo;
	Vector3 _wallHitPosition;
	Vector3 _wallHitNormal;
	Vector3 _wallBouncePosition;


	[Header ("Debug")]
	[SerializeField] bool drawLines = true;

	void Start () 
	{
		
	}
	
	void Update () 
	{

		_wallHit = Physics.Raycast(transform.position, transform.forward, out _wallHitInfo, wallSearchDistance + offWallDistance, cullingMask);
		if (_wallHit)
		{
			_wallHitPosition = _wallHitInfo.point;
			_wallHitNormal = _wallHitInfo.normal;
			_wallBouncePosition = _wallHitPosition + _wallHitNormal * offWallDistance;
		}
		else 
		{
			_wallHitPosition = transform.position + transform.forward * wallSearchDistance;
			// _wallHitNormal = -transform.forward;
			_wallBouncePosition = _wallHitPosition;
		}

		#if UNITY_EDITOR
		if (drawLines)
		{
			Debug.DrawLine(transform.position, _wallHitPosition, _wallHit ? Color.green : Color.yellow);
			Debug.DrawLine(_wallHitPosition, _wallBouncePosition, Color.blue);
			// Debug.DrawRay(transform.position, transform.forward * wallSearchDistance, Color.yellow);
		}
		#endif
	}
}
