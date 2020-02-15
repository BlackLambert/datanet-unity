using NUnit.Framework;
using SBaier.Datanet.Core;
using System;
using System.Collections.Generic;

namespace SBaier.Datanet.Tests
{
    public class DataNetContainerTest
    {
		private const string _netInContainerName = "Existing Net";
		private const string _netToAddName = "Existing Net";

		private DataNet _netInContainer;
		private DataNet _netToAdd;
		private DataNetContainer _container;

		[SetUp]
        public void Setup()
        {
			DataNetFactory dataNetFactory = new DataNetFactoryDummy();
			_netToAdd = dataNetFactory.Create(new DataNetFactory.Parameter(Guid.NewGuid(), _netToAddName));
			_netInContainer = dataNetFactory.Create(new DataNetFactory.Parameter(Guid.NewGuid(), _netInContainerName));
			_container = new DataNetContainerImpl();
			_container.AddDataNet(_netInContainer);
		}

		[Test]
		public void ContainsWorks()
		{
			Assert.True(_container.Contains(_netInContainer.ID));
			Assert.False(_container.Contains(_netToAdd.ID));
		}
	
        [Test]
        public void AddingNetWorks()
        {
			Assert.DoesNotThrow(() => _container.AddDataNet(_netToAdd));
			Assert.True(_container.Contains(_netToAdd.ID));
        }

		[Test]
		public void AddingExistingNetFails()
		{
			Assert.Throws<ArgumentException>(() => _container.AddDataNet(_netInContainer));
		}

		[Test]
		public void AddedEventCalledOnAdd()
		{
			bool called = false;
			Action<DataNet> listerner = (addedNet) =>
			{
				Assert.AreEqual(_netToAdd, addedNet);
				called = true;
			};
			_container.OnNetAdded += listerner;
			_container.AddDataNet(_netToAdd);
			Assert.True(called);
			_container.OnNetRemoved -= listerner;
		}

		[Test]
		public void RemovingExistingNetWorks()
		{
			Assert.DoesNotThrow(() => _container.RemoveDataNet(_netInContainer.ID));
			Assert.False(_container.Contains(_netInContainer.ID));
		}

		[Test]
		public void RemovingNotExistingNetFails()
		{
			Assert.Throws<KeyNotFoundException>(() => _container.RemoveDataNet(_netToAdd.ID));
		}

		[Test]
		public void RemovedEventCalledOnRemove()
		{
			bool called = false;
			Action<DataNet> listerner = (removedNet) =>
			{
				Assert.AreEqual(_netInContainer, removedNet);
				called = true;
			};
			_container.OnNetRemoved += listerner;
			_container.RemoveDataNet(_netInContainer.ID);
			Assert.True(called);
			_container.OnNetRemoved -= listerner;
		}

		[Test]
		public void GetNetWorks()
		{
			DataNet net = _container.GetDataNet(_netInContainer.ID);
			Assert.AreEqual(_netInContainer, net);
		}

		[Test]
		public void GetNetFailsIfNetNotExisting()
		{
			Assert.Throws<KeyNotFoundException>(() => _container.GetDataNet(_netToAdd.ID));
		}
	}
}
