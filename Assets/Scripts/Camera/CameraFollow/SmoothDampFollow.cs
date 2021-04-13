using System.Collections;
using UnityEngine;

namespace TDS.Core.Camera
{
	public class SmoothDampFollow : MonoBehaviour, IFollow
	{
		[SerializeField] private float smoothTime = 0.5f;

		private Vector3 _position;
		private Vector3 _currentVelocity;

		public void UpdateTargetPosition(Vector3 targetPosition)
		{
			Vector3 newPosition = Vector3.SmoothDamp(transform.position, targetPosition, ref _currentVelocity, smoothTime);
			_position = newPosition;
		}

		public Vector3 GetPosition()
		{
			return new Vector3(_position.x, _position.y, -10.0f);
		}
	}
}