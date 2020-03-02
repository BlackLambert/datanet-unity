using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SBaier.UI.List.Tests
{
	public class TestElementsCreator : ListElementsCreator<TestData, TestElement>
	{
		protected override PrefabFactory.Parameter[] getPrefabFactoryParameters(TestData data)
		{
			return new PrefabFactory.Parameter[] { new PrefabFactory.Parameter(data) };
		}
	}
}
