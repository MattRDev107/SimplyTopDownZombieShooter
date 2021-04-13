using UnityEngine;

public interface IFollow
{
	public void UpdateTargetPosition(Vector3 targetPosition);

	public Vector3 GetPosition();
}