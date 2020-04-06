

namespace SBaier
{
	public abstract class ListData<TData> : CollectionData<TData>
	{
		public abstract void Add(TData value);
		public abstract TData Get(int index);
		public abstract void Remove(TData value);
		public abstract void RemoveAt(int index);
		public abstract bool Contains(TData value);
	}
}