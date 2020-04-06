using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SBaier
{
	[JsonObject(MemberSerialization.OptIn)]
	public class BasicDictionaryData<TKey, TValue> : DictionaryData<TKey, TValue>
	{
		[JsonProperty]
		private Dictionary<TKey, TValue> _dictionary = new Dictionary<TKey, TValue>();
		public override event Action<KeyValuePair<TKey, TValue>> OnCollectionContentAdded;
		public override event Action<KeyValuePair<TKey, TValue>> OnCollectionContentRemoved;

		public override int Count { get { return _dictionary.Count; } }


		public BasicDictionaryData()
		{
			
		}


		public override void Add(TKey key, TValue value)
		{
			_dictionary.Add(key, value);
			OnCollectionContentAdded?.Invoke(new KeyValuePair<TKey, TValue>(key, value));
		}

		public override TValue Get(TKey key)
		{
			return _dictionary[key];
		}

		public override void Remove(TKey key)
		{
			TValue valueToRemove = _dictionary[key];
			_dictionary.Remove(key);
			OnCollectionContentRemoved?.Invoke(new KeyValuePair<TKey, TValue>(key, valueToRemove));
		}

		public override bool Contains(TKey key)
		{
			return _dictionary.ContainsKey(key);
		}

		public override IDictionary<TKey, TValue> CopyDictionary()
		{
			return new Dictionary<TKey, TValue>(_dictionary);
		}

		public override ICollection<KeyValuePair<TKey, TValue>> CopyCollection()
		{
			return _dictionary.ToList();
		}
	}
}