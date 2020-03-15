using NUnit.Framework;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;
using Zenject;

namespace SBaier.UI.Test
{
	[TestFixture]
	public class FadeViewAnimatorIntegrationTest : ZenjectIntegrationTestFixture
	{
		private const string _viewPath = "FadeTestView";

		public void Install()
		{
			PreInstall();
			Container.Bind<PrefabFactory>().AsSingle();
			Container.Bind(typeof(TestView), typeof(FadeViewAnimator)).FromComponentsInNewPrefabResource(_viewPath).AsSingle();
			PostInstall();
			
		}


		[Inject]
		private FadeViewAnimator _animator = null;
		[Inject]
		private TestView _view = null;

		[UnityTest]
		public IEnumerator ViewHiddenOnStart()
		{
			Install();
			yield return 0;

			Assert.IsFalse(_animator.Base.gameObject.activeInHierarchy);
			Assert.AreEqual(_animator.CanvasGroup.alpha, 0);
			Assert.AreEqual(_animator.CanvasGroup.interactable, false);
		}

		[UnityTest]
		public IEnumerator DisplayedAfterDisplay()
		{
			Install();
			yield return 0;

			_view.Display();
			yield return new WaitForSeconds(_animator.FadeInDuration);
			yield return 0;
			Assert.IsTrue(_animator.Base.gameObject.activeInHierarchy);
			Assert.AreEqual(_animator.CanvasGroup.alpha, 1);
			Assert.AreEqual(_animator.CanvasGroup.interactable, true);
		}

		[UnityTest]
		public IEnumerator HiddenAfterHide()
		{
			Install();
			yield return 0;

			_view.Display();
			yield return new WaitForSeconds(_animator.FadeInDuration);
			yield return 0;
			Assert.IsTrue(_animator.Base.gameObject.activeInHierarchy);
			Assert.AreEqual(_animator.CanvasGroup.alpha, 1);
			Assert.AreEqual(_animator.CanvasGroup.interactable, true);
			_view.Hide();
			yield return new WaitForSeconds(_animator.FadeOutDuration);
			yield return 0;
			Assert.IsFalse(_animator.Base.gameObject.activeInHierarchy);
			Assert.AreEqual(_animator.CanvasGroup.alpha, 0);
			Assert.AreEqual(_animator.CanvasGroup.interactable, false);
		}

		[UnityTest]
		public IEnumerator OnHiddenCalled()
		{
			Install();
			yield return 0;

			_view.Display();
			yield return new WaitForSeconds(_animator.FadeInDuration);
			yield return 0;

			bool called = false;
			Action onHidden = () =>
			{
				called = true;
			};

			_animator.OnHidden += onHidden;
			_view.Hide();
			yield return new WaitForSeconds(_animator.FadeOutDuration);
			yield return 0;
			Assert.IsTrue(called);
			_animator.OnHidden -= onHidden;
		}
	}
}