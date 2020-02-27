namespace SBaier.Storage
{
	public class BasicRepository<TData> : Repository<TData>
	{
		private TData _data = default(TData);
		public event RepositoryDataChangedAction<TData> OnRepositoryDataChanged;

		public TData Get()
		{
			return _data;
		}

		public void Store(TData value)
		{
			TData formerData = _data;
			_data = value;
			OnRepositoryDataChanged?.Invoke(formerData, _data);
		}
	}
}