using Zenject;
using NUnit.Framework;
using UnityEngine;
using System.IO;
using System.Threading.Tasks;
using System;

namespace SBaier.Tests
{
	[TestFixture]
	public class LocalDataAccesserUnitTest : ZenjectUnitTestFixture
	{
		private const string _data = "This is my text";
		private const string _pathPart = "Test/TestData.json";
		private const string _dirPathPart = "Test/TestData/";
		public string DataPath { get { return Path.Combine( Application.streamingAssetsPath, _pathPart); } }
		public string DirDataPath { get { return Path.Combine(Application.streamingAssetsPath, _dirPathPart); } }

		[SetUp]
		public void Install()
		{
			Container.Bind(typeof(LocalDataAccesser)).To<LocalDataAccesser>().AsTransient();
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

		[Inject]
		private LocalDataAccesser _localDataAccesser = null;

		[Test]
		public void Preserve_CreatesPathDirectories()
		{
			string directory = Path.GetDirectoryName(DataPath);
			Assert.IsFalse(Directory.Exists(directory));
			Task.Run(() => saveData(DataPath, _data)).GetAwaiter().GetResult();
			Assert.IsTrue(Directory.Exists(directory));
		}

		[Test]
		public void Preserve_FailsOnDirectoryPath()
		{
			Assert.Throws<ArgumentException>(() => Task.Run(() => saveData(DirDataPath, _data)).GetAwaiter().GetResult());
		}

		[Test]
		public void Preserve_FailsOnEmptyPath()
		{
			Assert.Throws<ArgumentNullException>(() => Task.Run(() => saveData(string.Empty, _data)).GetAwaiter().GetResult());
		}

		[Test]
		public void Preserve_FailsOnEmptyData()
		{
			Assert.Throws<ArgumentNullException>(() => Task.Run(() => saveData(DataPath, string.Empty)).GetAwaiter().GetResult());
		}


		private async Task<string> loadSavedData(string path)
		{
			return await _localDataAccesser.Load(path);
		}

		private async Task saveData(string path, string data)
		{
			await _localDataAccesser.Save(path, data);
		}
	}
}