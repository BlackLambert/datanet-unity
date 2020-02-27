using Zenject;
using System.Collections;
using UnityEngine.TestTools;
using NUnit.Framework;

namespace SBaier.Popup.Tests
{
	public class PopupContentCreatorIntegrationTest : ZenjectIntegrationTestFixture
	{
		private const string _prefabPath = "Prefabs/Tests/TestContent";
		private const string _popupPrefabPath = "Prefabs/Tests/TestContentPopup";

		public void Install()
		{
			PreInstall();
			Container.Bind<PopupContent>().FromResource(_prefabPath).AsSingle();
			Container.Bind<PrefabFactory>().AsSingle();
			Container.Bind(typeof(PopupInstaller), typeof(PopupContentCreator)).FromComponentsInNewPrefabResource(_popupPrefabPath).AsSingle().NonLazy();
			PostInstall();
		}

		[Inject]
		private PopupContent _contentPrefab = null;
		[Inject]
		private PopupContentCreator _contentCreator = null;

		[UnityTest]
		public IEnumerator HasCorrectInitialValues()
		{
			Install();
			yield return 0;

			Assert.IsNotNull(_contentCreator.Hook);
			Assert.IsNotNull(_contentPrefab.Base);
		}

		[UnityTest]
		public IEnumerator CreatesContent()
		{
			Install();
			yield return 0;

			Assert.IsNotNull(_contentCreator.Content);
		}

		[UnityTest]
		public IEnumerator ContentBaseHasHookAsParent()
		{
			Install();
			yield return 0;

			Assert.AreEqual(_contentCreator.Hook, _contentCreator.Content.Base.transform.parent);
		}
	}
}