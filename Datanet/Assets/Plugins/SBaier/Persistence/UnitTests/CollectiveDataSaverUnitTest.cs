using Zenject;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace SBaier.Persistence.Tests
{
	[TestFixture]
	public class CollectiveDataSaverUnitTest : ZenjectUnitTestFixture
	{
		[SetUp]
		public void Install()
		{
			Container.Bind(typeof(TestDataSaver)).To<TestDataSaver>().AsTransient();
			Container.Bind(typeof(CollectiveDataSaver)).To<CollectiveDataSaver>().AsTransient();
			Container.Inject(this);
		}

		[Inject]
		private TestDataSaver _first = null;
		[Inject]
		private TestDataSaver _second = null;
		[Inject]
		private TestDataSaver _third = null;
		[Inject]
		private CollectiveDataSaver _collectiveDataSaver = null;

		[Test]
		public void Add_FailsOnEmptyArgument()
		{
			Assert.Throws<ArgumentNullException>(() => _collectiveDataSaver.Add(null));
		}

		[Test]
		public void Add_FailsOnSelfArgument()
		{
			Assert.Throws<ArgumentException>(() => _collectiveDataSaver.Add(_collectiveDataSaver));
		}

		[Test]
		public void Add_FailsOnAddedSaverArgument()
		{
			_collectiveDataSaver.Add(_first);
			Assert.Throws<ArgumentException>(() => _collectiveDataSaver.Add(_first));
		}

		[Test]
		public void Add_AddsSaver()
		{
			_collectiveDataSaver.Add(_first);
			Assert.IsTrue(_collectiveDataSaver.SaversCopy.Contains(_first));
		}

		[Test]
		public void Remove_FailsOnNullArgument()
		{
			Assert.Throws<ArgumentNullException>(() => _collectiveDataSaver.Remove(null));
		}

		[Test]
		public void Remove_FailsOnNotAddedSaver()
		{
			Assert.Throws<ArgumentException>(() => _collectiveDataSaver.Remove(_first));
		}

		[Test]
		public void Remove_RemovesSaver()
		{
			_collectiveDataSaver.Add(_first);
			Assert.IsTrue(_collectiveDataSaver.SaversCopy.Contains(_first));
			_collectiveDataSaver.Remove(_first);
			Assert.IsFalse(_collectiveDataSaver.SaversCopy.Contains(_first));
		}

		[Test]
		public void Load_DoesNotFailOnEmpty()
		{
			Assert.DoesNotThrow(() => Task.Run(() => save()).GetAwaiter().GetResult());
		}

		[Test]
		public void Load_SavesAddedSavers()
		{
			Assert.IsFalse(_first.Saved);
			Assert.IsFalse(_second.Saved);
			Assert.IsFalse(_third.Saved);
			_collectiveDataSaver.Add(_first);
			_collectiveDataSaver.Add(_second);
			_collectiveDataSaver.Add(_third);
			Task.Run(() => save()).GetAwaiter().GetResult();
			Assert.IsTrue(_first.Saved);
			Assert.IsTrue(_second.Saved);
			Assert.IsTrue(_third.Saved);
		}

		private async Task save()
		{
			await _collectiveDataSaver.Save();
		}
	}

}