using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.TestTools;

namespace SBaier.Datanet.Tests
{
    public class NetCreationErrorDisplayTest
    {
		private const string _emptyError = "";
		private const string _errorName = "Horrible Error!";
  
		private DataNetCreationData _creationData;
		private GameObject _displayObject;
		private DataNetCreationErrorDisplay _display;
		private UITestHelper _uITestHelper;
		

        [SetUp]
        public void Setup()
        {
			_creationData = new DataNetCreationData();
			_creationData.Error = _emptyError;
			_uITestHelper = new UITestHelper();
			GameObject canvasObject = _uITestHelper.CreateDefaultTestCanvas();
			GameObject _errorDisplayPrefab = Resources.Load(ResourcePaths.NetCreationErrorDisplayPrefabPath) as GameObject;
			_displayObject = GameObject.Instantiate(_errorDisplayPrefab, canvasObject.transform);
			_display = _displayObject.GetComponentInChildren<DataNetCreationErrorDisplay>();
			_display.Construct(_creationData);
		}

		[TearDown]
		public void Teardown()
		{
			GameObject.Destroy(_displayObject);
			_uITestHelper.DestroyDefaultCanvas();
		}


		[UnityTest]
		public IEnumerator InitialErrorDisplayed()
		{
			TextMeshProUGUI text = _displayObject.GetComponentInChildren<TextMeshProUGUI>();
			Assert.AreEqual(text.text, _emptyError);
			yield return 0;
		}

		// A Test behaves as an ordinary method
		[UnityTest]
        public IEnumerator CorrectErrorDisplayed()
        {
			_creationData.Error = _errorName;
			TextMeshProUGUI text = _displayObject.GetComponentInChildren<TextMeshProUGUI>();
			Assert.AreEqual(text.text, _errorName);
			yield return 0;
		}
	}
}
