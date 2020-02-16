

using NUnit.Framework;
using SBaier.Testing;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.TestTools;
using Zenject;

namespace SBaier.Datanet.Tests
{
	[TestFixture]
	public class NetNameInputTest : ZenjectIntegrationTestFixture
	{
		private const string _inputText = "Input";
		private const string _errorText = "Error";

		
		public void Install()
		{
			PreInstall();

			//Setup scene
			UITestPrefabPaths paths = new DataNetUITestPrefabPaths();
			Container.Bind<UITestCanvas>().FromComponentInNewPrefabResource(paths.HightMatchingCanvasPath).AsSingle().NonLazy();
			Container.Bind<Camera>().FromComponentInNewPrefabResource(paths.TestCameraPath).AsSingle().NonLazy();

			//Bindings
			Container.Bind<DataNetCreationData>().AsSingle();
			Container.Bind<DataNetNameInput>().FromComponentInNewPrefabResource(ResourcePaths.NetNameInputPrefabPath).AsSingle().NonLazy();

			PostInstall();

			//Init Objects
			_creationData.Error = _errorText;
			_input.transform.SetParent(_canvas.Hook, false);
		}


		[Inject]
		private UITestCanvas _canvas = null;
		[Inject]
		private DataNetNameInput _input = null;
		[Inject]
		private DataNetCreationData _creationData = null;


		[UnityTest]
		public IEnumerator CreationDataUpdatesOnInputChange()
		{
			Install();
			yield return null;

			_input.InputField.text = _inputText;
			yield return null;
			_input.InputField.onEndEdit.Invoke(_input.InputField.text);
			Assert.AreEqual(_inputText, _creationData.Name);
			yield return null;
		}

		[UnityTest]
		public IEnumerator InputTextUpdatesOnCreationDataChange()
		{
			Install();
			yield return null;

			_creationData.Name = _inputText;
			yield return null;
			Assert.AreEqual(_inputText, _input.InputField.text);
			yield return null;
		}

		[UnityTest]
		public IEnumerator ErrorDeletedOnInputChange()
		{
			Install();
			yield return null;

			_input.InputField.text = _inputText;
			yield return null;
			_input.InputField.onValueChanged.Invoke(_input.InputField.text);
			Assert.AreEqual(string.Empty, _creationData.Error);
			yield return null;
		}
	}
}