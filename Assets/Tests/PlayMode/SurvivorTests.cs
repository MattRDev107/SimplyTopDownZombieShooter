using System;
using System.Collections;
using RitchiesCode.Utilities;
using NUnit.Framework;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.TestTools;
using Object = UnityEngine.Object;

namespace TopDownShooter.Tests.PlayMode
{
	public class SurvivorTests
	{
		public class Move
		{
			[UnityTearDown]
			public IEnumerator CleanScene()
			{
				foreach (var gameObject in Object.FindObjectsOfType<GameObject>())
				{
					Object.DestroyImmediate(gameObject);
				}

				yield return new WaitForEndOfFrame();
			}

			[UnityTest]
			public IEnumerator Vector_Z_Is_Zero()
			{
				Survivor survivor = A.Survivor.With<Rigidbody2D>();
				survivor.GetComponent<Rigidbody2D>().gravityScale = 0.0f;

				survivor.Move(Vector2.up);

				yield return new WaitForFixedUpdate();

				Assert.AreEqual(Vector3.zero.z, survivor.transform.position.z);
			}

			[UnityTest]
			public IEnumerator No_Direction_Then_No_Change()
			{
				Survivor survivor = A.Survivor.With<Rigidbody2D>();
				survivor.GetComponent<Rigidbody2D>().gravityScale = 0.0f;

				survivor.Move(Vector2.zero);

				yield return new WaitForFixedUpdate();

				Assert.AreEqual(Vector3.zero, survivor.transform.position);
			}

			[UnityTest]
			public IEnumerator Up_Direction_Then_Move_Up()
			{
				Survivor survivor = A.Survivor.With<Rigidbody2D>();
				survivor.GetComponent<Rigidbody2D>().gravityScale = 0.0f;

				survivor.Move(Vector2.up);
				
				yield return new WaitForFixedUpdate();
				
				Assert.AreEqual(MathT.VectorRound(new Vector3(0f, 1f,0f) * survivor.MoveSpeed * Time.fixedDeltaTime,2), 
					MathT.VectorRound(survivor.transform.position, 2));
			}

			[UnityTest]
			public IEnumerator Down_Direction_Then_Move_Down()
			{
				Survivor survivor = A.Survivor.With<Rigidbody2D>();
				survivor.GetComponent<Rigidbody2D>().gravityScale = 0.0f;

				survivor.Move(Vector2.down);
				
				yield return new WaitForFixedUpdate();

				Assert.AreEqual(MathT.VectorRound(new Vector3(0f, -1f, 0f) * survivor.MoveSpeed * Time.fixedDeltaTime,2), 
					MathT.VectorRound(survivor.transform.position, 2));
			}

			[UnityTest]
			public IEnumerator Left_Direction_Then_Move_Left()
			{
				Survivor survivor = A.Survivor.With<Rigidbody2D>();
				survivor.GetComponent<Rigidbody2D>().gravityScale = 0.0f;

				survivor.Move(Vector2.left);
				yield return new WaitForFixedUpdate();

				Assert.AreEqual(MathT.VectorRound(new Vector3(-1f, 0f, 0f) * survivor.MoveSpeed * Time.fixedDeltaTime,2), 
					MathT.VectorRound(survivor.transform.position, 2));
			}

			[UnityTest]
			public IEnumerator Right_Direction_Then_Move_Right()
			{
				Survivor survivor = A.Survivor.With<Rigidbody2D>();
				survivor.GetComponent<Rigidbody2D>().gravityScale = 0.0f;

				survivor.Move(Vector2.right);
				yield return new WaitForFixedUpdate();

				Assert.AreEqual(MathT.VectorRound(new Vector3(1f, 0f, 0f) * survivor.MoveSpeed * Time.fixedDeltaTime,2), 
					MathT.VectorRound(survivor.transform.position, 2));
			}
		}
	}
}