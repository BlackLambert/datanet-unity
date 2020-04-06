using Zenject;
using NUnit.Framework;
using UnityEngine;
using System.IO;
using System.Threading.Tasks;
using System;

namespace SBaier.LocalDataAccess.Tests
{
	[TestFixture]
	public class DefaultDataAccesserUnitTest : ZenjectUnitTestFixture
	{
		private const string _data = "This is my text";
		private const string _pathPart = "Test/TestData.json";
		private const string _dirPathPart = "Test/TestData/";
		public string DataPath { get { return Path.Combine( Application.streamingAssetsPath, _pathPart); } }

		[SetUp]
		public void Install()
		{
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

		[Inject]
		private LocalDataAccesser _localDataAccesser = null;

		[Test]
		public void Save_FileHasCorrectContent()
		{
			Task.Run(() => saveData(DataPath, _data)).GetAwaiter().GetResult();
			Assert.IsTrue(Directory.Exists(Path.GetDirectoryName(DataPath)));
			string content = Task.Run(() => loadSavedData(DataPath)).GetAwaiter().GetResult();
			Assert.IsTrue(content.Contains(_data.ToString()));
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