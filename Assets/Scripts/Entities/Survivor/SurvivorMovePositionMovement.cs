using UnityEngine;

public class SurvivorMovePositionMovement : MonoBehaviour, IMovement
{
	private Rigidbody2D _rb;

	private void Awake()
	{
		_rb = gameObject.GetComponent<Rigidbody2D>();
	}

	public void HandleMovement(Vector2 movement)
	{
		Vector2 currentMovement = _rb.position + movement * Time.fixedDeltaTime;
		_rb.MovePosition(currentMovement);
	}
}
