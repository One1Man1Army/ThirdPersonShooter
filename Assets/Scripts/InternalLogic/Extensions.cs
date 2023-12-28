using UnityEngine;

namespace TPS.InternalLogic
{
	public static class Extensions
	{	
		public static float SqrMagnitudeTo(this Vector3 from, Vector3 to) => 
			Vector3.SqrMagnitude(to - @from);
	}
}