using NUnit.Framework;
using SBaier.Datanet.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using Zenject;
using SBaier.Storage;

namespace SBaier.Datanet.Tests
{
	[TestFixture]
	public class DataNetsRepositoryTest: ZenjectUnitTestFixture
	{
		private const string _netInContainerName = "Existing Net";
		private const string _netToAddName = "New Net";

		[SetUp]
        public void Install()
        {
			DataNetFactory dataNetFactory = new DataNetFactoryDummy();
			DataNet netToAdd = dataNetFactory.Create(new DataNetFactory.Parameter(Guid.NewGuid(), _netToAddName));
			DataNet netInContainer = dataNetFactory.Create(new DataNetFactory.Parameter(Guid.NewGuid(), _netInContainerName));
			DataNetsRepositoryImpl repository = new DataNetsRepositoryImpl();
			repository.Add(netInContainer.ID, netInContainer);

			Container.Bind<DataNetsRepository>().WithId("Empty").To<DataNetsRepositoryImpl>().AsTransient();
			Container.Bind<DataNetsRepository>().WithId("WithElement").To<DataNetsRepositoryImpl>().FromInstance(repository).AsTransient();
			Container.Bind<DataNet>().WithId("NewNet").FromInstance(netToAdd).AsTransient();
			Container.Bind<DataNet>().WithId("ExistingNet").FromInstance(netInContainer).AsTransient();
			Container.Inject(this);
		}

		[Inject(Id = "Empty")]
		private DataNetsRepository _emptyRepository = null;
		[Inject(Id ="WithElement")]
		private DataNetsRepository _repository = null;
		[Inject(Id = "ExistingNet")]
		private DataNet _netInContainer = null;
		[Inject(Id = "NewNet")]
		private DataNet _netToAdd = null;

		[Test]
		public void HasCorrectInitialState()
		{
			Assert.AreEqual(0, _emptyRepository.Count);
			Assert.AreEqual(0, _emptyRepository.Get().Count());
		}

		[Test]
		public void Count_ReturnsCorrectValue()
		{
			Assert.AreEqual(1, _repository.Count);
			Assert.AreEqual(1, _repository.Get().Count());
		}

		[Test]
		public void DataNetsCopy_IsACopy()
		{
			Assert.AreNotSame(_repository.Get(), _repository.Get());
		}

		[Test]
		public void Contains_ReturnsCorrectValue()
		{
			Assert.True(_repository.Contains(_netInContainer.ID));
			Assert.False(_repository.Contains(_netToAdd.ID));
		}
	
        [Test]
        public void Add_AddsNet()
        {
			Assert.DoesNotThrow(() => _repository.Add(_netToAdd.ID, _netToAdd));
			Assert.True(_repository.Contains(_netToAdd.ID));
        }

		[Test]
		public void Add_FailsToAddExistingNet()
		{
			Assert.Throws<ArgumentException>(() => _repository.Add(_netInContainer));
		}

		[Test]
		public void Add_EventCalled()
		{
			bool called = false;
			CollectionContentChangedAction<KeyValuePair<Guid, DataNet>> listerner = (addedNet) =>
			{
				Assert.AreEqual(_netToAdd, addedNet.Value);
				called = true;
			};
			_repository.OnCollectionContentAdded += listerner;
			_repository.Add(_netToAdd.ID, _netToAdd);
			Assert.True(called);
			_repository.OnCollectionContentAdded -= listerner;
		}

		[Test]
		public void Remove_RemovesNet()
		{
			Assert.DoesNotThrow(() => _repository.Remove(_netInContainer.ID));
			Assert.False(_repository.Contains(_netInContainer.ID));
		}

		[Test]
		public void Remove_FailsToRemoveNonExistentNet()
		{
			Assert.Throws<KeyNotFoundException>(() => _repository.Remove(_netToAdd.ID));
		}

		[Test]
		public void Remove_EventCalled()
		{
			bool called = false;
			CollectionContentChangedAction<KeyValuePair<Guid, DataNet>> listerner = (removedNet) =>
			{
				Assert.AreEqual(_netInContainer, removedNet.Value);
				called = true;
			};
			_repository.OnCollectionContentRemoved += listerner;
			_repository.Remove(_netInContainer.ID);
			Assert.True(called);
			_repository.OnCollectionContentRemoved -= listerner;
		}

		[Test]
		public void Get_ReturnsCorrectNet()
		{
			DataNet net = _repository.Get(_netInContainer.ID);
			Assert.AreEqual(_netInContainer, net);
		}

		[Test]
		public void Get_FailsIfRequestedNetDoesNotExist()
		{
			Assert.Throws<KeyNotFoundException>(() => _repository.Get(_netToAdd.ID));
		}
	}
}
