using SBaier.LocalDataAccess;
using SBaier.Persistence;
using SBaier.Serialization.String;

namespace SBaier.Datanet
{
	public class DataNetsPreserver : LocalDataPreserver<DataNets>
	{
		public DataNetsPreserver(string path, 
			StringSerializer serializer,
			LocalDataAccesser localDataAccesser) : base(path, serializer, localDataAccesser)
		{
		}
	}
}