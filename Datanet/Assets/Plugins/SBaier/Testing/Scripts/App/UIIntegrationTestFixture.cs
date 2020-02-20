using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace SBaier.Testing.UI
{
	public class UIIntegrationTestFixture : ZenjectIntegrationTestFixture
	{
		protected void PrepareHightMatchingCanvasStage(DiContainer container)
		{
			PrepareHightMatchingCanvasStage(container, new DefaultUITestingResourcePaths());
		}

		protected void PrepareHightMatchingCanvasStage(DiContainer container, UITestResourcePaths paths)
		{
			Container.Bind<UITestCanvas>().FromComponentInNewPrefabResource(paths.HightMatchingCanvasPath).AsSingle().NonLazy();
			Container.Bind<Camera>().FromComponentInNewPrefabResource(paths.TestCameraPath).AsSingle().NonLazy();
		}
	}
}