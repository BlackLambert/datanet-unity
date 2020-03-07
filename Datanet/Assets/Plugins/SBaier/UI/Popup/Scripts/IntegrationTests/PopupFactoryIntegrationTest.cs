using Zenject;
using NUnit.Framework;
using UnityEngine;
using System;
using UnityEngine.TestTools;
using System.Collections;

namespace SBaier.UI.Popup
{
	[TestFixture]
	public class PopupFactoryIntegrationTest : ZenjectIntegrationTestFixture
	{
		private const string _popupPrefabPath = "Prefabs/Tests/TestPopup";
		private const string _popupStructurePrefabPath = "Prefabs/Tests/TestStructure";
		private const string _popupContentsPrefabPath = "Prefabs/Tests/TestContent";
		private const string _emptyCreationDataID = "Empty";
		private const string _fullCreationDataID = "Full";
		private const string _prefabOnlyCreationDataID = "PrefabOnly";

		public void Install()
		{
			PreInstall();
			_popupPrefab = (Resources.Load(_popupPrefabPath) as GameObject).GetComponentInChildren<PopupInstaller>();
			_popupStructurePrefab = (Resources.Load(_popupStructurePrefabPath) as GameObject).GetComponentInChildren<PopupStructure>();
			_popupContentPrefab = (Resources.Load(_popupContentsPrefabPath) as GameObject).GetComponentInChildren<PopupContent>();
			Container.Bind<PopupCreationData>().WithId(_prefabOnlyCreationDataID).FromInstance(new PopupCreationData(_popupPrefab, null, null)).AsTransient();
			Container.Bind<PopupCreationData>().WithId(_emptyCreationDataID).FromInstance(new PopupCreationData(null, null, null)).AsTransient();
			Container.Bind<PopupCreationData>().WithId(_fullCreationDataID).FromInstance(new PopupCreationData(_popupPrefab, _popupStructurePrefab, _popupContentPrefab)).AsTransient();
			Container.Bind<PopupFactory>().To<PopupFactoryImpl>().AsSingle();
			Container.Bind<PrefabFactory>().AsSingle();
			PostInstall();
		}

		private PopupInstaller _popupPrefab;
		private PopupStructure _popupStructurePrefab;
		private PopupContent _popupContentPrefab;
		[Inject]
		private PopupFactory _popupFactory = null;
		[Inject(Id = _emptyCreationDataID)]
		private PopupCreationData _emptyData = null;
		[Inject(Id = _prefabOnlyCreationDataID)]
		private PopupCreationData _prefabOnlyData = null;
		[Inject(Id = _fullCreationDataID)]
		private PopupCreationData _fullData = null;

		[Test]
		public void FailsOnMissingPopupPrefab()
		{
			Install();
			Assert.Throws<ArgumentNullException>(() => _popupFactory.Create(_emptyData));
		}

		[Test]
		public void FailsOnCreationDataNull()
		{
			Install();
			Assert.Throws<ArgumentNullException>(() => _popupFactory.Create(null));
		}

		[Test]
		public void CreatesPopupWithPrefabOnlyCreationData()
		{
			Install();
			PopupInstaller installer = _popupFactory.Create(_prefabOnlyData);
			Assert.IsNotNull(installer);
			Assert.IsNotNull(GameObject.FindObjectOfType<PopupInstaller>());
			Assert.IsNull(installer.PopupContentPrefab);
			Assert.IsNull(installer.PopupStructurePrefab);
		}

		[UnityTest]
		public IEnumerator CreatesPopupWithFullCreationData()
		{
			Install();
			yield return 0;

			PopupInstaller installer = _popupFactory.Create(_fullData);
			Assert.IsNotNull(installer);
			Assert.IsNotNull(GameObject.FindObjectOfType<PopupInstaller>());
			Assert.IsNotNull(installer.PopupContentPrefab);
			Assert.IsNotNull(installer.PopupStructurePrefab);
		}
	}
}