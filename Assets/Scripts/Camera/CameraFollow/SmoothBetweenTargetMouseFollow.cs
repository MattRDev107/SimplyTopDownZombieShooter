using MoonlanderCode.Core;
using UnityEngine;

public class SmoothBetweenTargetMouseFollow : MonoBehaviour, IFollow
{
	[SerializeField] private float maxRadius = 5.0f;
	[SerializeField] private float SmoothTime = 0.5f;

	private Vector3 _position;
	private Vector3 _mousePos;
	private PlayerInputs _input;

	private void OnEnable() => _input.Enable();
	private void OnDisable() => _input.Disable();

	private void Awake()
	{
		_input = new PlayerInputs();

		_input.CharacterControls.MousePos.performed += ctx => _mousePos = ctx.ReadValue<Vector2>();
	}

	public void UpdateTargetPosition(Vector3 targetPosition)
	{
		Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(_mousePos);
		Vector3 mouseOffset = (Vector3)mouseWorldPos - targetPosition;
		Vector3 newTarget = new Vector3(mouseOffset.x / 2.0f + targetPosition.x, mouseOffset.y / 2.0f + targetPosition.y, -10f);

		var distance = Vector2.Distance((Vector2)newTarget, (Vector2)targetPosition);

		if (distance > maxRadius)
		{
			Vector2 norm = mouseOffset.normalized;
			newTarget = new Vector3(norm.x * maxRadius + targetPosition.x, norm.y * maxRadius + targetPosition.y, -10f);
			_position = Vector3.Lerp(_position, newTarget, SmoothTime);
		}
		else
		{
			_position = Vector3.Lerp(_position, newTarget, SmoothTime);
		}
	}

	public Vector3 GetPosition()
	{
		return _position;
	}
}