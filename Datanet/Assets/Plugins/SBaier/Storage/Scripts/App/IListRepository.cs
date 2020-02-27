using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SBaier.Storage
{
	public interface IListRepository<TContent> : ICollectionRepository<TContent>
	{
		void Add(TContent value);
		TContent Get(int index);
		void Remove(TContent value);
		void RemoveAt(int index);
		bool Contains(TContent value);
	}
}