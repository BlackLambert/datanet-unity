using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;


namespace SBaier.Serialization.String.Tests
{
	[TestFixture]
	public class JsonDotNetSerializerUnitTest : ZenjectUnitTestFixture
	{
		private const int _innerNum = 20;
		private const int _smallNum = 5;
		private const int _num = 12;
		private const string _text = "Test";
		private const TestEnum _enum = TestEnum.Second;
		private readonly TestInnerSerializable _inner = new TestInnerSerializable(_innerNum);
		private const int _nonSerializedNum = 400;

		[SetUp]
		public void Install()
		{
			Container.Bind<StringSerializer>().To<JsonDotNetSerializer>().AsSingle();
			Container.Bind<TestInnerSerializable>().FromInstance(new TestInnerSerializable(_smallNum)).AsTransient();
			Container.Bind<TestSerializable>().FromInstance(new TestSerializable(_num, _text, _enum, _inner)).AsTransient();
			Container.Inject(this);
		}


		[Inject]
		private StringSerializer _serializer = null;
		[Inject]
		private TestInnerSerializable _small = null;
		[Inject]
		private TestSerializable _large = null;

		[Test]
		public void Serialize_SerializedSmallContainsCorrectValue()
		{
			string serialized = _serializer.Serialize(_small);
			Assert.IsTrue(serialized.Contains(_smallNum.ToString()));
		}

		[Test]
		public void Serialize_SerializedLargeContainsCorrectValue()
		{
			string serialized = _serializer.Serialize(_large);
			Assert.IsTrue(serialized.Contains(_innerNum.ToString()));
			Assert.IsTrue(serialized.Contains(_num.ToString()));
			Assert.IsTrue(serialized.Contains(_text));
			Assert.IsTrue(serialized.Contains(((int)_enum).ToString()));
		}

		[Test]
		public void Serialize_ReturnsEmptyStringOnNullArgument()
		{
			string serialized = _serializer.Serialize<TestSerializable>(null);
			Assert.IsTrue(string.IsNullOrEmpty(serialized));
		}

		[Test]
		public void Serialize_ContainsDefaultValueOnDefaultArgument()
		{
			string serialized = _serializer.Serialize<int>(default(int));
			Assert.IsTrue(serialized.Contains(default(int).ToString()));
			serialized = _serializer.Serialize<TestEnum>(default(TestEnum));
			Assert.IsTrue(serialized.Contains(((int)default(TestEnum)).ToString()));
		}

		[Test]
		public void Serialize_OnlySerializesMarkedFields()
		{
			_large.NonSerializedNum = _nonSerializedNum;
			string serialized = _serializer.Serialize<TestSerializable>(_large);
			Assert.IsFalse(serialized.Contains(_nonSerializedNum.ToString()));
		}

		[Test]
		public void Deserialize_ReturnsNullOnEmptyString()
		{
			TestSerializable serializable = _serializer.Deserialize<TestSerializable>(string.Empty);
			Assert.IsNull(serializable);
		}

		[Test]
		public void Deserialize_ReturnsDefaultValueOnSerializedDefault()
		{
			string serialized = _serializer.Serialize<TestEnum>(default(TestEnum));
			TestEnum serializable = _serializer.Deserialize<TestEnum>(serialized);
			Assert.AreEqual(default(TestEnum), serializable);
			serialized = _serializer.Serialize<int>(default(int));
			int serializableNum = _serializer.Deserialize<int>(serialized);
			Assert.AreEqual(default(int), serializableNum);
		}

		[Test]
		public void Deserialize_ReturnsSameObjectAsInput()
		{
			string serialized = _serializer.Serialize<TestInnerSerializable>(_small);
			TestInnerSerializable serializable = _serializer.Deserialize<TestInnerSerializable>(serialized);
			Assert.AreEqual(_small.Num, serializable.Num);
			serialized = _serializer.Serialize<TestSerializable>(_large);
			TestSerializable serializableLarge = _serializer.Deserialize<TestSerializable>(serialized);
			Assert.AreEqual(_large.Inner.Num, serializableLarge.Inner.Num);
			Assert.AreEqual(_large.EnumValue, serializableLarge.EnumValue);
			Assert.AreEqual(_large.Text, serializableLarge.Text);
			Assert.AreEqual(_large.Number, serializableLarge.Number);
		}

		[Test]
		public void Deserialize_NonSerializedFieldsHaveDefaultValue()
		{
			_large.NonSerializedNum = _nonSerializedNum;
			string serialized = _serializer.Serialize<TestSerializable>(_large);
			TestSerializable serializable = _serializer.Deserialize<TestSerializable>(serialized);
			Assert.AreEqual(65, serializable.NonSerializedNum);
		}
	}
}