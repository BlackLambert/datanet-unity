using Zenject;
using System.Collections;
using UnityEngine.TestTools;
using NUnit.Framework;
using SBaier.Testing.UI;

namespace SBaier.Popup.Tests
{
	public class PopupContentIntegrationTest : UIIntegrationTestFixture
	{
		private const string _prefabPath = "Prefabs/Tests/TestContent"; 

		public void Install()
		{
			PreInstall();
			PrepareHightMatchingCanvasStage(Container);
			Container.Bind<PopupContent>().FromComponentsInNewPrefabResource(_prefabPath).AsSingle();
			PostInstall();

			_content.Base.transform.SetParent(_testCanvas.Hook);
		}

		[Inject]
		private PopupContent _content = null;
		[Inject]
		private UITestCanvas _testCanvas = null;

		[UnityTest]
		public IEnumerator HasCorrectInitialValues()
		{
			Install();
			yield return 0;

			Assert.IsNotNull(_content.Base);
		}
	}
}