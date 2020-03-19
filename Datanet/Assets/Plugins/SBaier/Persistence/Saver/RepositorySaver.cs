using SBaier.Storage;
using System.Threading.Tasks;

namespace SBaier.Persistence
{
	public abstract class RepositorySaver<TData> : DataSaver<TData>
	{
		private Repository<TData> _repository;
		private DataPreserver<TData> _preserver;

		public RepositorySaver(Repository<TData> repository,
			DataPreserver<TData> preserver)
		{
			_repository = repository;
			_preserver = preserver;
		}

		public async Task Save()
		{
			TData data = _repository.Get();
			if (data == default)
				return;
			await _preserver.Preserve(data);
		}
	}
}