using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SBaier.Persistence.Tests
{
	public class TestData 
	{
		public string TestString { get; set; }
		public int TestInt { get; set; }

		public override string ToString()
		{
			return $"TestData (TestString: {TestString} | TestInt: {TestInt})";
		}
	}
}