using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SBaier.Storage
{
	public class BasicDictionaryRepository<TKey, TContent> : IDictionaryRepository<TKey, TContent>
	{
		private Dictionary<TKey, TContent> _dictionary = null;
		public event CollectionContentChangedAction<KeyValuePair<TKey, TContent>> OnCollectionContentAdded;
		public event CollectionContentChangedAction<KeyValuePair<TKey, TContent>> OnCollectionContentRemoved;
		public event RepositoryDataChangedAction<ICollection<KeyValuePair<TKey, TContent>>> OnRepositoryDataChanged;

		public int Count { get { return _dictionary.Count; } }


		public void Add(TKey key, TContent value)
		{
			_dictionary.Add(key, value);
			OnCollectionContentAdded?.Invoke(new KeyValuePair<TKey, TContent>(key, value));
		}

		public TContent Get(TKey key)
		{
			return _dictionary[key];
		}

		public void Remove(TKey key)
		{
			TContent valueToRemove = _dictionary[key];
			_dictionary.Remove(key);
			OnCollectionContentRemoved?.Invoke(new KeyValuePair<TKey, TContent>(key, valueToRemove));
		}

		public bool Contains(TKey key)
		{
			return _dictionary.ContainsKey(key);
		}

		public ICollection<KeyValuePair<TKey, TContent>> Get()
		{
			return _dictionary.ToList();
		}

		public void Store(ICollection<KeyValuePair<TKey, TContent>> value)
		{
			Dictionary<TKey, TContent> former = _dictionary;
			_dictionary = new Dictionary<TKey, TContent>();
			foreach (KeyValuePair<TKey, TContent> pair in value)
				_dictionary.Add(pair.Key, pair.Value);
			OnRepositoryDataChanged?.Invoke(former, value);
		}

		public IDictionary<TKey, TContent> Copy()
		{
			return new Dictionary<TKey, TContent>(_dictionary);
		}
	}
}