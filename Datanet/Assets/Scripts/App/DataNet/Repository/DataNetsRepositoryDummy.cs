using SBaier.Storage;

namespace SBaier.Datanet.Core
{
	public class DataNetsRepositoryDummy : RepositoryDummy<DataNets>, DataNetsRepository
	{
		public DataNetsRepositoryDummy()
		{
			Store(new DataNets());
		}
	}
}