using Zenject;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SBaier.Storage.Tests
{
	[TestFixture]
	public class BasicDictionaryRepositoryUnitTest : ZenjectUnitTestFixture
	{
		[SetUp]
		public void Install()
		{
			Container.Bind(typeof(BasicDictionaryRepository<Guid, TestData>)).To<TestDictionaryRepository>().AsSingle();
			_first = new KeyValuePair<Guid, TestData>(Guid.NewGuid(), new TestData(2));
			_second = new KeyValuePair<Guid, TestData>(Guid.NewGuid(), new TestData(3));
			Container.Inject(this);
		}

		[Inject]
		private BasicDictionaryRepository<Guid, TestData> _repository = null;
		private KeyValuePair<Guid, TestData> _first;
		private KeyValuePair<Guid, TestData> _second;

		[Test]
		public void IsEmptyOnStart()
		{
			Assert.AreEqual(0, _repository.Count);
		}

		[Test]
		public void Count_ReturnsListCount()
		{
			Assert.AreEqual(0, _repository.Count);
			_repository.Add(_first.Key, _first.Value);
			Assert.AreEqual(1, _repository.Count);
			_repository.Add(_second.Key, _second.Value);
			Assert.AreEqual(2, _repository.Count);
		}

		[Test]
		public void Add_AddsElements()
		{
			_repository.Add(_first.Key, _first.Value);
			_repository.Add(_second.Key, _second.Value);
			Assert.AreEqual(2, _repository.Count);
			Assert.AreEqual(_first.Value, _repository.Get(_first.Key));
			Assert.AreEqual(_second.Value, _repository.Get(_second.Key));
		}

		[Test]
		public void Add_InvokesAddedEvent()
		{
			bool called = false;
			CollectionContentChangedAction<KeyValuePair<Guid,TestData>> listener = (data) =>
			{
				Assert.AreEqual(_first, data);
				called = true;
			};

			_repository.OnCollectionContentAdded += listener;
			_repository.Add(_first.Key, _first.Value);
			Assert.IsTrue(called);
			_repository.OnCollectionContentAdded -= listener;
		}

		[Test]
		public void Add_ThrowsExceptionOnDoubleKey()
		{
			_repository.Add(_first.Key, _first.Value);
			Assert.Throws<ArgumentException>(() => _repository.Add(_first.Key, _first.Value));
		}


		[Test]
		public void Contains_ReturnsCorrectValue()
		{
			Assert.IsFalse(_repository.Contains(_first.Key));
			_repository.Add(_first.Key, _first.Value);
			Assert.IsTrue(_repository.Contains(_first.Key));
		}

		[Test]
		public void Get_ReturnsCorrectElement()
		{
			Guid thirdGuid = Guid.NewGuid();
			Assert.AreEqual(0, _repository.Count);
			_repository.Add(_first.Key, _first.Value);
			_repository.Add(_second.Key, _second.Value);
			_repository.Add(thirdGuid, null);
			Assert.AreEqual(_first.Value, _repository.Get(_first.Key));
			Assert.AreEqual(_second.Value, _repository.Get(_second.Key));
			Assert.AreEqual(null, _repository.Get(thirdGuid));
		}

		[Test]
		public void Get_ThrowsExceptionIfKeyNotFound()
		{
			Assert.Throws<KeyNotFoundException>(() => _repository.Get(Guid.NewGuid()));
		}

		[Test]
		public void GetRepositoryData_ReturnsListCopy()
		{
			_repository.Add(_first.Key, _first.Value);
			Assert.AreNotSame(_repository.Get(), _repository.Get());
			Assert.AreEqual(_repository.Count, _repository.Count);
			Assert.AreEqual(_first, _repository.Get().ToList()[0]);
		}

		[Test]
		public void Remove_RemovesContent()
		{
			_repository.Add(_first.Key, _first.Value);
			_repository.Add(_second.Key, _second.Value);
			Assert.IsTrue(_repository.Contains(_first.Key));
			Assert.IsTrue(_repository.Contains(_second.Key));
			_repository.Remove(_first.Key);
			Assert.IsFalse(_repository.Contains(_first.Key));
			Assert.IsTrue(_repository.Contains(_second.Key));
		}

		

		[Test]
		public void Remove_ThrowsExceptionIfTryingToRemoveNonExistentContent()
		{
			_repository.Add(_first.Key, _first.Value);
			Assert.IsFalse(_repository.Contains(_second.Key));
			Assert.Throws<KeyNotFoundException>(() => _repository.Remove(_second.Key));
		}

		[Test]
		public void Remove_InvokesRemovedEvent()
		{
			_repository.Add(_first.Key, _first.Value);
			bool called = false;
			CollectionContentChangedAction<KeyValuePair<Guid, TestData>> listener = (data) =>
			{
				Assert.AreEqual(_first, data);
				called = true;
			};

			_repository.OnCollectionContentRemoved += listener;
			_repository.Remove(_first.Key);
			Assert.IsTrue(called);
			_repository.OnCollectionContentRemoved -= listener;
		}


		[Test]
		public void Store_SetsCorrectValue()
		{
			Assert.AreNotEqual(null, _repository.Get());
			Dictionary<Guid, TestData> list = new Dictionary<Guid, TestData>();
			list.Add(_first.Key, _first.Value);
			_repository.Store(list);
			Assert.AreEqual(_first.Value.TestValue, _repository.Get(_first.Key).TestValue);
		}

		[Test]
		public void Store_InvokesOnDataChangedEvent()
		{
			bool called = false;
			Dictionary<Guid, TestData> firstDictionary = new Dictionary<Guid, TestData>();
			_repository.Store(firstDictionary);
			Assert.AreNotEqual(null, _repository.Get());
			Dictionary<Guid, TestData> secondDictionary = new Dictionary<Guid, TestData>();
			secondDictionary.Add(_first.Key, _first.Value);
			Assert.AreEqual(firstDictionary.Count, _repository.Count);
			RepositoryDataChangedAction<ICollection<KeyValuePair<Guid,TestData>>> listener = (former, newList) =>
			{
				called = true;
				Assert.AreEqual(firstDictionary, former);
				Assert.AreEqual(secondDictionary, newList);
			};
			_repository.OnRepositoryDataChanged += listener;
			_repository.Store(secondDictionary);
			Assert.AreEqual(secondDictionary[_first.Key].TestValue, _repository.Get(_first.Key).TestValue);
			Assert.IsTrue(called);
			_repository.OnRepositoryDataChanged -= listener;
		}

		[Test]
		public void Copy_CreatesCopyOfDictionary()
		{
			_repository.Add(_first.Key, _first.Value);
			Assert.AreNotSame(_repository.Copy(), _repository.Copy());
			Assert.AreEqual(_first.Value, _repository.Copy()[_first.Key]);
		}
	}
}