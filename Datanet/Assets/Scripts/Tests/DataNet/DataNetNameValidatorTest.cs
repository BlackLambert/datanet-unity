

using NUnit.Framework;
using SBaier.Datanet;
using System;
using System.Collections.Generic;
using Zenject;

namespace SBaier.Datanet.Tests
{
	[TestFixture]
	public class DataNetNameValidatorTest : ZenjectUnitTestFixture
	{
		private const string _newNetName = "New Net";
		private const string _existingNetName = "Existing Net";
		

		[SetUp]
		public void Install()
		{
			List<DataNet> existingNets = new List<DataNet>();
			existingNets.Add(new DataNet(Guid.NewGuid(), _existingNetName));

			Container.Bind<List<DataNet>>().FromInstance(existingNets).AsTransient();
			Container.Bind<DataNetNameValidator>().To<DataNetNameValidatorImpl>().AsTransient();
			Container.Inject(this);
		}


		[Inject]
		private List<DataNet> _existingNets = null;
		[Inject]
		private DataNetNameValidator _validator = null;


		[Test]
		public void Validate_ThrowsExceptionOnEmptyName()
		{
			Assert.Throws<ArgumentNullException>(() => _validator.Validate(string.Empty, _existingNets));
		}

		[Test]
		public void Validate_ThrowsExceptionOnExistingName()
		{
			Assert.Throws<ArgumentException>(() => _validator.Validate(_existingNetName, _existingNets));
		}

		[Test]
		public void Validate_PassesOnValidName()
		{
			Assert.DoesNotThrow(() => _validator.Validate(_newNetName, _existingNets));
		}

		[Test]
		public void Validate_PassesOnNoExistingNets()
		{
			Assert.DoesNotThrow(() => _validator.Validate(_newNetName, new List<DataNet>()));
		}
	}
}