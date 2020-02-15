

using System.IO;
using UnityEngine;

namespace SBaier.Datanet.Tests
{
	public class UITestHelper
	{
		private const string _defaultTestCanvasPath = "Prefabs/Testing";
		private const string _defaultTestCanvasName = "DefaultTestCanvas";

		public GameObject CreateDefaultTestCanvas()
		{
			GameObject prefab = Resources.Load(Path.Combine(_defaultTestCanvasPath, _defaultTestCanvasName)) as GameObject;
			GameObject result = GameObject.Instantiate(prefab);
			result.name = _defaultTestCanvasName;
			return result;
		}

		public void DestroyDefaultCanvas()
		{
			GameObject.Destroy(GameObject.Find(_defaultTestCanvasName));
		}
	}
}