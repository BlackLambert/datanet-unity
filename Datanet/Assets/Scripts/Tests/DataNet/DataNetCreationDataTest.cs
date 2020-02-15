using System;
using NUnit.Framework;

namespace SBaier.Datanet.Tests
{
    public class DataNetCreationDataTest
    {
		private const string _error = "Oh No! An error";
		private const string _name = "My net";
		private const string _newError = "New error";
		private const string _newName = "New name";

		private DataNetCreationData _creationData;

        [SetUp]
        public void Setup()
        {
			_creationData = new DataNetCreationData();
			_creationData.Error = _error;
			_creationData.Name = _name;
		}
	
        // A Test behaves as an ordinary method
        [Test]
        public void InputEqualsOutput()
        {
			Assert.AreEqual(_creationData.Error, _error);
			Assert.AreEqual(_creationData.Name, _name);
		}

		[Test]
		public void ErrorChangedEventCalled()
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
		public void NameChangedEventCalled()
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
