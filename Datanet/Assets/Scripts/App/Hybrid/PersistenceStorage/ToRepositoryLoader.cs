using SBaier.Storage;
using System.Threading.Tasks;
using UnityEngine;

namespace SBaier.Persistence
{
	public abstract class ToRepositoryLoader<TData> : DataLoader<TData>
	{
		private Repository<TData> _repository;
		private DataPreserver<TData> _preserver;

		public ToRepositoryLoader(Repository<TData> repository,
			DataPreserver<TData> preserver)
		{
			_repository = repository;
			_preserver = preserver;
		}

		public async Task Load()
		{
			TData data = await _preserver.Retrieve();
			if (data == default)
				data = createNew();
			_repository.Store(data);
			//Debug.Log($"Loaded {nameof(TData)} to Repository: {_repository.Get().ToString()}");
		}

		protected abstract TData createNew();
	}
}