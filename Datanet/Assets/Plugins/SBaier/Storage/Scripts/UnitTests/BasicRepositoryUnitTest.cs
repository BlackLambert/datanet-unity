using Zenject;
using NUnit.Framework;

namespace SBaier.Storage.Tests
{
	[TestFixture]
	public class BasicRepositoryUnitTest : ZenjectUnitTestFixture
	{
		private const int _testDataValue = 2;
		private const int _testInt = 3;
		private const string _testString = "Bla";

		[SetUp]
		public void Install()
		{
			Container.Bind<Repository<int>>().To<BasicRepository<int>>().AsTransient();
			Container.Bind<Repository<TestData>>().To<BasicRepository<TestData>>().AsTransient();
			Container.Bind<Repository<string>>().To<BasicRepository<string>>().AsTransient();
			Container.Bind<TestData>().FromInstance(new TestData(_testDataValue)).AsTransient();
			Container.Inject(this);
		}


		[Inject]
		private Repository<int> _intRepository = null;
		[Inject]
		private Repository<string> _stringRepository = null;
		[Inject]
		private Repository<TestData> _dataRepository = null;
		[Inject]
		private TestData _testData = null;

		[Test]
		public void NewValueRepositoryContainsDefaultValue()
		{
			Assert.AreEqual(default(int), _intRepository.Get());
			Assert.AreEqual(default(string), _stringRepository.Get());
		}

		[Test]
		public void NewDataRepositoryContainsDefaultValue()
		{
			Assert.AreEqual(default(TestData), _dataRepository.Get());
		}

		[Test]
		public void RetrunsStoredValue()
		{
			_intRepository.Store(_testInt);
			_stringRepository.Store(_testString);
			_dataRepository.Store(_testData);

			Assert.AreEqual(_testInt, _intRepository.Get());
			Assert.AreEqual(_testData, _dataRepository.Get());
			Assert.AreEqual(_testString, _stringRepository.Get());
		}

		[Test]
		public void InvokesDataChangedEventWithCorrectParameters()
		{
			bool called = false;

			RepositoryDataChangedAction<TestData> dataListener = (former, newData) =>
			{
				Assert.AreEqual(null, former);
				Assert.AreEqual(_testData, newData);
				called = true;
			};

			RepositoryDataChangedAction<int> intListener = (former, newData) =>
			{
				Assert.AreEqual(default(int), former);
				Assert.AreEqual(_testInt, newData);
				called = true;
			};

			RepositoryDataChangedAction<string> stringListener = (former, newData) =>
			{
				Assert.AreEqual(default(string), former);
				Assert.AreEqual(_testString, newData);
				called = true;
			};

			_dataRepository.OnRepositoryDataChanged += dataListener;
			_intRepository.OnRepositoryDataChanged += intListener;
			_stringRepository.OnRepositoryDataChanged += stringListener;

			_dataRepository.Store(_testData);
			Assert.IsTrue(called);
			called = false;
			_intRepository.Store(_testInt);
			Assert.IsTrue(called);
			called = false;
			_stringRepository.Store(_testString);
			Assert.IsTrue(called);
			called = false;

			_dataRepository.OnRepositoryDataChanged -= dataListener;
			_intRepository.OnRepositoryDataChanged -= intListener;
			_stringRepository.OnRepositoryDataChanged -= stringListener;
		}
	}
}