

using NUnit.Framework;
using SBaier.Datanet;
using System;
using Zenject;
using SBaier.Storage;

namespace SBaier.Datanet.Tests
{
	[TestFixture]
	public class DataNetFactoryTest : ZenjectUnitTestFixture
	{
		private const string _netName = "My New Net";

		
		[SetUp]
		public void Install()
		{
			Container.Bind<DataNetsRepository>().To<DataNetsRepositoryDummy>().AsTransient();
			Container.Bind<DataNetNameValidator>().To<DataNetNameValidatorDummy>().AsTransient();
			Container.Bind<DataNetFactory>().To<DataNetFactoryImpl>().AsTransient();
			Container.Bind<DataNetFactory.Parameter>().FromInstance(new DataNetFactory.Parameter(Guid.NewGuid(), _netName)).AsTransient();
			Container.Inject(this);
		}

		[Inject]
		private DataNetFactory _factory = null;
		[Inject]
		private DataNetFactory.Parameter _inputParameters = null;


		[Test]
		public void Create_ReturnsExpectedNet()
		{
			DataNet result = _factory.Create(_inputParameters);
			Assert.AreEqual(_inputParameters.ID, result.ID);
			Assert.AreEqual(_inputParameters.NetName, result.Name);
			Assert.AreEqual(result.Count, 0);
		}
	}
}