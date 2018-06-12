using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFocusManager : MonoBehaviour 
{

	List<ObjectFocus> objectsInRange = new List<ObjectFocus>();

	#region Singleton

	private static ObjectFocusManager _instance;
	public static ObjectFocusManager Instance 
	{
		get 
		{
			if (_instance == null)
			{
				_instance = FindObjectOfType<ObjectFocusManager>();

				if (_instance == null)
				{
					GameObject go = new GameObject ("ObjectFocusManager : Singleton");
					_instance = go.AddComponent<ObjectFocusManager>();

				}
			}
		}
		set 
		{
			_instance = value;
		}
	}

	#endregion

	#region MonoBehaviour
	void Start () 
	{

	}

	void Update () 
	{

	}
	#endregion
}