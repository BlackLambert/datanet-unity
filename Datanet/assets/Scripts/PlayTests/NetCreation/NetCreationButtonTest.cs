

using NUnit.Framework;
using SBaier.Datanet.Core;
using SBaier.Testing;
using SBaier.Testing.UI;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;
using Zenject;

namespace SBaier.Datanet.Tests
{
	[TestFixture]
	public class NetCreationButtonTest: ZenjectIntegrationTestFixture
	{
		private const string _netName = "My Net";
		private const string _existingNetName = "Existing Net";

		

		public void Install()
		{
			PreInstall();

			//Setup scene
			UITestResourcePaths paths = new DefaultUITestingResourcePaths();
			Container.Bind<UITestCanvas>().FromComponentInNewPrefabResource(paths.HightMatchingCanvasPath).AsSingle().NonLazy();
			Container.Bind<Camera>().FromComponentInNewPrefabResource(paths.TestCameraPath).AsSingle().NonLazy();

			//Do Bindings
			Container.Bind<DataNetContainer>().To<DataNetContainerImpl>().AsSingle();
			Container.Bind<DataNetCreationData>().AsSingle();
			Container.Bind<DataNetNameValidator>().To<DataNetNameValidatorImpl>().AsSingle();
			Container.Bind<DataNetFactory>().To<DataNetFactoryImpl>().AsSingle();
			Container.Bind<DataNetCreationButton>().FromComponentInNewPrefabResource(ResourcePaths.CreateNetButton).AsSingle().NonLazy();

			PostInstall();

			//Init objects
			_creationButton.transform.SetParent(_canvas.Hook, false);
			_dataNetContainer.Add(_netFactory.Create(new DataNetFactory.Parameter(_existingNetName)));
		}


		[Inject]
		private DataNetCreationData _creationData = null;
		[Inject]
		private DataNetContainer _dataNetContainer = null;
		[Inject]
		private DataNetCreationButton _creationButton = null;
		[Inject]
		private UITestCanvas _canvas = null;
		[Inject]
		private DataNetFactory _netFactory = null;


		[UnityTest]
		public IEnumerator SetsErrorOnEmptyNameSet()
		{
			Install();
			yield return null;

			_creationData.Name = string.Empty;
			_creationButton.Button.onClick.Invoke();
			yield return null;
			Assert.AreNotEqual(string.Empty, _creationData.Error);
			yield return null;
		}

		[UnityTest]
		public IEnumerator SetsErrorOnExistingNameSet()
		{
			Install();
			yield return null;

			_creationData.Name = _existingNetName;
			_creationButton.Button.onClick.Invoke();
			yield return null;
			Assert.AreNotEqual(string.Empty, _creationData.Error);
			yield return null;
		}

		[UnityTest]
		public IEnumerator AddsNetOnClick()
		{
			Install();
			yield return null;

			_creationData.Name = _netName;
			_creationButton.Button.onClick.Invoke();
			yield return null;
			Assert.AreEqual(2, _dataNetContainer.Count);
			Assert.IsNotNull(_dataNetContainer.DataNetsCopy.Where(n => n.Name.Equals(_netName)));
			Assert.AreEqual(string.Empty, _creationData.Name);
			Assert.AreEqual(string.Empty, _creationData.Error);
			yield return null;
		}
	}
}