using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroscopeTracking : MonoBehaviour {

	#if UNITY_EDITOR

	void Awake ()
	{
		if (!enabled)
			return;

		Vector3 position = transform.position;
		Transform p = new GameObject("Gyro Root").transform;
		p.position = position;
		p.SetParent(transform.parent, true);
		transform.SetParent (p);

		// transform.parent = new GameObject("Gyro Root").transform;
		transform.parent.rotation = Quaternion.Euler (90, -90, 0);
		transform.rotation = Quaternion.identity;
	}

	void Start () 
	{
		Input.gyro.enabled = true;
	}
	
	void Update () 
	{
		transform.localRotation = GyroToUnity (Input.gyro.attitude);
	}

	private static Quaternion GyroToUnity(Quaternion q)
    {
        return new Quaternion(q.x, q.y, -q.z, -q.w);
    }
	#endif
}
