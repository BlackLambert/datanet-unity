using Zenject;
using System.Collections;
using UnityEngine.TestTools;
using SBaier.Testing;
using TMPro;
using NUnit.Framework;
using SBaier.Datanet.Core;
using SBaier.Testing.UI;

namespace SBaier.Datanet.Tests
{
	public class NetDashboardNetNameDisplayTest : UIIntegrationTestFixture
	{
		private const string _netName = "MyNet";

		public void Install()
		{
			PreInstall();

			//Setup scene
			PrepareHightMatchingCanvasStage(Container);

			//Bindings
			Container.Bind<SelectedDataNet>().AsSingle();
			Container.Bind<DataNetFactory>().To<DataNetFactoryImpl>().AsSingle();
			Container.Bind<DataNetContainer>().To<DataNetContainerImpl>().AsSingle();
			Container.Bind<DataNetNameValidator>().To<DataNetNameValidatorImpl>().AsSingle();
			DataNet dataNet = Container.Resolve<DataNetFactory>().Create(new DataNetFactory.Parameter(_netName));
			Container.Bind<DataNet>().FromInstance(dataNet).AsSingle();
			Container.Bind(typeof(NetNameDisplay)).FromComponentInNewPrefabResource(ResourcePaths.NetDashboard_NetNameDisplay).AsSingle().NonLazy();
			PostInstall();

			_net = _netFactory.Create(new DataNetFactory.Parameter(_netName));
		}

		[Inject]
		private NetNameDisplay _display = null;
		[Inject]
		private DataNetFactory _netFactory = null;
		[Inject]
		private DataNet _net = null;

		[UnityTest]
		public IEnumerator DisplaysCorrectNetName()
		{
			Install();
			yield return 0;
			Assert.AreEqual(_net.Name, _display.Text.text);
		}
	}
}