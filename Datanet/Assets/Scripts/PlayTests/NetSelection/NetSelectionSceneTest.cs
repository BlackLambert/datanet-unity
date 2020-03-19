using Zenject;
using System.Collections;
using UnityEngine.TestTools;
using SBaier.Testing;
using UnityEngine;
using NUnit.Framework;
using SBaier.Datanet.Core;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;
using System.Collections.Generic;
using System;

namespace SBaier.Datanet.Tests
{
	public class NetSelectionSceneTest : SceneTestFixture
	{
		private const string _firstNetName = "First Net Name";
		private const string _secondNetName = "Seconds Net Name";

		public IEnumerator Install()
		{
			//Setup scene
			yield return LoadScenes(SceneNames.MainScene, SceneNames.NetSelection);

			//Init Objects
		}

		[Inject]
		private SelectedDataNet _selectedNet = null;
		[Inject]
		private DataNetCreationData _creationData = null;
		[Inject]
		private DataNetsRepository _dataNetsRepository = null;
		[Inject]
		private DataNetFactory _netFactory = null;


		[UnityTest]
		public IEnumerator UserSelectsExistingNet()
		{
			yield return Install();
			yield return 0;

			Assert.IsFalse(SceneManager.GetSceneByName(SceneNames.NetWorkspaceScene).isLoaded);
			DataNet firstNet = _netFactory.Create(new DataNetFactory.Parameter(_firstNetName));
			_dataNetsRepository.Get().Add(firstNet);
			yield return 0;
			NetSelectionElementsCreator _elementsCreator = GameObject.FindObjectOfType<NetSelectionElementsCreator>();
			Assert.AreEqual(1, _elementsCreator.ElementsCopy.Count);
			Assert.True(_elementsCreator.ElementsCopy.ContainsKey(new KeyValuePair<Guid, DataNet>(firstNet.ID, firstNet)));
			NetSelectionElementInstaller element = _elementsCreator.ElementsCopy[new KeyValuePair<Guid, DataNet>(firstNet.ID, firstNet)];
			Button button = element.GetComponentInChildren<Button>();
			button.onClick.Invoke();
			yield return new WaitForSeconds(1);
			Assert.AreEqual(firstNet, _selectedNet.Selected);
			Assert.IsTrue(SceneManager.GetSceneByName(SceneNames.MainScene).isLoaded);
			Assert.IsTrue(SceneManager.GetSceneByName(SceneNames.NetWorkspaceScene).isLoaded);
			Assert.IsFalse(SceneManager.GetSceneByName(SceneNames.NetSelection).isLoaded);
		}

		[UnityTest]
		public IEnumerator UserCreatesTwoNetsWithAllErrors()
		{
			yield return Install();
			yield return 0;

			// Checks initial state and clicks create button
			Assert.AreEqual(1, GameObject.FindObjectsOfType<DataNetCreationErrorDisplay>().Length);
			DataNetCreationErrorDisplay errorDisplay = GameObject.FindObjectOfType<DataNetCreationErrorDisplay>();
			Assert.AreEqual(_creationData.GetHashCode(), errorDisplay.CreationData.GetHashCode());
			checkErrorDisplayEmpty(errorDisplay);
			DataNetNameInput nameInput = GameObject.FindObjectOfType<DataNetNameInput>();
			Assert.AreEqual(_creationData.GetHashCode(), nameInput.CreationData.GetHashCode());
			checkInputFieldEmpty(nameInput);
			DataNetCreationButton creationButton = GameObject.FindObjectOfType<DataNetCreationButton>();
			creationButton.Button.onClick.Invoke();
			yield return 0;

			// Checks error display and enters first net name
			checkErrorDisplayed(errorDisplay);
			enterName(nameInput, _firstNetName);
			yield return 0;

			// Checks error not displayed anymore and clicks create button
			checkErrorDisplayEmpty(errorDisplay);
			creationButton.Button.onClick.Invoke();
			yield return 0;

			// Checks if net and also the list element have been created and enters the name of the first net again.
			NetSelectionElementsCreator netSelectionElementsCreator = GameObject.FindObjectOfType<NetSelectionElementsCreator>();
			checkNetElementsCreated(netSelectionElementsCreator);
			checkInputFieldEmpty(nameInput);
			enterName(nameInput, _firstNetName);
			creationButton.Button.onClick.Invoke();
			yield return 0;

			// Checks if the expected error is display, enters second net name and clicks create button
			checkErrorDisplayed(errorDisplay);
			enterName(nameInput, _secondNetName);
			creationButton.Button.onClick.Invoke();
			yield return 0;

			// Checks if the error display is empty, 
			// checks if second net has been created,
			// checks if name input is empty,
			checkNetElementsCreated(netSelectionElementsCreator);
			checkInputFieldEmpty(nameInput);
			checkErrorDisplayEmpty(errorDisplay);
		}

		private void enterName(DataNetNameInput nameInput, string name)
		{
			nameInput.InputField.text = name;
			nameInput.InputField.onValueChanged.Invoke(name);
			nameInput.InputField.onEndEdit.Invoke(name);
		}

		private void checkErrorDisplayed(DataNetCreationErrorDisplay errorDisplay)
		{
			Assert.AreNotEqual(string.Empty, _creationData.Error);
			Assert.AreEqual(_creationData.Error, errorDisplay.TextField.text);
		}

		private void checkErrorDisplayEmpty(DataNetCreationErrorDisplay errorDisplay)
		{
			Assert.AreEqual(string.Empty, _creationData.Error);
			Assert.AreEqual(string.Empty, errorDisplay.TextField.text);
		}

		private void checkInputFieldEmpty(DataNetNameInput input)
		{
			Assert.AreEqual(string.Empty, _creationData.Name);
			Assert.AreEqual(string.Empty, input.InputField.text);
		}

		private void checkNetElementsCreated(NetSelectionElementsCreator netSelectionElementsCreator)
		{
			foreach (DataNet net in _dataNetsRepository.Get().CopyDictionary().Values)
				Assert.IsNotNull(netSelectionElementsCreator.ElementsCopy[new KeyValuePair<Guid, DataNet>(net.ID, net)]);
			Assert.AreEqual(_dataNetsRepository.Get().Count, netSelectionElementsCreator.ElementsCopy.Count);
		}
	}
}