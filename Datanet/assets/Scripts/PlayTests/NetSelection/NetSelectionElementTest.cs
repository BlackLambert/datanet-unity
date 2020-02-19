using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using SBaier.Datanet.Core;
using SBaier.SceneManagement;
using SBaier.Testing;
using SBaier.Testing.UI;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;
using Zenject;

namespace SBaier.Datanet.Tests
{
	[TestFixture]
	public class NetSelectionElementTest : ZenjectIntegrationTestFixture
	{
		private const string _netName = "My Net";

		
        public void Install()
        {
			PreInstall();

			//Setup scene
			UITestResourcePaths paths = new DefaultUITestingResourcePaths();
			Container.Bind<UITestCanvas>().FromComponentInNewPrefabResource(paths.HightMatchingCanvasPath).AsSingle().NonLazy();
			Container.Bind<Camera>().FromComponentInNewPrefabResource(paths.TestCameraPath).AsSingle().NonLazy();

			//Bindings
			Container.Bind<SelectedDataNet>().AsSingle();
			Container.Bind(typeof(NetSelectionElementInstaller), typeof(SelectNetOnClick), typeof(NetNameDisplay),  typeof(SceneLoaderOnClick), typeof(SceneUnloaderOnClick)).FromComponentInNewPrefabResource(ResourcePaths.NetSelectionElement).AsSingle().NonLazy();
			DataNetFactory factory = new DataNetFactoryDummy();
			Container.Bind<DataNet>().FromInstance(factory.Create(new DataNetFactory.Parameter(_netName))).AsSingle();

			PostInstall();

			//Init Objects
			_element.transform.SetParent(_canvas.Hook, false);
		}

		private void removeSceneLoader()
		{
			GameObject.Destroy(_element.GetComponentInChildren<SceneLoaderOnClick>());
			GameObject.Destroy(_element.GetComponentInChildren<SceneUnloaderOnClick>());
		}

		[Inject]
		private UITestCanvas _canvas = null;
		[Inject]
		private NetSelectionElementInstaller _element = null;
		[Inject]
		private DataNet _elementNet = null;
		[Inject]
		private SelectedDataNet _selectedDataNet = null;
		[Inject]
		private SelectNetOnClick _selectNetOnClick = null;
		[Inject]
		private NetNameDisplay _netNameDisplay = null;
		[Inject]
		private SceneLoaderOnClick _sceneLoaderOnClick = null;
		[Inject]
		private SceneUnloaderOnClick _sceneUnloaderOnClick = null;

		[UnityTest]
		public IEnumerator HasNeededComponents()
		{
			Install();
			yield return null;

			Assert.IsNotNull(_element.GetComponentInChildren<GameObjectContext>());
			Assert.IsNotNull(_element.GetComponentInChildren<NetSelectionElementInstaller>());
			Assert.IsNotNull(_element.GetComponentInChildren<Button>());
			Assert.IsNotNull(_element.GetComponentInChildren<SelectNetOnClick>());
			Assert.IsNotNull(_element.GetComponentInChildren<SceneLoaderOnClick>());
			Assert.IsNotNull(_element.GetComponentInChildren<SceneUnloaderOnClick>());
			Assert.IsNotNull(_element.GetComponentInChildren<NetNameDisplay>());
		}

		// A Test behaves as an ordinary method
		[UnityTest]
        public IEnumerator SelectsNetOnClick()
        {
			Install();
			removeSceneLoader();
			yield return null;

			_selectNetOnClick.Button.onClick.Invoke();
			yield return null;
			Assert.AreEqual(_elementNet, _selectedDataNet.Selected);
			yield return null;
		}

		[UnityTest]
		public IEnumerator DisplaysCorrectNetName()
		{
			Install();
			yield return null;

			Assert.AreEqual(_netName, _netNameDisplay.Text.text);
			yield return null;
		}

		[UnityTest]
		public IEnumerator SceneLoader_CorrectTargetScene()
		{
			Install();
			yield return null;

			Assert.AreEqual(SceneNames.NetWorkspaceScene, _sceneLoaderOnClick.SceneName);
			yield return null;
		}

		[UnityTest]
		public IEnumerator SceneLoader_IsAdditive()
		{
			Install();
			yield return null;

			Assert.IsTrue(_sceneLoaderOnClick.Additive);
			yield return null;
		}

		[UnityTest]
		public IEnumerator SceneUnloader_CorrectTargetScene()
		{
			Install();
			yield return null;

			Assert.AreEqual(SceneNames.NetSelection, _sceneUnloaderOnClick.SceneName);
			yield return null;
		}
	}
}
