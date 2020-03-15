using NUnit.Framework;
using System;
using System.Collections;
using UnityEngine.TestTools;
using Zenject;

namespace SBaier.UI.Test
{
	[TestFixture]
	public class BasicViewAnimatorIntegrationTest : ZenjectIntegrationTestFixture
	{
		private const string _viewPath = "BasicTestView";

		public void Install()
		{
			PreInstall();
			Container.Bind<PrefabFactory>().AsSingle();
			Container.Bind(typeof(TestView), typeof(BasicViewAnimator)).FromComponentsInNewPrefabResource(_viewPath).AsSingle();
			PostInstall();
			
		}


		[Inject]
		private BasicViewAnimator _animator = null;
		[Inject]
		private TestView _view = null;

		[UnityTest]
		public IEnumerator ViewHiddenOnStart()
		{
			Install();
			yield return 0;

			Assert.IsFalse(_animator.Base.activeInHierarchy);
		}

		[UnityTest]
		public IEnumerator DisplayedAfterDisplay()
		{
			Install();
			yield return 0;

			_view.Display();
			yield return 0;
			Assert.IsTrue(_animator.Base.activeInHierarchy);
		}

		[UnityTest]
		public IEnumerator HiddenAfterHide()
		{
			Install();
			yield return 0;

			_view.Display();
			yield return 0;
			_view.Hide();
			yield return 0;
			Assert.IsFalse(_animator.Base.activeInHierarchy);
		}

		[UnityTest]
		public IEnumerator OnHiddenCalled()
		{
			Install();
			yield return 0;

			_view.Display();
			yield return 0;

			bool called = false;
			Action onHidden = () =>
			{
				called = true;
			};

			_animator.OnHidden += onHidden;
			_view.Hide();
			yield return 0;
			Assert.IsTrue(called);
			_animator.OnHidden -= onHidden;
		}
	}
}