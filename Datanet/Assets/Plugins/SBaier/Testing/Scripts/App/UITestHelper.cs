

using System.IO;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace SBaier.Testing.UI
{
	public class UITestHelper
	{
		private UITestResourcePaths _prefabPaths;

		[Inject]
		private void Construct(UITestResourcePaths prefabPaths)
		{
			_prefabPaths = prefabPaths;
		}

		public UITestCanvas CreateHightMatchingCanvas()
		{
			GameObject prefab = Resources.Load(_prefabPaths.HightMatchingCanvasPath) as GameObject;
			GameObject result = GameObject.Instantiate(prefab);
			UITestCanvas canvas = result.GetComponentInChildren<UITestCanvas>();

			if (canvas == null)
				throw new MissingComponentException($"The Canvas Object is missing the {nameof(UITestCanvas)}-Component. Please add it to the object or any children.");
			if (result.GetComponentInChildren<Canvas>() == null)
				throw new MissingComponentException($"The Canvas Object is missing the {nameof(Canvas)}-Component. Please add it to the object or any children.");
			if (result.GetComponentInChildren<CanvasScaler>() == null)
				throw new MissingComponentException($"The Canvas Object is missing the {nameof(CanvasScaler)}-Component. Please add it to the object or any children.");
			return canvas;
		}

		public Camera CreateTestCamera()
		{
			GameObject prefab = Resources.Load(_prefabPaths.TestCameraPath) as GameObject;
			GameObject result = GameObject.Instantiate(prefab);
			Camera camera = result.GetComponentInChildren<Camera>();

			if (camera == null)
				throw new MissingComponentException($"The Test Camera Object is missing the {nameof(Camera)}-Component. Please add it to the object or any children.");
			return camera;
		}
	}
}