using SBaier.Persistence;
using SBaier.Serialization.String;

namespace SBaier.Datanet
{
	public class NodeDatasPreserver : LocalDataPreserver<NodeDatas>
	{
		public NodeDatasPreserver(string path, StringSerializer serializer, LocalDataAccesser localDataAccesser) : base(path, serializer, localDataAccesser)
		{
		}
	}
}