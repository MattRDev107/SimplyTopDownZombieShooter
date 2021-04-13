using System.Collections;
using UnityEngine;


public class NullFollow :MonoBehaviour, IFollow
{
	public Vector3 GetPosition()
	{
		return transform.position;
	}

	public void UpdateTargetPosition(Vector3 position)
	{

	}
}
