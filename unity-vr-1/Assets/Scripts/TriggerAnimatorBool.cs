using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Collider))]
public class TriggerAnimatorBool : MonoBehaviour 
{
	[SerializeField] string filterTag = "Player";
	[SerializeField] Animator animator;
	[SerializeField] string animatorBoolName;
	[SerializeField] bool trueOnExit;
	int _animatorBoolID;

	void Awake ()
	{
		if (!animator)
			animator = GetComponentInParent<Animator>();
		_animatorBoolID = Animator.StringToHash(animatorBoolName);
	}

	void OnTriggerEnter (Collider other)
	{
		if (!other.CompareTag(filterTag))
			return;

		// Debug.Log(other.name + "has entered " + gameObject.name, gameObject);
		animator.SetBool(_animatorBoolID, !trueOnExit);
	}
	void OnTriggerExit (Collider other) 
	{
		if (!other.CompareTag(filterTag))
			return;
		// Debug.Log(other.name + "has exited " + gameObject.name, gameObject);
		animator.SetBool(_animatorBoolID, trueOnExit);

	}
}
