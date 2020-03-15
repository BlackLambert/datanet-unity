using NUnit.Framework;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;
using Zenject;

namespace SBaier.UI.Test
{
	[TestFixture]
	public class LastInShownViewDisplayerIntegrationTest : ZenjectIntegrationTestFixture
	{
		private const string _viewPath = "BasicTestView";

		public void Install()
		{
			PreInstall();
			Container.Bind<PrefabFactory>().AsSingle();
			Container.Bind<LastInShownViewDisplayer<TestView>>().To<TestLastInShownViewDisplayer>().AsSingle();
			Container.Bind(typeof(TestView)).FromComponentsInNewPrefabResource(_viewPath).AsTransient();
			PostInstall();
		}


		[Inject]
		private TestView _view = null;
		[Inject]
		private TestView _secondView = null;
		[Inject]
		private TestView _thirdView = null;
		[Inject]
		private LastInShownViewDisplayer<TestView> _displayer = null;

		[UnityTest]
		public IEnumerator ThrowsArgumentNullException()
		{
			Install();
			yield return 0;

			Assert.Throws<ArgumentNullException>(() => _displayer.Display(null));
		}

		[UnityTest]
		public IEnumerator Display_LastViewDisplayed()
		{
			Install();
			yield return 0;

			Assert.IsFalse(_view.gameObject.activeInHierarchy);
			Assert.IsFalse(_secondView.gameObject.activeInHierarchy);
			Assert.IsFalse(_thirdView.gameObject.activeInHierarchy);
			Assert.IsFalse(_displayer.ViewsCopy.Contains(_view));
			Assert.IsNull(_displayer.CurrentlyDisplayedView);
			Assert.AreEqual(0, _displayer.ViewsCopy.Count);

			_displayer.Display(_view);
			yield return 0;
			Assert.IsTrue(_view.gameObject.activeInHierarchy);
			Assert.AreEqual(_view, _displayer.CurrentlyDisplayedView);
			Assert.IsTrue(_displayer.ViewsCopy.Contains(_view));

			_displayer.Display(_secondView);
			yield return 0;
			Assert.IsFalse(_view.gameObject.activeInHierarchy);
			Assert.IsTrue(_secondView.gameObject.activeInHierarchy);
			Assert.AreEqual(_secondView, _displayer.CurrentlyDisplayedView);
			Assert.IsTrue(_displayer.ViewsCopy.Contains(_view));
			Assert.IsTrue(_displayer.ViewsCopy.Contains(_secondView));

			_displayer.Display(_thirdView);
			yield return 0;
			Assert.IsFalse(_view.gameObject.activeInHierarchy);
			Assert.IsFalse(_secondView.gameObject.activeInHierarchy); 
			Assert.IsTrue(_thirdView.gameObject.activeInHierarchy);
			Assert.AreEqual(_thirdView, _displayer.CurrentlyDisplayedView);
			Assert.IsTrue(_displayer.ViewsCopy.Contains(_view));
			Assert.IsTrue(_displayer.ViewsCopy.Contains(_secondView));
			Assert.IsTrue(_displayer.ViewsCopy.Contains(_thirdView));
			Assert.AreEqual(3, _displayer.ViewsCopy.Count);
		}

		[UnityTest]
		public IEnumerator Display_AddingViewAgainIsDoneCorrectly()
		{
			Install();
			yield return 0;

			Assert.IsFalse(_view.gameObject.activeInHierarchy);
			Assert.IsFalse(_secondView.gameObject.activeInHierarchy);
			Assert.IsFalse(_thirdView.gameObject.activeInHierarchy);

			_displayer.Display(_view);
			_displayer.Display(_secondView);
			_displayer.Display(_thirdView);
			yield return 0;

			Assert.IsFalse(_view.gameObject.activeInHierarchy);
			Assert.IsFalse(_secondView.gameObject.activeInHierarchy);
			Assert.IsTrue(_thirdView.gameObject.activeInHierarchy);

			_displayer.Display(_view);
			yield return 0;
			Assert.IsTrue(_view.gameObject.activeInHierarchy);
			Assert.IsFalse(_secondView.gameObject.activeInHierarchy);
			Assert.IsFalse(_thirdView.gameObject.activeInHierarchy);
			Assert.AreEqual(_view, _displayer.CurrentlyDisplayedView);
			Assert.IsTrue(_displayer.ViewsCopy.Contains(_view));
			Assert.AreEqual(3, _displayer.ViewsCopy.Count);
		}

		[UnityTest]
		public IEnumerator Hide_HidesLastView()
		{
			Install();
			yield return 0;

			Assert.IsFalse(_view.gameObject.activeInHierarchy);
			Assert.IsFalse(_secondView.gameObject.activeInHierarchy);
			Assert.IsFalse(_thirdView.gameObject.activeInHierarchy);

			_displayer.Display(_view);
			_displayer.Display(_secondView);
			_displayer.Display(_thirdView);
			yield return 0;

			Assert.IsFalse(_view.gameObject.activeInHierarchy);
			Assert.IsFalse(_secondView.gameObject.activeInHierarchy);
			Assert.IsTrue(_thirdView.gameObject.activeInHierarchy);
			Assert.AreEqual(_thirdView, _displayer.CurrentlyDisplayedView);
			Assert.AreEqual(3, _displayer.ViewsCopy.Count);
			_displayer.Hide();
			yield return 0;

			Assert.AreEqual(2, _displayer.ViewsCopy.Count);
			Assert.IsFalse(_view.gameObject.activeInHierarchy);
			Assert.IsTrue(_secondView.gameObject.activeInHierarchy);
			Assert.AreEqual(_secondView, _displayer.CurrentlyDisplayedView);
			_displayer.Hide();
			yield return 0;

			Assert.AreEqual(1, _displayer.ViewsCopy.Count);
			Assert.IsTrue(_view.gameObject.activeInHierarchy);
			Assert.AreEqual(_view, _displayer.CurrentlyDisplayedView);
			_displayer.Hide();
			yield return 0;

			Assert.AreEqual(0, _displayer.ViewsCopy.Count);
			Assert.IsNull(_displayer.CurrentlyDisplayedView);
		}

		[UnityTest]
		public IEnumerator Hide_ThrowsExceptionIfNoView()
		{
			Install();
			yield return 0;

			Assert.AreEqual(0, _displayer.ViewsCopy.Count);
			Assert.Throws<InvalidOperationException>(() => _displayer.Hide());
		}

		[UnityTest]
		public IEnumerator Hide_View_HidesGivenView()
		{
			Install();
			yield return 0;

			_displayer.Display(_view);
			_displayer.Display(_secondView);
			yield return 0;

			Assert.AreEqual(_secondView, _displayer.CurrentlyDisplayedView);
			_displayer.Hide(_view);
			yield return 0;

			Assert.IsFalse(_view.gameObject.activeInHierarchy);
			Assert.AreEqual(1, _displayer.ViewsCopy.Count);
			Assert.AreEqual(_secondView, _displayer.CurrentlyDisplayedView);
			Assert.IsFalse(_displayer.ViewsCopy.Contains(_view));
			_displayer.Display(_view);
			_displayer.Display(_thirdView);
			yield return 0;

			Assert.AreEqual(3, _displayer.ViewsCopy.Count);
			Assert.AreEqual(_thirdView, _displayer.CurrentlyDisplayedView);
			_displayer.Hide(_thirdView);
			yield return 0;

			Assert.IsFalse(_thirdView.gameObject.activeInHierarchy);
			Assert.AreEqual(_view, _displayer.CurrentlyDisplayedView);
			Assert.AreEqual(2, _displayer.ViewsCopy.Count);
			Assert.IsFalse(_displayer.ViewsCopy.Contains(_thirdView));
		}

		[UnityTest]
		public IEnumerator Hide_View_ThrowsExceptionIfViewIsNull()
		{
			Install();
			yield return 0;

			Assert.AreEqual(0, _displayer.ViewsCopy.Count);
			_displayer.Display(_view);
			yield return 0;

			Assert.Throws<ArgumentNullException>(() => _displayer.Hide(null));
		}

		[UnityTest]
		public IEnumerator Hide_View_ThrowsExceptionIfViewNotFound()
		{
			Install();
			yield return 0;

			Assert.AreEqual(0, _displayer.ViewsCopy.Count);
			_displayer.Display(_view);
			yield return 0;

			Assert.Throws<ArgumentException>(() => _displayer.Hide(_secondView));
		}
	}
}