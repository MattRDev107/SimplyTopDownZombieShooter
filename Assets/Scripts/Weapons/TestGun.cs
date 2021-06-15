using System;
using System.Collections;
using UnityEngine;

namespace TDS.Weapons
{
    public class TestGun : MonoBehaviour, IWeapon
    {
		public float _range = 25.0f;
		public Transform _endOfBarral;

		private IFireProjectile _Prejectile;

		public void Awake()
		{
			_Prejectile = gameObject.GetComponent<IFireProjectile>();
		}

		public void Fire()
		{
			_Prejectile.FireBullet(_endOfBarral.position, transform.up, _range);
		}

		public void Reload()
		{

		}

		private IEnumerator RepeatFire(bool canFire)
		{
			yield return null;
		}
	}
}
