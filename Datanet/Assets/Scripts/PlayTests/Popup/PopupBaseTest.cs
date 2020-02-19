using Zenject;
using System.Collections;
using UnityEngine.TestTools;
using SBaier.Testing.UI;
using TMPro;

namespace SBaier.Popup.Tests
{
	public class PopupBaseTest : UIIntegrationTestFixture
	{
		public void Install()
		{
			PreInstall();

			//Setup scene
			PrepareHightMatchingCanvasStage(Container);

			//Bindings
			//Container.Bind(typeof(SceneLoaderOnClick), typeof(SceneUnloaderOnClick), typeof(TextMeshProUGUI)).FromComponentInNewPrefabResource().AsSingle().NonLazy();

			PostInstall();
		}

		[UnityTest]
		public IEnumerator RunTest1()
		{
			// Setup initial state by creating game objects from scratch, loading prefabs/scenes, etc

			PreInstall();

			// Call Container.Bind methods

			PostInstall();

			// Add test assertions for expected state
			// Using Container.Resolve or [Inject] fields
			yield break;
		}
	}
}