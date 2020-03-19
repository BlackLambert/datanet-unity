
using SBaier.Persistence;
using SBaier.Datanet.Core;
using SBaier.Storage;

namespace SBaier.Datanet
{
	public class DataNetsLoader : ToRepositoryLoader<DataNets>
	{
		public DataNetsLoader(Repository<DataNets> repository, DataPreserver<DataNets> preserver) : base(repository, preserver)
		{
		}

		protected override DataNets createNew()
		{
			return new DataNets();
		}
	}
}