using Zenject;
using System.Collections;
using UnityEngine.TestTools;
using NUnit.Framework;
using UnityEngine;

namespace SBaier.Persistence.Tests
{
	public class ToCollectiveDataSaverAdderIntegrationTest : ZenjectIntegrationTestFixture
	{
		public void Install()
		{
			PreInstall();
			Container.Bind(typeof(DataSaver<TestData>), typeof(TestDataSaver)).To<TestDataSaver>().AsSingle();
			Container.Bind<CollectiveDataSaver>().AsSingle();
			Container.Bind<ToCollectiveDataSaverAdder<TestData>>().To<TestToCollectiveDataSaverAdder>().FromNewComponentOnNewGameObject().AsSingle();
			PostInstall();
		}

		[Inject]
		private CollectiveDataSaver _collectiveDataSaver= null;
		[Inject]
		private TestDataSaver _testDataSaver = null;
		[Inject]
		private ToCollectiveDataSaverAdder<TestData> _adder;

		[UnityTest]
		public IEnumerator AddsSaverToCollectiveSaver()
		{
			Install();
			Assert.IsFalse(_collectiveDataSaver.SaversCopy.Contains(_testDataSaver));

			yield return 0;
			Assert.IsTrue(_collectiveDataSaver.SaversCopy.Contains(_testDataSaver));
		}

		[UnityTest]
		public IEnumerator RemovesSaverFromCollectiveSaverOnDestroy()
		{
			Install();

			yield return 0;
			Assert.IsTrue(_collectiveDataSaver.SaversCopy.Contains(_testDataSaver));
			GameObject.Destroy(_adder.gameObject);
			yield return 0;
			Assert.IsFalse(_collectiveDataSaver.SaversCopy.Contains(_testDataSaver));
		}
	}
}