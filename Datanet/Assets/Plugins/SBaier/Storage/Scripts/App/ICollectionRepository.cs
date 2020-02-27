using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SBaier.Storage
{
	public interface ICollectionRepository<TContent> : Repository<ICollection<TContent>>
	{
		event CollectionContentChangedAction<TContent> OnCollectionContentAdded;
		event CollectionContentChangedAction<TContent> OnCollectionContentRemoved;
		int Count { get; }
		
		
	}
}