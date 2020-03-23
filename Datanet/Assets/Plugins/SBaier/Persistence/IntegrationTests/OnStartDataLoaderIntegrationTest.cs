using Zenject;
using System.Collections;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Threading.Tasks;

namespace SBaier.Persistence.Tests
{
	public class OnStartDataLoaderIntegrationTest : ZenjectIntegrationTestFixture
	{
		public void Install()
		{
			PreInstall();
			Container.Bind(typeof(DataLoader<TestData>), typeof(TestDataLoader)).To<TestDataLoader>().AsSingle();
			Container.Bind<TestOnStartDataLoader>().FromNewComponentOnNewGameObject().AsTransient();
			PostInstall();
		}

		[Inject]
		private TestDataLoader _testDataLoader;
		[Inject]
		private TestOnStartDataLoader _testOnStartDataLoader;

		[UnityTest]
		public IEnumerator LoadsDataOnStart()
		{
			Install();
			

			Assert.IsNull(_testDataLoader.Data);
			yield return 0;
			Assert.IsNotNull(_testDataLoader.Data);
		}

	}
}