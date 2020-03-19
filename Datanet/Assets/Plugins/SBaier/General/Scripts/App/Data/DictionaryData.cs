
using System.Collections.Generic;

namespace SBaier
{
	public abstract class DictionaryData<TKey, TValue> : CollectionData<KeyValuePair<TKey, TValue>>
	{
		public abstract void Add(TKey key, TValue value);
		public abstract TValue Get(TKey key);
		public abstract void Remove(TKey key);
		public abstract bool Contains(TKey key);
		public abstract IDictionary<TKey, TValue> CopyDictionary();
	}
}