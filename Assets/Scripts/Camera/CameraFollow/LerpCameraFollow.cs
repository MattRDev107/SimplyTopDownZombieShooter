using System.Collections;
using UnityEngine;
using UnityEngine.Assertions.Must;

namespace TDS.Core.Camera
{
	public class LerpCameraFollow : MonoBehaviour, IFollow
	{
		[Range(0.0f, 1.0f)]
		[SerializeField] private float duration = 0.5f;

		private Vector3 _position;

		public void UpdateTargetPosition(Vector3 targetPosition)
		{
			Vector3 newPosition = Vector3.Lerp(transform.position, targetPosition, duration);
			_position = newPosition;
		}

		public Vector3 GetPosition()
		{
			return new Vector3(_position.x, _position.y, -10.0f);
		}
	}
}