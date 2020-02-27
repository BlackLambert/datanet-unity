using System;
using System.Collections.Generic;
using System.Linq;

namespace SBaier.Storage
{
	public abstract class BasicListRepository<TData> : IListRepository<TData>
	{
		public int Count => _datas.Count;

		public event CollectionContentChangedAction<TData> OnCollectionContentAdded;
		public event CollectionContentChangedAction<TData> OnCollectionContentRemoved;
		public event RepositoryDataChangedAction<ICollection<TData>> OnRepositoryDataChanged;

		private List<TData> _datas;


		public BasicListRepository()
		{
			_datas = new List<TData>();
			Store(_datas);
		}


		public void Add(TData value)
		{
			_datas.Add(value);
			OnCollectionContentAdded?.Invoke(value);
		}

		public bool Contains(TData value)
		{
			return _datas.Contains(value);
		}

		public TData Get(int index)
		{
			return _datas[index];
		}

		public ICollection<TData> Get()
		{
			return new List<TData>(_datas);
		}

		public void Remove(TData value)
		{
			if (!_datas.Contains(value))
				throw new ArgumentException();
			while(_datas.Contains(value))
				_datas.Remove(value);
			OnCollectionContentRemoved?.Invoke(value);
		}

		public void Store(ICollection<TData> value)
		{
			ICollection<TData> formerData = _datas;
			_datas = value.ToList();
			OnRepositoryDataChanged?.Invoke(formerData, _datas);
		}

		public void RemoveAt(int index)
		{
			TData dataToRemove = _datas[index];
			_datas.RemoveAt(index);
			OnCollectionContentRemoved?.Invoke(dataToRemove);
		}
	}
}
