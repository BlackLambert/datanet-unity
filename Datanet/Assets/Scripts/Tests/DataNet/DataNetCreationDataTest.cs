using System;
using NUnit.Framework;
using Zenject;

namespace SBaier.Datanet.Tests
{
	[TestFixture]
	public class DataNetCreationDataTest : ZenjectUnitTestFixture
	{
		private const string _fistError = "Oh No! An error";
		private const string _firstName = "My net";
		private const string _newError = "New error";
		private const string _newName = "New name";

		

        [SetUp]
        public void Install()
        {
			Container.Bind<DataNetCreationData>().AsTransient();
			Container.Inject(this);
		}


		[Inject]
		private DataNetCreationData _creationData = null;



		[Test]
        public void HasCorrectInitialState()
        {
			Assert.AreEqual(string.Empty, _creationData.Error);
			Assert.AreEqual(string.Empty, _creationData.Name);
		}

		[Test]
		public void Error_SetAndGetWorking()
		{
			_creationData.Error = _fistError;
			Assert.AreEqual(_fistError, _creationData.Error);
			_creationData.Error = _newError;
			Assert.AreEqual(_newError, _creationData.Error);
		}

		[Test]
		public void Error_EventCalled()
		{
			bool called = false;
			Action listener = () =>
			{
				Assert.AreEqual(_newError, _creationData.Error);
				called = true;
			};
			_creationData.OnErrorChanged += listener;
			_creationData.Error = _newError;
			Assert.True(called);
			_creationData.OnErrorChanged -= listener;
		}

		[Test]
		public void Name_SetAndGetWorking()
		{
			_creationData.Name = _firstName;
			Assert.AreEqual(_firstName, _creationData.Name);
			_creationData.Name = _newName;
			Assert.AreEqual(_newName, _creationData.Name);
		}

		[Test]
		public void Name_EventCalled()
		{
			bool called = false;
			Action listener = () =>
			{
				Assert.AreEqual(_newName, _creationData.Name);
				called = true;
			};
			_creationData.OnNameChanged += listener;
			_creationData.Name = _newName;
			Assert.True(called);
			_creationData.OnNameChanged -= listener;
		}
	}
}
