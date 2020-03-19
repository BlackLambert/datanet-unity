using Zenject;
using System.Collections;
using UnityEngine.TestTools;
using NUnit.Framework;
using UnityEngine;

namespace SBaier.UI.Page.Tests
{
	public class PageOnStartLoaderIntegrationTest : ZenjectIntegrationTestFixture
	{
		private const string _pagePath = "TestPage";

		public void Install()
		{
			PreInstall();
			Container.Bind<PrefabFactory>().AsSingle();
			Container.Bind<PageViewDisplayer>().To<TestPageViewDisplayer>().AsSingle();
			Container.Bind(typeof(OnStartPageLoader)).FromNewComponentOnNewGameObject().AsSingle().WithArguments(_pagePath).NonLazy();
			PostInstall();
		}

		[UnityTest]
		public IEnumerator PageDisplayedOnStart()
		{
			Install();
			yield return 0;

			Page page = GameObject.FindObjectOfType<Page>();
			Assert.IsNotNull(page);
			Assert.IsTrue(page.gameObject.activeInHierarchy);
		}
	}
}