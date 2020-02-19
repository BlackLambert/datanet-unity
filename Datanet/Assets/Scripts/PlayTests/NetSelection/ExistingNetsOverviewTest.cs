using Zenject;
using System.Collections;
using UnityEngine.TestTools;
using SBaier.Testing;
using UnityEngine;
using NUnit.Framework;
using SBaier.Datanet.Core;
using SBaier.Testing.UI;

namespace SBaier.Datanet.Tests
{
	public class ExistingNetsOverviewTest : UIIntegrationTestFixture
	{
		private const string _firstNetName = "My net";
		private const string _secondNetName = "My second net";
		private const string _additionalNetName = "Additional net";

		public void Install()
		{
			PreInstall();

			//Setup scene
			PrepareHightMatchingCanvasStage(Container);

			//Bindings
			Container.Bind(typeof(ExistingNetOverviewInstaller), typeof(NetSelectionElementsCreator)).FromComponentInNewPrefabResource(ResourcePaths.ExistingNetsOverview).AsSingle().NonLazy();
			Container.Bind<DataNetFactory>().To<DataNetFactoryImpl>().AsSingle();
			Container.Bind<SelectedDataNet>().AsSingle();
			Container.Bind<DataNetContainer>().To<DataNetContainerImpl>().AsSingle();
			Container.Bind<PrefabFactory>().AsSingle();
			Container.Bind<DataNetNameValidator>().To<DataNetNameValidatorImpl>().AsSingle();

			PostInstall();

			//Init Objects
			_overviewInstaller.transform.SetParent(_canvas.Hook, false);
			_container.Add(_netFactory.Create(new DataNetFactory.Parameter(_firstNetName)));
			_container.Add(_netFactory.Create(new DataNetFactory.Parameter(_secondNetName)));
			_additionalNet = _netFactory.Create(new DataNetFactory.Parameter(_additionalNetName));
		}

		[Inject]
		private ExistingNetOverviewInstaller _overviewInstaller = null;
		[Inject]
		private UITestCanvas _canvas = null;
		[Inject]
		private NetSelectionElementsCreator _elementsCreator = null;
		[Inject]
		private DataNetFactory _netFactory = null;
		[Inject]
		private DataNetContainer _container = null;
		private DataNet _additionalNet = null;

		[UnityTest]
		public IEnumerator HasNeededComponents()
		{
			Install();
			yield return 0;

			Assert.IsNotNull(_overviewInstaller.GetComponentInChildren<ExistingNetOverviewInstaller>());
			Assert.IsNotNull(_overviewInstaller.GetComponentInChildren<GameObjectContext>());
			Assert.IsNotNull(_overviewInstaller.GetComponentInChildren<NetSelectionElementsCreator>());
		}

		[UnityTest]
		public IEnumerator ElementsCreator_HasCorrectElementsOnStart()
		{
			Install();
			yield return 0;

			Assert.AreEqual(2, _elementsCreator.ElementsCopy.Count);
			Assert.AreEqual(2, _elementsCreator.Hook.GetComponentsInChildren<NetSelectionElementInstaller>().Length);
			foreach(DataNet net in _container.DataNetsCopy)
				Assert.IsNotNull(_elementsCreator.ElementsCopy.ContainsKey(net.ID));
			yield return 0;
		}

		[UnityTest]
		public IEnumerator ElementsCreator_AddsElementOnNewNet()
		{
			Install();
			yield return 0;

			_container.Add(_additionalNet);
			yield return 0;
			Assert.AreEqual(3, _elementsCreator.Hook.GetComponentsInChildren<NetSelectionElementInstaller>().Length);
			foreach (DataNet net in _container.DataNetsCopy)
				Assert.IsNotNull(_elementsCreator.ElementsCopy.ContainsKey(net.ID));
			yield return 0;
		}
	}
}