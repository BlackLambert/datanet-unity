using Zenject;
using System.Collections;
using UnityEngine.TestTools;
using SBaier.Testing.UI;
using SBaier.Datanet.Core;
using NUnit.Framework;
using UnityEngine;
using SBaier.Popup;
using System.Collections.Generic;
using System;
using SBaier.Storage;

namespace SBaier.Datanet.Tests
{
	public class ShowNodeTemplateSelectionButtonTest : UIIntegrationTestFixture
	{
		public void Install()
		{
			PreInstall();
			PrepareHightMatchingCanvasStage(Container);

			//Bindings
			Container.Bind<PopupFactory>().To<PopupFactoryImpl>().AsSingle();
			Container.Bind<PrefabFactory>().AsSingle();
			Container.Bind<PopupResourcePaths>().To<DataNetPopupResourcePaths>().AsTransient();
			Container.Bind(typeof(ICollectionRepository<KeyValuePair<Guid, NodeTemplate>>), typeof(NodeTemplatesRepository)).To<NodeTemplatesRepositoryImpl>().AsSingle();
			Container.Bind(typeof(ShowNodeTemplateSelectionButton)).FromComponentInNewPrefabResource(ResourcePaths.NetDashboard_NodeTemplateSelectionButton).AsSingle().NonLazy();
			PostInstall();

			_button.transform.SetParent(_canvas.Hook);
		}

		[Inject]
		private ShowNodeTemplateSelectionButton _button = null;
		[Inject]
		private UITestCanvas _canvas = null;

		[UnityTest]
		public IEnumerator HasCorrectInitialValues()
		{
			Install();
			yield return 0;

			Assert.IsNotNull(_button.Button);
		}

		[UnityTest]
		public IEnumerator CreatesPopupOnClick()
		{
			Install();
			yield return 0;

			_button.Button.onClick.Invoke();
			yield return 0;
			Assert.IsNotNull(GameObject.FindObjectOfType<PopupInstaller>());
			Assert.IsNotNull(GameObject.FindObjectOfType<PopupStructure>());
			Assert.IsNotNull(GameObject.FindObjectOfType<NodeTemplateSelectionElementCreator>());
		}
	}
}