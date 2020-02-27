using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SBaier.Storage.Tests
{
	public class TestData
	{
		public int TestValue { get; private set; }

		public TestData(int testValue)
		{
			TestValue = testValue;
		}
	}
}