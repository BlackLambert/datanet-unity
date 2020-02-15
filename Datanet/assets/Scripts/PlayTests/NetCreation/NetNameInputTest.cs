

using NUnit.Framework;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.TestTools;

namespace SBaier.Datanet.Tests
{
	public class NetNameInputTest
	{
		private const string _inputText = "Input";
		private const string _errorText = "Error";

		private UITestHelper _uITestHelper;
		private GameObject _canvas;
		private GameObject _inputObject;
		private DataNetCreationData _creationData;

		[SetUp]
		public void Setup()
		{
			_uITestHelper = new UITestHelper();
			_canvas = _uITestHelper.CreateDefaultTestCanvas();
			_inputObject = GameObject.Instantiate(Resources.Load(ResourcePaths.NetNameInputPrefabPath) as GameObject, _canvas.transform);
			_creationData = new DataNetCreationData();
			DataNetNameInput input = _inputObject.GetComponentInChildren<DataNetNameInput>();
			input.Construct(_creationData);
			_creationData.Error = _errorText;
		}

		[TearDown]
		public void Teardown()
		{
			GameObject.Destroy(_inputObject);
			_uITestHelper.DestroyDefaultCanvas();
		}


		[UnityTest]
		public IEnumerator CreationDataUpdatesOnInputChange()
		{
			TMP_InputField inputField = _inputObject.GetComponentInChildren<TMP_InputField>();
			inputField.text = _inputText;
			yield return null;
			inputField.onEndEdit.Invoke(inputField.text);
			Assert.AreEqual(_inputText, _creationData.Name);
			yield return null;
		}

		[UnityTest]
		public IEnumerator InputTextUpdatesOnCreationDataChange()
		{
			TMP_InputField inputField = _inputObject.GetComponentInChildren<TMP_InputField>();
			_creationData.Name = _inputText;
			yield return null;
			Assert.AreEqual(_inputText, inputField.text);
			yield return null;
		}

		[UnityTest]
		public IEnumerator ErrorDeletedOnInputChange()
		{
			TMP_InputField inputField = _inputObject.GetComponentInChildren<TMP_InputField>();
			inputField.text = _inputText;
			yield return null;
			inputField.onValueChanged.Invoke(inputField.text);
			Assert.AreEqual(string.Empty, _creationData.Error);
			yield return null;
		}
	}
}