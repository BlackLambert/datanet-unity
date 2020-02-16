using NUnit.Framework;
using SBaier.Datanet.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using Zenject;

namespace SBaier.Datanet.Tests
{
	[TestFixture]
	public class DataNetContainerTest: ZenjectUnitTestFixture
	{
		private const string _netInContainerName = "Existing Net";
		private const string _netToAddName = "New Net";

		[SetUp]
        public void Install()
        {
			DataNetFactory dataNetFactory = new DataNetFactoryDummy();
			DataNet netToAdd = dataNetFactory.Create(new DataNetFactory.Parameter(Guid.NewGuid(), _netToAddName));
			DataNet netInContainer = dataNetFactory.Create(new DataNetFactory.Parameter(Guid.NewGuid(), _netInContainerName));
			DataNetContainerImpl container = new DataNetContainerImpl();
			container.Add(netInContainer);

			Container.Bind<DataNetContainer>().WithId("Empty").To<DataNetContainerImpl>().AsTransient();
			Container.Bind<DataNetContainer>().WithId("WithElement").To<DataNetContainerImpl>().FromInstance(container).AsTransient();
			Container.Bind<DataNet>().WithId("NewNet").FromInstance(netToAdd).AsTransient();
			Container.Bind<DataNet>().WithId("ExistingNet").FromInstance(netInContainer).AsTransient();
			Container.Inject(this);
		}

		[Inject(Id = "Empty")]
		private DataNetContainer _emptyContainer = null;
		[Inject(Id ="WithElement")]
		private DataNetContainer _container = null;
		[Inject(Id = "ExistingNet")]
		private DataNet _netInContainer = null;
		[Inject(Id = "NewNet")]
		private DataNet _netToAdd = null;

		[Test]
		public void HasCorrectInitialState()
		{
			Assert.AreEqual(0, _emptyContainer.Count);
			Assert.AreEqual(0, _emptyContainer.DataNetsCopy.Count());
		}

		[Test]
		public void Count_ReturnsCorrectValue()
		{
			Assert.AreEqual(1, _container.Count);
			Assert.AreEqual(1, _container.DataNetsCopy.Count());
		}

		[Test]
		public void Contains_ReturnsCorrectValue()
		{
			Assert.True(_container.Contains(_netInContainer.ID));
			Assert.False(_container.Contains(_netToAdd.ID));
		}
	
        [Test]
        public void Add_AddsNet()
        {
			Assert.DoesNotThrow(() => _container.Add(_netToAdd));
			Assert.True(_container.Contains(_netToAdd.ID));
        }

		[Test]
		public void Add_FailsToAddExistingNet()
		{
			Assert.Throws<ArgumentException>(() => _container.Add(_netInContainer));
		}

		[Test]
		public void Add_EventCalled()
		{
			bool called = false;
			Action<DataNet> listerner = (addedNet) =>
			{
				Assert.AreEqual(_netToAdd, addedNet);
				called = true;
			};
			_container.OnNetAdded += listerner;
			_container.Add(_netToAdd);
			Assert.True(called);
			_container.OnNetRemoved -= listerner;
		}

		[Test]
		public void Remove_RemovesNet()
		{
			Assert.DoesNotThrow(() => _container.Remove(_netInContainer.ID));
			Assert.False(_container.Contains(_netInContainer.ID));
		}

		[Test]
		public void Remove_FailsToRemoveNonExistentNet()
		{
			Assert.Throws<KeyNotFoundException>(() => _container.Remove(_netToAdd.ID));
		}

		[Test]
		public void Remove_EventCalled()
		{
			bool called = false;
			Action<DataNet> listerner = (removedNet) =>
			{
				Assert.AreEqual(_netInContainer, removedNet);
				called = true;
			};
			_container.OnNetRemoved += listerner;
			_container.Remove(_netInContainer.ID);
			Assert.True(called);
			_container.OnNetRemoved -= listerner;
		}

		[Test]
		public void Get_ReturnsCorrectNet()
		{
			DataNet net = _container.Get(_netInContainer.ID);
			Assert.AreEqual(_netInContainer, net);
		}

		[Test]
		public void Get_FailsIfRequestedNetDoesNotExist()
		{
			Assert.Throws<KeyNotFoundException>(() => _container.Get(_netToAdd.ID));
		}
	}
}
