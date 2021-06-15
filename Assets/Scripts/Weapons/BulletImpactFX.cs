using System;
using System.Collections;
using TDS.Weapons;
using UnityEngine;

namespace TDS.Assets.Scripts.Weapons
{
	public class BulletImpactFX : MonoBehaviour
	{
		[SerializeField] private GameObject _impactFX;

		private IFireProjectile _projectile;

		private void Start()
		{
			_projectile = gameObject.GetComponent<IFireProjectile>();
			_projectile.OnBulletHit += Projectile_OnBulletHit;
		}

		private void Projectile_OnBulletHit(RaycastHit2D hit)
		{
			SpawnImpactFX(hit.point);
		}

        private void SpawnImpactFX(Vector2 spawnPoint)
        {
			Instantiate(_impactFX, spawnPoint, Quaternion.identity);
        }
    }
}