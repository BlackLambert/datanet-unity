using NUnit.Framework;
using SBaier.Datanet.Core;
using System;

namespace SBaier.Datanet.Tests
{
    public class DataNetTest
    {
		private const string _netName = "TestNet";
		private const string _newNetName = "NewName";


		private Guid _netGuid;
		private NodeContainer _nodeContainer;
		private DataNet _netToTest;
		

		[SetUp]
		public void Setup()
		{
			_netGuid = Guid.NewGuid();
			_nodeContainer = new NodeContainerDummy();
			_netToTest = new DataNet(_netGuid, _nodeContainer, _netName);
		}

        [Test]
        public void ConstructorInputEqualsOutput()
        {
			Assert.AreEqual(_netName, _netToTest.Name);
			Assert.AreEqual(_netGuid, _netToTest.ID);
			Assert.AreEqual(_nodeContainer, _netToTest.NodeContainer);
		}

		[Test]
		public void OnNameChangedTriggered()
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
