using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCamera : MonoBehaviour
{
	[SerializeField] private Transform _targetPos;
	
	private IFollow _follow;

	private void Awake()
	{
		
		if(!TryGetComponent(out _follow))
		{
			gameObject.AddComponent<NullFollow>();
			Debug.LogWarning("Follow type have not be assigned to the Object");
		}

		RepositionCamera();
	}

	private void FixedUpdate()
	{
		RepositionCamera();
	}

	public void RepositionCamera()
	{
		_follow.UpdateTargetPosition(_targetPos.position);

		transform.position = _follow.GetPosition();
	}
}
