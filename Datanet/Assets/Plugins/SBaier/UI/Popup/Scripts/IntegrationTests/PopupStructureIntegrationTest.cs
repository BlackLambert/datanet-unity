using Zenject;
using System.Collections;
using UnityEngine.TestTools;
using NUnit.Framework;
using SBaier.Testing.UI;

namespace SBaier.Popup.Tests
{
	public class PopupStructureIntegrationTest : UIIntegrationTestFixture
	{
		private const string _prefabPath = "Prefabs/Tests/TestStructure"; 

		public void Install()
		{
			PreInstall();
			PrepareHightMatchingCanvasStage(Container);
			Container.Bind<PopupStructure>().FromComponentsInNewPrefabResource(_prefabPath).AsSingle();
			PostInstall();

			_structure.Base.SetParent(_testCanvas.Hook);
		}

		[Inject]
		private PopupStructure _structure = null;
		[Inject]
		private UITestCanvas _testCanvas = null;

		[UnityTest]
		public IEnumerator HasCorrectInitialValues()
		{
			Install();
			yield return 0;

			Assert.IsNotNull(_structure.Base);
			Assert.IsNotNull(_structure.ContentHook);
		}
	}
}