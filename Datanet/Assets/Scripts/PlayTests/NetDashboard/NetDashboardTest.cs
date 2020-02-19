using Zenject;
using System.Collections;
using UnityEngine.TestTools;
using SBaier.Testing;
using SBaier.Testing.UI;

namespace SBaier.Datanet.Tests
{
	public class NetDashboardTest : UIIntegrationTestFixture
	{
		public void Install()
		{
			PreInstall();

			//Setup scene
			PrepareHightMatchingCanvasStage(Container);

			//Bindings
			//Container.Bind(typeof(SceneLoaderOnClick), typeof(SceneUnloaderOnClick), typeof(TextMeshProUGUI)).FromComponentInNewPrefabResource(ResourcePaths.ExistingNetsOverview).AsSingle().NonLazy();

			PostInstall();
		}
	}
}