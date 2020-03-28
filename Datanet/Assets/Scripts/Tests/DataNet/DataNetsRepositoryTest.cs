using NUnit.Framework;
using SBaier.Datanet;
using System;
using System.Collections.Generic;
using System.Linq;
using Zenject;

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
			repository.Store(new DataNets());
			repository.Get().Add(netInContainer);
			DataNetsRepositoryImpl emptyNetRepository = new DataNetsRepositoryImpl();
			emptyNetRepository.Store(new DataNets());

			Container.Bind<DataNetsRepository>().WithId("Empty").To<DataNetsRepositoryImpl>().FromInstance(emptyNetRepository).AsTransient();
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

		public DataNets DataNets { get { return _repository.Get(); } }
		public DataNets EmptyDataNets { get { return _emptyRepository.Get(); } }

		[Test]
		public void HasCorrectInitialState()
		{
			Assert.AreEqual(0, EmptyDataNets.Count);
			Assert.AreEqual(0, EmptyDataNets.CopyDictionary().Count());
		}

		[Test]
		public void Count_ReturnsCorrectValue()
		{
			Assert.AreEqual(1, DataNets.Count);
			Assert.AreEqual(1, DataNets.CopyDictionary().Count());
		}

		[Test]
		public void DataNetsCopy_IsACopy()
		{
			Assert.AreNotSame(DataNets.CopyDictionary(), DataNets.CopyDictionary());
		}

		[Test]
		public void Contains_ReturnsCorrectValue()
		{
			Assert.True(DataNets.Contains(_netInContainer.ID));
			Assert.False(DataNets.Contains(_netToAdd.ID));
		}
	
        [Test]
        public void Add_AddsNet()
        {
			Assert.DoesNotThrow(() => DataNets.Add(_netToAdd.ID, _netToAdd));
			Assert.True(DataNets.Contains(_netToAdd.ID));
        }

		[Test]
		public void Add_FailsToAddExistingNet()
		{
			Assert.Throws<ArgumentException>(() => DataNets.Add(_netInContainer));
		}

		[Test]
		public void Add_EventCalled()
		{
			bool called = false;
			Action<KeyValuePair<Guid, DataNet>> listerner = (addedNet) =>
			{
				Assert.AreEqual(_netToAdd, addedNet.Value);
				called = true;
			};
			DataNets.OnCollectionContentAdded += listerner;
			DataNets.Add(_netToAdd.ID, _netToAdd);
			Assert.True(called);
			_repository.Get().OnCollectionContentAdded -= listerner;
		}

		[Test]
		public void Remove_RemovesNet()
		{
			Assert.DoesNotThrow(() => DataNets.Remove(_netInContainer.ID));
			Assert.False(DataNets.Contains(_netInContainer.ID));
		}

		[Test]
		public void Remove_FailsToRemoveNonExistentNet()
		{
			Assert.Throws<KeyNotFoundException>(() => DataNets.Remove(_netToAdd.ID));
		}

		[Test]
		public void Remove_EventCalled()
		{
			bool called = false;
			Action<KeyValuePair<Guid, DataNet>> listerner = (removedNet) =>
			{
				Assert.AreEqual(_netInContainer, removedNet.Value);
				called = true;
			};
			DataNets.OnCollectionContentRemoved += listerner;
			DataNets.Remove(_netInContainer.ID);
			Assert.True(called);
			DataNets.OnCollectionContentRemoved -= listerner;
		}

		[Test]
		public void Get_ReturnsCorrectNet()
		{
			DataNet net = DataNets.Get(_netInContainer.ID);
			Assert.AreEqual(_netInContainer, net);
		}

		[Test]
		public void Get_FailsIfRequestedNetDoesNotExist()
		{
			Assert.Throws<KeyNotFoundException>(() => DataNets.Get(_netToAdd.ID));
		}
	}
}
