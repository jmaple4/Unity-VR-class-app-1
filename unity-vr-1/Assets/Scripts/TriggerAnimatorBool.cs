using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Collider))]
public class TriggerAnimatorBool : MonoBehaviour 
{
	[SerializeField] string filterTag = "Player";
	[SerializeField] Animator animator;
	[SerializeField] string animatorBoolName;

	
	void OnTriggerEnter (Collider other)
	{
		// Debug.Log(other.name + "has entered " + gameObject.name, gameObject);
		animator.SetBool(animatorBoolName, true);
	}
	void OnTriggerExit (Collider other) 
	{
		// Debug.Log(other.name + "has exited " + gameObject.name, gameObject);
		animator.SetBool(animatorBoolName, false);

	}
}
