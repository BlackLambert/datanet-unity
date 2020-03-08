using Zenject;
using NUnit.Framework;
using UnityEngine.TestTools;
using System.Collections;

namespace SBaier.UI.Popup.Tests
{
	[TestFixture]
	public class ClosePopupOnClickIntegrationTest : ZenjectIntegrationTestFixture
	{
		private const string _prefabPath = "Prefabs/Tests/ClosableTestPopup";

		public void Install()
		{
			PreInstall();
			Container.Bind(typeof(PopupInstaller), typeof(ClosePopupOnClick)).FromComponentInNewPrefabResource(_prefabPath).AsSingle();
			Container.Bind(typeof(PopupViewDisplayer)).To<TestPopupViewDisplayer>().AsSingle();
			Container.Inject(this);
			PostInstall();

			_popupViewDisplayer.Display(_popup.Popup);
		}


		[Inject]
		private PopupInstaller _popup = null;
		[Inject]
		private PopupViewDisplayer _popupViewDisplayer = null;
		[Inject]
		private ClosePopupOnClick _closeOnClick = null;

		[UnityTest]
		public IEnumerator DestroysPopupOnClick()
		{
			Install();
			yield return 0;

			Assert.IsNotNull(_popup);
			_closeOnClick.Button.onClick.Invoke();
			yield return 2;
			Assert.IsTrue(_popup == null);
		}
	}
}