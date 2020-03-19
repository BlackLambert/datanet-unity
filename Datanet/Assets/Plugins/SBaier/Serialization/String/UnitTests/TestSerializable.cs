using Newtonsoft.Json;
using System;
using UnityEngine;

namespace SBaier.Serialization.String.Tests
{
	[Serializable]
	public class TestSerializable 
	{
		private int _number;
		public int Number { get { return _number; } }

		private string _text;
		public string Text { get { return _text; } }

		private TestEnum _enumValue;
		public TestEnum EnumValue { get { return _enumValue; } }

		private TestInnerSerializable _inner;
		public TestInnerSerializable Inner { get { return _inner; } }

		private int _nonSerializedNum = 65;
		[JsonIgnore]
		public int NonSerializedNum
		{
			get { return _nonSerializedNum; }
			set { _nonSerializedNum = value; }
		}

		public TestSerializable(int number,
			string text,
			TestEnum enumValue,
			TestInnerSerializable inner)
		{
			_number = number;
			_text = text;
			_enumValue = enumValue;
			_inner = inner;
		}
	}
}