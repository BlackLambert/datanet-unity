using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using SBaier.Datanet.Core;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine.UI;

namespace SBaier.Datanet.Tests
{
    public class NetSelectionElementTest
    {
		private const string _netName = "My Net";

		private UITestHelper _uITestHelper;
		private GameObject _canvas;
		private GameObject _elementObject;
		private DataNet _elementNet;
		private SelectedDataNet _selectedDataNet;
		private SelectNetOnClick _selectNetOnClick;
		private NetNameDisplay _netNameDisplay;

		[SetUp]
        public void Setup()
        {
			_uITestHelper = new UITestHelper();
			_canvas = _uITestHelper.CreateDefaultTestCanvas();
			_elementObject = GameObject.Instantiate(Resources.Load(ResourcePaths.NetSelectionElementPrefabPath) as GameObject, _canvas.transform);
			DataNetFactory factory = new DataNetFactoryDummy();
			_elementNet = factory.Create(new DataNetFactory.Parameter(_netName));
			_selectedDataNet = new SelectedDataNet();
			_selectNetOnClick = _elementObject.GetComponentInChildren<SelectNetOnClick>();
			_selectNetOnClick.Construct(_selectedDataNet, _elementNet);
			_netNameDisplay = _elementObject.GetComponentInChildren<NetNameDisplay>();
			_netNameDisplay.Construct(_elementNet);
		}

		[TearDown]
		public void Teardown()
		{
			if(_elementObject != null)
				GameObject.Destroy(_elementObject);
			_uITestHelper.DestroyDefaultCanvas();
		}

		private void removeSceneLoaderComponents()
		{
			GameObject.Destroy(_elementObject.GetComponentInChildren<SceneLoaderOnClick>());
			GameObject.Destroy(_elementObject.GetComponentInChildren<SceneUnloaderOnClick>());
		}
	
        // A Test behaves as an ordinary method
        [UnityTest]
        public IEnumerator NetSelectedOnClick()
        {
			removeSceneLoaderComponents();
			yield return null;
			_selectNetOnClick.Button.onClick.Invoke();
			yield return null;
			Assert.AreEqual(_elementNet, _selectedDataNet.Selected);
			yield return null;
		}

		[UnityTest]
		public IEnumerator CorrectNameDisplayed()
		{
			NetNameDisplay nameDisplay = _elementObject.GetComponentInChildren<NetNameDisplay>();
			Assert.AreEqual(_netName, nameDisplay.Text.text);
			yield return null;
		}
	}
}
