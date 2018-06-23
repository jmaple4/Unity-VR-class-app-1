using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroscopeTracking : MonoBehaviour {

	#if UNITY_EDITOR

	void Awake ()
	{
		if (!enabled)
			return;
		transform.parent = new GameObject("Gyro Root").transform;
		transform.parent.rotation = Quaternion.Euler (0, 0, 60);
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
