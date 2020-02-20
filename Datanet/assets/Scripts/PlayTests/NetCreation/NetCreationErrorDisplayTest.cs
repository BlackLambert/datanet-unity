using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using SBaier.Testing;
using SBaier.Testing.UI;
using TMPro;
using UnityEngine;
using UnityEngine.TestTools;
using Zenject;

namespace SBaier.Datanet.Tests
{
	[TestFixture]
	public class NetCreationErrorDisplayTest : UIIntegrationTestFixture
	{
		private const string _emptyError = "";
		private const string _errorName = "Horrible Error!";
		

        public void Install()
        {
			PreInstall();

			//Setup scene
			PrepareHightMatchingCanvasStage(Container);

			//Bindings
			Container.Bind<DataNetCreationData>().AsSingle();
			Container.Bind<DataNetCreationErrorDisplay>().FromComponentInNewPrefabResource(ResourcePaths.NetCreationErrorDisplay).AsSingle().NonLazy();

			PostInstall();

			//Init Objects
			_creationData.Error = _emptyError;
			_display.transform.SetParent(_canvas.Hook, false);
		}


		[Inject]
		private DataNetCreationData _creationData = null;
		[Inject]
		private DataNetCreationErrorDisplay _display = null;
		[Inject]
		private UITestCanvas _canvas = null;


		[UnityTest]
		public IEnumerator InitialErrorDisplayed()
		{
			Install();
			yield return null;

			Assert.AreEqual(_display.TextField.text, _emptyError);
			yield return null;
		}

		// A Test behaves as an ordinary method
		[UnityTest]
        public IEnumerator CorrectErrorDisplayed()
        {
			Install();
			yield return null;

			_creationData.Error = _errorName;
			Assert.AreEqual(_display.TextField.text, _errorName);
			yield return null;
		}
	}
}
