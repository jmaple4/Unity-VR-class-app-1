using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Navigator : MonoBehaviour 
{
	[Header ("Ray Casting")]
	[SerializeField] float wallSearchDistance = 5;
	[SerializeField] float offWallDistance = .5f;
	[SerializeField] float groundSearchDistance = 5;


	[SerializeField] LayerMask cullingMask = -5;
	[SerializeField] QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.Ignore;

	bool _wallHit;
	RaycastHit _wallHitInfo;
	Vector3 _wallHitPosition;
	Vector3 _wallHitNormal;
	Vector3 _wallBouncePosition;

	bool _groundHit;
	RaycastHit _groundHitInfo;
	Vector3 _groundHitPosition;

	Vector3 _targetLocation;

	private bool _hasTargetLocation;
	public bool hasTargetLocation
	{
		get { return _hasTargetLocation; }
		set
		{
			if (value != _hasTargetLocation)
			{
				_hasTargetLocation = value;
			}
		}
	}

	[Header ("Debug")]
	[SerializeField] bool drawLines = true;

	void Start () 
	{
		
	}
	
	void Update () 
	{

		_wallHit = Physics.Raycast(transform.position, transform.forward, out _wallHitInfo, wallSearchDistance + offWallDistance, cullingMask, queryTriggerInteraction);
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

		_groundHit = Physics.Raycast(_wallBouncePosition, Vector3.down, out _groundHitInfo, groundSearchDistance, cullingMask, queryTriggerInteraction);
		if (_groundHit)
		{
			_groundHitPosition = _groundHitInfo.point;
		}
		else 
		{
			hasTargetLocation = false;
		}

		#if UNITY_EDITOR
		if (drawLines)
		{
			Debug.DrawLine(transform.position, _wallHitPosition, _wallHit ? Color.green : Color.yellow);
			Debug.DrawLine(_wallHitPosition, _wallBouncePosition, Color.blue);
			if (_groundHit)
				Debug.DrawLine(_wallBouncePosition, _groundHitPosition, Color.cyan);
			// Debug.DrawRay(transform.position, transform.forward * wallSearchDistance, Color.yellow);
		}
		#endif
	}
}
