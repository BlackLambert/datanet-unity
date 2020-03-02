using Zenject;
using System.Collections;
using UnityEngine.TestTools;
using SBaier.Testing.UI;
using SBaier.Storage;
using NUnit.Framework;
using UnityEngine;

namespace SBaier.UI.List.Tests
{
	public class ListElementsCreatorIntegrationTest : UIIntegrationTestFixture
	{
		private const string _elementsCreatorPath = "Prefabs/Tests/TestElementsCreator";
		private const string _elementPath = "Prefabs/Tests/TestElement";


		private void Install()
		{
			PreInstall();
			PrepareHightMatchingCanvasStage(Container);
			Container.Bind(typeof(ICollectionRepository<TestData>), typeof(IListRepository<TestData>)).To<TestRepository>().AsSingle();
			Container.Bind<TestElementsCreator>().FromComponentInNewPrefabResource(_elementsCreatorPath).AsSingle();
			Container.Bind<TestElement>().FromResource(_elementPath).AsSingle();
			Container.Bind<TestData>().AsTransient();
			Container.Bind<PrefabFactory>().AsTransient();
			PostInstall();

			_creator.transform.SetParent(_canvas.transform, false);
			_repository.Add(_firstData);
		}

		[Inject]
		private TestData _firstData = null;
		[Inject]
		private TestData _secondData = null;
		[Inject]
		private TestElementsCreator _creator = null;
		[Inject]
		private UITestCanvas _canvas = null;
		[Inject]
		private IListRepository<TestData> _repository = null;


		[UnityTest]
		public IEnumerator HasCorrectInitialState()
		{
			Install();
			yield return 0;

			Assert.AreEqual(1, _repository.Count);
			Assert.AreEqual(1, GameObject.FindObjectsOfType<TestElement>().Length);
			Assert.AreSame(_firstData, GameObject.FindObjectOfType<TestElement>().TestData);
			Assert.AreEqual(1, _creator.Hook.transform.childCount);
			Assert.IsNotNull(_creator.Hook);
			Assert.IsNotNull(GameObject.FindObjectOfType<TestElement>().transform.parent);
			Assert.AreSame(GameObject.FindObjectOfType<TestElement>(), _creator.ElementsCopy[_firstData]);
		}

		[UnityTest]
		public IEnumerator CreatesNewElement()
		{
			Install();
			yield return 0;

			Assert.AreNotSame(_firstData, _secondData);
			_repository.Add(_secondData);
			yield return 0;
			TestElement[] elements = GameObject.FindObjectsOfType<TestElement>();
			Assert.AreEqual(2, elements.Length);
			Assert.AreSame(_firstData, elements[1].TestData);
			Assert.AreSame(_secondData, elements[0].TestData);
			Assert.AreEqual(2, _creator.Hook.transform.childCount);
		}
	}
}