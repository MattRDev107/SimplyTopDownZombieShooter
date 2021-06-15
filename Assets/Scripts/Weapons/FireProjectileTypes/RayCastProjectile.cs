using JetBrains.Annotations;
using System;
using UnityEngine;

namespace TDS.Weapons.FireBulletTypes
{
	public class RayCastProjectile : MonoBehaviour, IFireProjectile
	{
		public event Action<RaycastHit2D> OnBulletHit;

		public void FireBullet(Vector3 startPosition, Vector3 aimDirection, float range)
		{
			RaycastHit2D hit = Physics2D.Raycast(startPosition, aimDirection);

			if (hit.collider != null) OnBulletHit?.Invoke(hit);
		}
	}
}
