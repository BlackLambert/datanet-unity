using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace SBaier.Testing
{
	public class UIIntegrationTestFixture : ZenjectIntegrationTestFixture
	{
		protected void PrepareHightMatchingCanvasStage(DiContainer container, UITestPrefabPaths paths)
		{
			Container.Bind<UITestCanvas>().FromComponentInNewPrefabResource(paths.HightMatchingCanvasPath).AsSingle().NonLazy();
			Container.Bind<Camera>().FromComponentInNewPrefabResource(paths.TestCameraPath).AsSingle().NonLazy();
		}
	}
}