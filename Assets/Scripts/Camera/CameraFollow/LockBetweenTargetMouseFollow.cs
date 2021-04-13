using MoonlanderCode.Core;
using UnityEngine;

public class LockBetweenTargetMouseFollow : MonoBehaviour, IFollow
{
	[SerializeField]private float maxRadius = 5.0f;

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
		Vector3 newTargetPos = new Vector3(mouseOffset.x / 2.0f + targetPosition.x, mouseOffset.y / 2.0f + targetPosition.y, -10f);

		var distance = Vector2.Distance((Vector2)newTargetPos, (Vector2)targetPosition);

		if(distance > maxRadius)
		{
			Vector2 norm = mouseOffset.normalized;
			newTargetPos = new Vector3(norm.x * maxRadius + targetPosition.x, norm.y * maxRadius + targetPosition.y, -10f);
			_position = newTargetPos;
		}
		else
		{
			_position = newTargetPos;
		}
	}

	public Vector3 GetPosition()
	{
		return _position;
	}
}
