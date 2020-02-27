using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SBaier.Storage
{
	public class DictionaryRepositoryDummy<TKey, TValue> : IDictionaryRepository<TKey, TValue>
	{
		public int Count => 0;

		public event CollectionContentChangedAction<KeyValuePair<TKey, TValue>> OnCollectionContentAdded;
		public event CollectionContentChangedAction<KeyValuePair<TKey, TValue>> OnCollectionContentRemoved;
		public event RepositoryDataChangedAction<ICollection<KeyValuePair<TKey, TValue>>> OnRepositoryDataChanged;

		public void Add(TKey key, TValue value)
		{
			Debug.Log($"Adding key and value to {nameof(DictionaryRepositoryDummy<TKey, TValue>)} '{this}'");
			OnCollectionContentAdded?.Invoke( new KeyValuePair<TKey, TValue>(key, value));
		}

		public bool Contains(TKey key)
		{
			Debug.Log($"Checking if {nameof(DictionaryRepositoryDummy<TKey, TValue>)} '{this}' contains Key '{key}'");
			return true;
		}

		public IDictionary<TKey, TValue> Copy()
		{
			return new Dictionary<TKey, TValue>();
		}

		public TValue Get(TKey key)
		{
			return default(TValue);
		}

		public ICollection<KeyValuePair<TKey, TValue>> Get()
		{
			return new List<KeyValuePair<TKey, TValue>>();
		}

		public void Remove(TKey key)
		{
			Debug.Log($"Removing value with key '{key}' from {nameof(DictionaryRepositoryDummy<TKey, TValue>)} '{this}'");
			OnCollectionContentRemoved?.Invoke(new KeyValuePair<TKey, TValue>(key, default(TValue)));
		}

		public void Store(ICollection<KeyValuePair<TKey, TValue>> value)
		{
			Debug.Log("Storing new Dictionary in Repository");
			OnRepositoryDataChanged?.Invoke(null, value);
		}
	}
}