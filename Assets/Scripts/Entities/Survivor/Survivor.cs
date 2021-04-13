using System;
using UnityEngine;

public class Survivor : MonoBehaviour
{
	public float MoveSpeed { get => _moveSpeed; set => _moveSpeed = value; }

	private float _moveSpeed = 5.0f;

	private IMovement _movement;

	private void Awake()
	{
		_movement = gameObject.GetComponent<IMovement>();
	}

	public void Move(Vector2 movement)
	{
		Vector2 currentMovement = movement.normalized * _moveSpeed;
		_movement.HandleMovement(currentMovement);
	}

	public void MoveToward(Vector2 target)
	{

	}

	public void LookAt(Vector2 target)
	{
		Vector2 targetDirection = target - (Vector2)transform.position;
		float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle - 90f));
	}
}
