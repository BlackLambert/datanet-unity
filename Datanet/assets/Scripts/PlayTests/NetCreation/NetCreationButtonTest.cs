

using NUnit.Framework;
using SBaier.Datanet.Core;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

namespace SBaier.Datanet.Tests
{
	public class NetCreationButtonTest
	{
		private const string _netName = "My Net";
		private const string _existingNetName = "Existing Net";

		private UITestHelper _testHelper;
		private GameObject _canvas;
		private GameObject _object;

		private DataNetCreationData _creationData;
		private DataNetContainer _dataNetContainer;

		[SetUp]
		public void Setup()
		{
			_testHelper = new UITestHelper();
			_canvas = _testHelper.CreateDefaultTestCanvas();

			GameObject prefab = Resources.Load(ResourcePaths.CreateNetButtonPrefabPath) as GameObject;
			_object = GameObject.Instantiate(prefab, _canvas.transform);
			_dataNetContainer = new DataNetContainerImpl();
			DataNetFactory factory = new DataNetFactoryImpl(_dataNetContainer, new DataNetNameValidatorImpl());
			_dataNetContainer.Add(factory.Create(new DataNetFactory.Parameter(_existingNetName)));
			_creationData = new DataNetCreationData();
			
			DataNetCreationButton button = _object.GetComponentInChildren<DataNetCreationButton>();
			button.Construct(factory, _dataNetContainer, _creationData);
		}

		[TearDown]
		public void Teardown()
		{
			GameObject.Destroy(_object);
			_testHelper.DestroyDefaultCanvas();
		}


		[UnityTest]
		public IEnumerator ErrorOnEmptyNameSet()
		{
			_creationData.Name = "";
			Button button = _object.GetComponentInChildren<Button>();
			button.onClick.Invoke();
			yield return null;
			Assert.AreNotEqual(string.Empty, _creationData.Error);
			yield return null;
		}

		[UnityTest]
		public IEnumerator ErrorOnExistingNameSet()
		{
			_creationData.Name = _existingNetName;
			Button button = _object.GetComponentInChildren<Button>();
			button.onClick.Invoke();
			yield return null;
			Assert.AreNotEqual(string.Empty, _creationData.Error);
			yield return null;
		}

		[UnityTest]
		public IEnumerator NetAddedOnClick()
		{
			_creationData.Name = _netName;
			Button button = _object.GetComponentInChildren<Button>();
			button.onClick.Invoke();
			yield return null;
			Assert.AreEqual(_dataNetContainer.Count, 2);
			Assert.IsNotNull(_dataNetContainer.DataNetsCopy.Where(n => n.Name.Equals(_netName)));
			Assert.AreEqual(string.Empty, _creationData.Name);
			Assert.AreEqual(string.Empty, _creationData.Error);
			yield return null;
		}
	}
}