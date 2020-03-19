using System;
using UnityEngine;

namespace SBaier.Serialization.String.Tests
{
	[Serializable]
	public class TestInnerSerializable
	{
		private int _num;
		public int Num { get { return _num; } }

		public TestInnerSerializable(int num)
		{
			_num = num;
		}
	}
}