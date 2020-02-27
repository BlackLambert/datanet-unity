using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SBaier.Storage
{
	public interface IDictionaryRepository<TKey, TContent> : ICollectionRepository<KeyValuePair<TKey, TContent>>
	{
		void Add(TKey key, TContent value);
		TContent Get(TKey key);
		void Remove(TKey key);
		bool Contains(TKey key);
		IDictionary<TKey, TContent> Copy();
	}
}