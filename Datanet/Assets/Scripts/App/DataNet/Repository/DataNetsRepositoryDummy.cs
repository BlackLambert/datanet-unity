using SBaier.Storage;

namespace SBaier.Datanet
{
	public class DataNetsRepositoryDummy : RepositoryDummy<DataNets>, DataNetsRepository
	{
		public DataNetsRepositoryDummy()
		{
			Store(new DataNets());
		}
	}
}