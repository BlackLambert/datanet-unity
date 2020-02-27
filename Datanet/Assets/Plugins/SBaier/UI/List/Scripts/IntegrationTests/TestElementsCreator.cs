using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SBaier;

namespace SBaier.UI.List.Tests
{
	public class TestElementsCreator : ListElementsCreator<TestData, TestElement>
	{
		protected override SBaier.PrefabFactory.Parameter[] getPrefabFactoryParameters(TestData data)
		{
			return new PrefabFactory.Parameter[] { new PrefabFactory.Parameter(data) };
		}
	}
}
