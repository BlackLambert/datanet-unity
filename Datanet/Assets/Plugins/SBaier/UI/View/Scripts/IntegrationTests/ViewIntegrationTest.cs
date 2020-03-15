using NUnit.Framework;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;
using Zenject;

namespace SBaier.UI.Test
{
	[TestFixture]
	public class ViewIntegrationTest : ZenjectIntegrationTestFixture
	{
		private const string _viewPath = "BasicTestView";

		public void Install()
		{
			PreInstall();
			Container.Bind<PrefabFactory>().AsSingle();
			Container.Bind(typeof(TestView)).FromComponentsInNewPrefabResource(_viewPath).AsSingle();
			PostInstall();
		}


		[Inject]
		private TestView _view = null;

		[UnityTest]
		public IEnumerator ViewHiddenOnStart()
		{
			Install();
			yield return 0;

			Assert.IsFalse(_view.gameObject.activeInHierarchy);
		}

		[UnityTest]
		public IEnumerator OnHiddenCalled()
		{
			Install();
			yield return 0;

			bool called = false;
			Action onHidden = () =>
			{
				called = true;
			};

			_view.OnHidden += onHidden;
			_view.Hide();
			yield return 0;
			Assert.IsTrue(called);
			_view.OnHidden -= onHidden;
		}
	}
}