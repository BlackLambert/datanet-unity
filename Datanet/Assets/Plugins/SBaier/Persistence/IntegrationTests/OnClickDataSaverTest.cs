using NUnit.Framework;
using System.Collections;
using UnityEngine.TestTools;
using Zenject;

namespace SBaier.Persistence.Tests
{
	[TestFixture]
	public class OnClickDataSaverTest : ZenjectIntegrationTestFixture
	{
		private const string _prefabPath = "DataSaverTestButton";

		public void Install()
		{
			PreInstall();
			Container.Bind<OnClickDataSaver>().FromComponentInNewPrefabResource(_prefabPath).AsSingle();
			Container.Bind(typeof(TestDataSaver), typeof(DataSaver)).To<TestDataSaver>().AsSingle();
			PostInstall();

		}

		[Inject]
		private OnClickDataSaver _onClickDataSaver;
		[Inject]
		private TestDataSaver _testDataSaver;

		[UnityTest]
		public IEnumerator SavesOnClick()
		{
			Install();
			yield return 0;

			Assert.IsFalse(_testDataSaver.Saved);
			_onClickDataSaver.Button.onClick.Invoke();
			yield return 0;
			Assert.IsTrue(_testDataSaver.Saved);
		}
	}
}