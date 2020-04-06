using Zenject;
using NUnit.Framework;
using SBaier.Serialization.String;
using UnityEngine;
using System.IO;
using System.Threading.Tasks;
using System;
using SBaier.LocalDataAccess;

namespace SBaier.Persistence.Tests
{
	[TestFixture]
	public class LocalDataPreserverUnitTest : ZenjectUnitTestFixture
	{
		private const string _pathPart = "Test/TestData.json";
		public string DataPath { get { return Path.Combine( Application.streamingAssetsPath, _pathPart); } }

		[SetUp]
		public void Install()
		{
			Container.Bind(typeof(StringSerializer)).To<StringSerializerDummy>().AsSingle();
			Container.Bind(typeof(DataPreserver<TestData>)).WithId("Correct").To<TestLocalDataPreserver>().AsTransient().WithArguments(DataPath);
			Container.Bind(typeof(TestData)).To<TestData>().AsTransient();
			Container.Bind(typeof(LocalDataAccesser)).To<DefaultDataAccesser>().AsTransient();
			Container.Inject(this);
		}

		[TearDown]
		public void CleanUp()
		{
			if(File.Exists(DataPath))
				File.Delete(DataPath);
			if(Directory.Exists(Path.GetDirectoryName(DataPath)))
				Directory.Delete(Path.GetDirectoryName(DataPath));
		}

		[Inject (Id = "Correct")]
		private DataPreserver<TestData> _preserver = null;
		[Inject]
		private TestData _data = null;
		[Inject]
		private LocalDataAccesser _localDataAccesser = null;

		[Test]
		public void Preserve_CreatesPathDirectories()
		{
			string directory = Path.GetDirectoryName(DataPath);
			Assert.IsFalse(Directory.Exists(directory));
			Task.Run(() => preserveData()).GetAwaiter().GetResult();
			Assert.IsTrue(Directory.Exists(directory));
		}

		[Test]
		public void Preserve_FailsOnNullArgument()
		{
			Assert.Throws<ArgumentNullException>(() => Task.Run(() => preservEmpty()).GetAwaiter().GetResult());
		}

		[Test]
		public void Preserve_SavesExpected()
		{
			string expectedString = _data.ToString();
			Task.Run(() => preserveData()).GetAwaiter().GetResult();
			string savedData = Task.Run(() => loadSavedData()).GetAwaiter().GetResult();
			Assert.IsTrue(savedData.Contains(expectedString));
		}

		private async Task<string> loadSavedData()
		{
			return await _localDataAccesser.Load(DataPath);
		}

		private async Task preserveData()
		{
			await _preserver.Preserve(_data);
		}

		private async Task preservEmpty()
		{
			await _preserver.Preserve(null);
		}
	}
}