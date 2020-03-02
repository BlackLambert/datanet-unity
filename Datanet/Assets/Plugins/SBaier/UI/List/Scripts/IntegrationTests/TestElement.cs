using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace SBaier.UI.List.Tests
{
	public class TestElement : MonoBehaviour
	{
		[Inject]
		private TestData _testData = null;
		public TestData TestData { get { return _testData; } }
	}
}
