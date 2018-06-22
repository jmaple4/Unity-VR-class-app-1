using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.SceneManagement;



public class XRManager : MonoBehaviour {

	static XRManager _instance;

	void Awake () 
	{
		if (!_instance)
			_instance = this;
		else
			Destroy(gameObject);
		
		DontDestroyOnLoad (gameObject);
		SceneManager.activeSceneChanged += ActiveSceneChanged;
	}
	
	void ActiveSceneChanged (Scene arg0, Scene arg1) 
	{
		InputTracking.Recenter();
	}

	void Start () 
	{
		InputTracking.Recenter();
	}
	


}
