using RitchiesCode.Assets.RitchiesCode.Uiltities;
using TDS.Core;
using TDS.Weapons;
using UnityEngine;

namespace TDS.Entites.Survivor
{
	public class Survivor : MonoBehaviour
	{
		public float MoveSpeed { get => _moveSpeed; set => _moveSpeed = value; }

		private float _moveSpeed = 5.0f;

		private IMovement _movement;
		private IWeapon _equipedWeapon;

		private void Awake()
		{
			_movement = gameObject.GetComponent<IMovement>();

			//! Need to change to a weapon equipped system
			_equipedWeapon = GameObjectT.FindChildGameObjectWithName(this.gameObject, "PrimaryWeaponSlot").GetComponentInChildren<IWeapon>();
		}

		public void Move(Vector2 movement)
		{
			Vector2 currentMovement = movement.normalized * _moveSpeed;
			_movement.HandleMovement(currentMovement);
		}

		//? Move to Way-point for AI
		public void MoveToward(Vector2 target)
		{

		}

		public void LookAt(Vector2 target)
		{
			Vector2 targetDirection = target - (Vector2)transform.position;
			float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle - 90f));
		}

		public void Shoot()
		{
			_equipedWeapon.Fire();
		}
	}
}