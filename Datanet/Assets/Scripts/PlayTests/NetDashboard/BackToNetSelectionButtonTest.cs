using Zenject;
using System.Collections;
using UnityEngine.TestTools;
using SBaier.Testing;
using UnityEngine;
using NUnit.Framework;
using TMPro;
using SBaier.SceneManagement;
using SBaier.Testing.UI;

namespace SBaier.Datanet.Tests
{
	public class BackToNetSelectionButtonTest : UIIntegrationTestFixture
	{
		public void Install()
		{
			PreInstall();

			//Setup scene
			PrepareHightMatchingCanvasStage(Container);

			//Bindings
			Container.Bind(typeof(SceneLoaderOnClick), typeof(SceneUnloaderOnClick), typeof(TextMeshProUGUI)).FromComponentInNewPrefabResource(ResourcePaths.NetDashboard_BackToNetSelectionButton).AsSingle().NonLazy();

			PostInstall();
		}


		[Inject]
		private SceneLoaderOnClick _sceneLoader = null;
		[Inject]
		private SceneUnloaderOnClick _sceneUnloader = null;

		[UnityTest]
		public IEnumerator HasCorrectTargetScenes()
		{
			Install();
			yield return 0;

			Assert.AreEqual(SceneNames.NetSelection, _sceneLoader.SceneName);
			Assert.AreEqual(SceneNames.NetWorkspaceScene, _sceneUnloader.SceneName);
		}
	}
}