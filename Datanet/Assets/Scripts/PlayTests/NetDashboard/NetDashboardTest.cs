using Zenject;
using System.Collections;
using UnityEngine.TestTools;
using UnityEngine;
using NUnit.Framework;
using SBaier.Datanet.Core;
using UnityEngine.UI;
using SBaier.SceneManagement;
using UnityEngine.SceneManagement;
using System.Linq;

namespace SBaier.Datanet.Tests
{
	public class NetDashboardTest : SceneTestFixture
	{
		private const string _backButtonName = "BackToNetSelectionButton";

		public IEnumerator Install()
		{
			yield return LoadScenes(SceneNames.NetSelectedMainScene, SceneNames.NetWorkspaceScene);
			_netNameDisplay = GameObject.FindObjectOfType<NetNameDisplay>();
			_templateSelectionButton = GameObject.FindObjectOfType<ShowNodeTemplateSelectionButton>();
			_nodeCountDisplay = GameObject.FindObjectOfType<NodeCountDisplay>();
			GameObject backButton = GameObject.Find(_backButtonName);
			_backToNetSelectionSceneLoader = backButton.GetComponent<SceneLoaderOnClick>();
			_backToNetSelectionSceneUnloader = backButton.GetComponent<SceneUnloaderOnClick>();
		}

		[Inject]
		private SelectedDataNet _selectedDataNet = null;
		private DataNet _dataNet;
		private NetNameDisplay _netNameDisplay;
		private ShowNodeTemplateSelectionButton _templateSelectionButton;
		private NodeCountDisplay _nodeCountDisplay;
		private SceneLoaderOnClick _backToNetSelectionSceneLoader;
		private SceneUnloaderOnClick _backToNetSelectionSceneUnloader;

		[UnityTest]
		public IEnumerator HasCorrectInitialState()
		{
			yield return Install();
			yield return 0;

			Assert.IsNotNull(_selectedDataNet.Selected);
			Assert.AreEqual(NetSelectedMainInstaller.NetName, _netNameDisplay.Text.text);
			Assert.IsTrue(_templateSelectionButton.Button.interactable);
			Assert.IsTrue(_backToNetSelectionSceneLoader.Button.interactable);
			Assert.AreEqual(0.ToString(), _nodeCountDisplay.CounterText.text);
		}

		[UnityTest]
		public IEnumerator BackButtonReturnsToNetSelecton()
		{
			yield return Install();
			yield return 0;

			Assert.AreEqual(SceneNames.NetSelection, _backToNetSelectionSceneLoader.SceneName);
			Assert.IsTrue(_backToNetSelectionSceneLoader.Additive);
			Assert.AreSame(_backToNetSelectionSceneLoader.Button, _backToNetSelectionSceneUnloader.Button);
			Assert.AreEqual(SceneNames.NetWorkspaceScene, _backToNetSelectionSceneUnloader.SceneName);
			_backToNetSelectionSceneLoader.Button.onClick.Invoke();
			yield return new WaitForSeconds(0.25f);
			Assert.AreEqual(SceneNames.NetSelection, SceneManager.GetSceneAt(1).name);
		}

		[UnityTest]
		public IEnumerator OpensNodeSelectionPopup()
		{
			yield return Install();
			yield return 0;

			Assert.IsNull(GameObject.FindObjectOfType<NodeTemplateSelectionPopupInstaller>());
			_templateSelectionButton.Button.onClick.Invoke();
			yield return 0;
			Assert.IsNotNull(GameObject.FindObjectOfType<NodeTemplateSelectionPopupInstaller>());
		}
	}
}