using System;
using System.Collections.Generic;

namespace SBaier
{
	public class BasicListData<TData> : ListData<TData>
	{
		public override int Count => _datas.Count;

		public override event Action<TData> OnCollectionContentAdded;
		public override event Action<TData> OnCollectionContentRemoved;

		private List<TData> _datas = new List<TData>();


		public override void Add(TData value)
		{
			_datas.Add(value);
			OnCollectionContentAdded?.Invoke(value);
		}

		public override bool Contains(TData value)
		{
			return _datas.Contains(value);
		}

		public override TData Get(int index)
		{
			return _datas[index];
		}

		public override void Remove(TData value)
		{
			if (!_datas.Contains(value))
				throw new ArgumentException();
			while (_datas.Contains(value))
				_datas.Remove(value);
			OnCollectionContentRemoved?.Invoke(value);
		}

		public override void RemoveAt(int index)
		{
			TData dataToRemove = _datas[index];
			_datas.RemoveAt(index);
			OnCollectionContentRemoved?.Invoke(dataToRemove);
		}

		public override ICollection<TData> CopyCollection()
		{
			return new List<TData>(_datas);
		}
	}
}