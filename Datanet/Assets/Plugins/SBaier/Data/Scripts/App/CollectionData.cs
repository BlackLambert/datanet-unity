using System;
using System.Collections.Generic;

namespace SBaier
{
	public abstract class CollectionData<TData>
	{
		public abstract event Action<TData> OnCollectionContentAdded;
		public abstract event Action<TData> OnCollectionContentRemoved;
		public abstract int Count { get; }
		public abstract ICollection<TData> CopyCollection();
	}
}