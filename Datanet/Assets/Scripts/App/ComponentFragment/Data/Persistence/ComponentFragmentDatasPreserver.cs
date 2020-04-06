using SBaier.LocalDataAccess;
using SBaier.Persistence;
using SBaier.Serialization.String;

namespace SBaier.Datanet
{
	public class ComponentFragmentDatasPreserver : LocalDataPreserver<ComponentFragmentDatas>
	{
		public ComponentFragmentDatasPreserver(string path, StringSerializer serializer, LocalDataAccesser localDataAccesser) : base(path, serializer, localDataAccesser)
		{
		}
	}
}