using Zenject;
using NUnit.Framework;
using System;
using System.Linq;
using System.Collections.Generic;

namespace SBaier.Storage.Tests
{
	[TestFixture]
	public class BasicListRepositoryUnitTest : ZenjectUnitTestFixture
	{
		[SetUp]
		public void Install()
		{
			Container.Bind(typeof(BasicListRepository<TestData>)).To<TestListRepository>().AsSingle();
			_first = new TestData(2);
			_second = new TestData(3);
			Container.Inject(this);
		}

		[Inject]
		private BasicListRepository<TestData> _repository = null;
		private TestData _first;
		private TestData _second;

		[Test]
		public void IsEmptyOnStart()
		{
			Assert.AreEqual(0, _repository.Count);
		}

		[Test]
		public void Count_ReturnsListCount()
		{
			Assert.AreEqual(0, _repository.Count);
			_repository.Add(_first);
			Assert.AreEqual(1, _repository.Count);
			_repository.Add(_second);
			Assert.AreEqual(2, _repository.Count);
		}

		[Test]
		public void Add_AddsElements()
		{
			_repository.Add(_first);
			_repository.Add(_second);
			Assert.AreEqual(2, _repository.Count);
		}

		[Test]
		public void Add_InvokesAddedEvent()
		{
			bool called = false;
			CollectionContentChangedAction<TestData> listener = (data) =>
			{
				Assert.AreEqual(_first, data);
				called = true;
			};
			
			_repository.OnCollectionContentAdded += listener;
			_repository.Add(_first);
			Assert.IsTrue(called);
			_repository.OnCollectionContentAdded -= listener;
		}


		[Test]
		public void Contains_ReturnsCorrectValue()
		{
			Assert.IsFalse(_repository.Contains(_first));
			_repository.Add(_first);
			Assert.IsTrue(_repository.Contains(_first));
		}

		[Test]
		public void Get_ReturnsCorrectElement()
		{
			Assert.AreEqual(0, _repository.Count);
			_repository.Add(_first);
			_repository.Add(_second);
			_repository.Add(null);
			Assert.AreEqual(_first, _repository.Get(0));
			Assert.AreEqual(_second, _repository.Get(1));
			Assert.AreEqual(null, _repository.Get(2));
		}

		[Test]
		public void Get_ThrowsExceptionIfIndexOutOfBounds()
		{
			Assert.Throws<ArgumentOutOfRangeException>(() => _repository.Get(1));
		}

		[Test]
		public void GetRepositoryData_ReturnsListCopy()
		{
			_repository.Add(_first);
			Assert.AreNotSame(_repository.Get(), _repository.Get());
			Assert.AreEqual(_repository.Count, _repository.Count);
			Assert.AreEqual(_first, _repository.Get().ToList()[0]);
		}

		[Test]
		public void Remove_RemovesContent()
		{
			_repository.Add(_first);
			_repository.Add(_second);
			Assert.IsTrue(_repository.Contains(_first));
			Assert.IsTrue(_repository.Contains(_second));
			_repository.Remove(_first);
			Assert.IsFalse(_repository.Contains(_first));
			Assert.IsTrue(_repository.Contains(_second));
		}

		[Test]
		public void Remove_RemovesAllEqualContent()
		{
			_repository.Add(_first);
			_repository.Add(_first);
			Assert.IsTrue(_repository.Contains(_first));
			_repository.Remove(_first);
			Assert.IsFalse(_repository.Contains(_first));
		}

		[Test]
		public void Remove_ThrowsExceptionIfTryingToRemoveNonExistentContent()
		{
			_repository.Add(_first);
			Assert.IsFalse(_repository.Contains(_second));
			Assert.Throws<ArgumentException>(() => _repository.Remove(_second));
		}

		[Test]
		public void Remove_InvokesRemovedEvent()
		{
			_repository.Add(_first);
			bool called = false;
			CollectionContentChangedAction<TestData> listener = (data) =>
			{
				Assert.AreEqual(_first, data);
				called = true;
			};

			_repository.OnCollectionContentRemoved += listener;
			_repository.Remove(_first);
			Assert.IsTrue(called);
			_repository.OnCollectionContentRemoved -= listener;
		}

		[Test]
		public void RemoveAt_RemovesContentAtIndex()
		{
			_repository.Add(_first);
			_repository.Add(_second);
			Assert.IsTrue(_repository.Contains(_first));
			Assert.IsTrue(_repository.Contains(_second));
			_repository.RemoveAt(0);
			Assert.IsFalse(_repository.Contains(_first));
			Assert.IsTrue(_repository.Contains(_second));
			Assert.AreEqual(1, _repository.Count);
		}

		[Test]
		public void RemoveAt_ThrowsOutOfBoundsException()
		{
			_repository.Add(_first);
			_repository.Add(_second);
			Assert.IsTrue(_repository.Contains(_first));
			Assert.IsTrue(_repository.Contains(_second));
			Assert.Throws<ArgumentOutOfRangeException>(() => _repository.RemoveAt(3));
		}

		[Test]
		public void RemoveAt_InvokesRemovedEvent()
		{
			_repository.Add(_first);
			bool called = false;
			CollectionContentChangedAction<TestData> listener = (data) =>
			{
				Assert.AreEqual(_first, data);
				called = true;
			};

			_repository.OnCollectionContentRemoved += listener;
			_repository.RemoveAt(0);
			Assert.IsTrue(called);
			_repository.OnCollectionContentRemoved -= listener;
		}

		[Test]
		public void Store_SetsCorrectValue()
		{
			Assert.AreNotEqual(null, _repository.Get());
			List<TestData> list = new List<TestData>();
			list.Add(new TestData(3));
			_repository.Store(list);
			Assert.AreEqual(list[0].TestValue, _repository.Get(0).TestValue);
		}

		[Test]
		public void Store_InvokesOnDataChangedEvent()
		{
			bool called = false;
			List<TestData> firstList = new List<TestData>();
			_repository.Store(firstList);
			Assert.AreNotEqual(null, _repository.Get());
			List<TestData> secondList = new List<TestData>();
			secondList.Add(new TestData(3));
			Assert.AreEqual(firstList.Count, _repository.Count);
			RepositoryDataChangedAction<ICollection<TestData>> listener = (former, newList) =>
			{
				called = true;
				Assert.AreEqual(firstList, former);
				Assert.AreEqual(secondList, newList);
			};
			_repository.OnRepositoryDataChanged += listener;
			_repository.Store(secondList);
			Assert.AreEqual(secondList[0].TestValue, _repository.Get(0).TestValue);
			Assert.IsTrue(called);
			_repository.OnRepositoryDataChanged -= listener;
		}
	}
}