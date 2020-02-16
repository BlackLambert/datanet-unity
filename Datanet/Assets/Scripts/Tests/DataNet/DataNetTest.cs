using NUnit.Framework;
using SBaier.Datanet.Core;
using System;
using Zenject;

namespace SBaier.Datanet.Tests
{
	[TestFixture]
	public class DataNetTest : ZenjectUnitTestFixture
	{
		private const string _netName = "TestNet";
		private const string _newNetName = "NewName";
		

		[SetUp]
		public void Install()
		{
			Guid guid = Guid.NewGuid();
			Container.Bind<Guid>().FromInstance(guid).AsTransient();
			NodeContainerDummy nodeContainer = new NodeContainerDummy();
			Container.Bind<NodeContainer>().To<NodeContainerDummy>().FromInstance(nodeContainer).AsTransient();
			Container.Bind<DataNet>().FromInstance(new DataNet(guid, nodeContainer, _netName)).AsTransient();
			Container.Inject(this);
		}

		[Inject]
		private Guid _netGuid = Guid.Empty;
		[Inject]
		private NodeContainer _nodeContainer = null;
		[Inject]
		private DataNet _netToTest = null;

		[Test]
        public void HasExpectedValues()
        {
			Assert.AreEqual(_netName, _netToTest.Name);
			Assert.AreEqual(_netGuid, _netToTest.ID);
			Assert.AreEqual(_nodeContainer, _netToTest.NodeContainer);
		}

		[Test]
		public void Name_SetAndGetWorking()
		{
			Assert.AreEqual(_netName, _netToTest.Name);
			_netToTest.Name = _newNetName;
			Assert.AreEqual(_newNetName, _netToTest.Name);
		}

		[Test]
		public void Name_EventTriggered()
		{
			bool called = false;
			Action listerner = () =>
			{
				Assert.AreEqual(_newNetName, _netToTest.Name);
				called = true;
			};
			_netToTest.OnNameChanged += listerner;
			_netToTest.Name = _newNetName;
			Assert.True(called);
			_netToTest.OnNameChanged -= listerner;
		}
    }
}
