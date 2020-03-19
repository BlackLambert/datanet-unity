using UnityEngine;

namespace SBaier.Storage
{
	public abstract class RepositoryDummy<TData> : Repository<TData>
	{
		public event RepositoryDataChangedAction<TData> OnRepositoryDataChanged;
		private TData _data = default;

		public TData Get()
		{
			return _data;
		}

		public void Store(TData value)
		{
			_data = value;
			OnRepositoryDataChanged?.Invoke(default, value);
		}
	}
}