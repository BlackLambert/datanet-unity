

using NUnit.Framework;
using SBaier.Datanet.Core;
using System;
using System.Collections.Generic;

namespace SBaier.Datanet.Tests
{
	public class DataNetNameValidatorTest
	{
		private const string _newNetName = "New Net";
		private const string _existingNetName = "Existing Net";
		private List<DataNet> _existingNets;
		private DataNetNameValidator _validator;

		[SetUp]
		public void Setup()
		{
			_existingNets = new List<DataNet>();
			_existingNets.Add(new DataNet(Guid.NewGuid(), new NodeContainerDummy(), _existingNetName));
			_validator = new DataNetNameValidatorImpl();
		}

		[Test]
		public void EmptyNameThrowsException()
		{
			Assert.Throws<ArgumentNullException>(() => _validator.Validate(string.Empty, _existingNets));
		}

		[Test]
		public void ExistingNameThrowsException()
		{
			Assert.Throws<ArgumentException>(() => _validator.Validate(_existingNetName, _existingNets));
		}

		[Test]
		public void ValidNamePassesTest()
		{
			Assert.DoesNotThrow(() => _validator.Validate(_newNetName, _existingNets));
		}

		[Test]
		public void EmptyExistingNetIsAllowed()
		{
			Assert.DoesNotThrow(() => _validator.Validate(_newNetName, new List<DataNet>()));
		}
	}
}