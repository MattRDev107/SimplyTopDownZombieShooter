using System;
using UnityEditor.UIElements;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Survivor : MonoBehaviour
{
	[SerializeField] private float _moveSpeed = 5.0f;
	public float MoveSpeed { get => _moveSpeed; set => _moveSpeed = value; }

	private Rigidbody2D _rb;

	private void Awake()
	{
		_rb = gameObject.GetComponent<Rigidbody2D>();
	}

	public void Move(Vector2 movementDir)
	{
		Vector2 movePos = _rb.position + movementDir.normalized * _moveSpeed * Time.fixedDeltaTime;
		_rb.MovePosition(movePos);
	}
}