using System.Collections;
using UnityEngine;

namespace Assets
{
	public class LockCameraFollow: MonoBehaviour, IFollow
	{
		private Vector3 _position;

		public void UpdateTargetPosition(Vector3 targetPosition)
		{
			_position = new Vector3(targetPosition.x, targetPosition.y, -10.0f);
		}

		public Vector3 GetPosition()
		{
			return _position;
		}
	}
}