using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RitchiesCode.Utilities
{
	public static class MathT
	{
		public static Vector2 VectorAbs(Vector2 vector)
		{
			return new Vector2(Mathf.Abs(vector.x), Mathf.Abs(vector.y));
		}

		public static Vector3 VectorAbs(Vector3 vector)
		{
			return new Vector3(Mathf.Abs(vector.x), Mathf.Abs(vector.y), Mathf.Abs(vector.z));
		}

		public static Vector2 VectorRound(Vector2 vector)
		{
			return new Vector2((float)Math.Round(vector.x), (float)Math.Round(vector.y));
		}

		public static Vector3 VectorRound(Vector3 vector)
		{
			return new Vector3((float)Math.Round(vector.x), (float)Math.Round(vector.y));
		}

		public static Vector2 VectorRound(Vector2 vector, int decimals)
		{
			return new Vector2((float)Math.Round(vector.x, decimals), (float)Math.Round(vector.y, decimals));
		}

		public static Vector3 VectorRound(Vector3 vector, int decimals)
		{
			return new Vector3((float)Math.Round(vector.x, decimals), (float)Math.Round(vector.y, decimals));
		}
	}
}