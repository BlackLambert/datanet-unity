

using NUnit.Framework;
using SBaier.Datanet.Core;
using System;

namespace SBaier.Datanet.Tests
{
	public class DataNetFactoryTest
	{
		private const string _netName = "My New Net";

		private DataNetFactory _factory;
		private DataNetFactory.Parameter _inputParameters;

		[SetUp]
		public void Setup()
		{
			_factory = new DataNetFactoryImpl(new DataNetContainerDummy(), new DataNetNameValidatorDummy());
			_inputParameters = new DataNetFactory.Parameter(Guid.NewGuid(), _netName);
		}

		[Test]
		public void CreatesExpectedNet()
		{
			DataNet result = _factory.Create(_inputParameters);
			Assert.AreEqual(_inputParameters.ID, result.ID);
			Assert.AreEqual(_inputParameters.NetName, result.Name);
			Assert.AreEqual(result.NodeContainer.Count, 0);
		}
	}
}