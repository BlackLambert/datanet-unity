using Zenject;
using System.Collections;
using UnityEngine.TestTools;
using NUnit.Framework;

namespace SBaier.Popup.Tests
{
	public class PopupStructureCreatorIntegrationTest : ZenjectIntegrationTestFixture
	{
		private const string _prefabPath = "Prefabs/Tests/TestStructure";
		private const string _popupPrefabPath = "Prefabs/Tests/TestStructurePopup";

		public void Install()
		{
			PreInstall();
			Container.Bind<PopupStructure>().FromResource(_prefabPath).AsSingle();
			Container.Bind<PrefabFactory>().AsSingle();
			Container.Bind(typeof(PopupInstaller), typeof(PopupStructureCreator)).FromComponentsInNewPrefabResource(_popupPrefabPath).AsSingle().NonLazy();
			PostInstall();
		}

		[Inject]
		private PopupStructure _structurePrefab = null;
		[Inject]
		private PopupStructureCreator _structureCreator = null;

		[UnityTest]
		public IEnumerator HasCorrectInitialValues()
		{
			Install();
			yield return 0;

			Assert.IsNotNull(_structureCreator.Hook);
			Assert.IsNotNull(_structurePrefab.Base);
		}

		[UnityTest]
		public IEnumerator CreatesStructure()
		{
			Install();
			yield return 0;

			Assert.IsNotNull(_structureCreator.Structure);
		}

		[UnityTest]
		public IEnumerator ContentBaseHasHookAsParent()
		{
			Install();
			yield return 0;

			Assert.AreEqual(_structureCreator.Hook, _structureCreator.Structure.Base.transform.parent);
		}
	}
}