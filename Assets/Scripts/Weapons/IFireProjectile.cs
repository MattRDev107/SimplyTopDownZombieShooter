using System;
using UnityEngine;

namespace TDS.Weapons
{
	public interface IFireProjectile
	{
		public event Action<RaycastHit2D> OnBulletHit;
		public void FireBullet(Vector3 startPosition, Vector3 aimDirection, float range);
	}
}