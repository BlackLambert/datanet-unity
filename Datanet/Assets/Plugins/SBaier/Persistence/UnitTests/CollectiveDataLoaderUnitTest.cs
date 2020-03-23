using Zenject;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace SBaier.Persistence.Tests
{
	[TestFixture]
	public class CollectiveDataLoaderUnitTest : ZenjectUnitTestFixture
	{
		[SetUp]
		public void Install()
		{
			Container.Bind(typeof(TestDataLoader), typeof(DataLoader<TestData>)).To<TestDataLoader>().AsTransient();
			Container.Bind(typeof(CollectiveDataLoader)).To<CollectiveDataLoader>().AsTransient();
			Container.Inject(this);
		}

		[Inject]
		private TestDataLoader _first = null;
		[Inject]
		private TestDataLoader _second = null;
		[Inject]
		private TestDataLoader _third = null;
		[Inject]
		private CollectiveDataLoader _collectiveDataLoader = null;

		[Test]
		public void Add_FailsOnEmptyArgument()
		{
			Assert.Throws<ArgumentNullException>(() => _collectiveDataLoader.Add(null));
		}

		[Test]
		public void Add_FailsOnSelfArgument()
		{
			Assert.Throws<ArgumentException>(() => _collectiveDataLoader.Add(_collectiveDataLoader));
		}

		[Test]
		public void Add_FailsOnAddedLoaderArgument()
		{
			_collectiveDataLoader.Add(_first);
			Assert.Throws<ArgumentException>(() => _collectiveDataLoader.Add(_first));
		}

		[Test]
		public void Add_AddsLoader()
		{
			_collectiveDataLoader.Add(_first);
			Assert.IsTrue(_collectiveDataLoader.LoadersCopy.Contains(_first));
		}

		[Test]
		public void Remove_FailsOnNullArgument()
		{
			Assert.Throws<ArgumentNullException>(() => _collectiveDataLoader.Remove(null));
		}

		[Test]
		public void Remove_FailsOnNotAddedLoader()
		{
			Assert.Throws<ArgumentException>(() => _collectiveDataLoader.Remove(_first));
		}

		[Test]
		public void Remove_RemovesLoader()
		{
			_collectiveDataLoader.Add(_first);
			Assert.IsTrue(_collectiveDataLoader.LoadersCopy.Contains(_first));
			_collectiveDataLoader.Remove(_first);
			Assert.IsFalse(_collectiveDataLoader.LoadersCopy.Contains(_first));
		}

		[Test]
		public void Load_DoesNotFailOnEmpty()
		{
			Assert.DoesNotThrow(() => Task.Run(() => load()).GetAwaiter().GetResult());
		}

		[Test]
		public void Load_LoadsAddedLoades()
		{
			Assert.IsNull(_first.Data);
			Assert.IsNull(_second.Data);
			Assert.IsNull(_third.Data);
			_collectiveDataLoader.Add(_first);
			_collectiveDataLoader.Add(_second);
			_collectiveDataLoader.Add(_third);
			Task.Run(() => load()).GetAwaiter().GetResult();
			Assert.IsNotNull(_first.Data);
			Assert.IsNotNull(_second.Data);
			Assert.IsNotNull(_third.Data);
		}

		private async Task load()
		{
			await _collectiveDataLoader.Load();
		}
	}

}