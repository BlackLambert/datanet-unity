using SBaier.Persistence;
using SBaier.Serialization.String;

namespace SBaier.Datanet
{
	public class NodeComponentDatasPreserver : LocalDataPreserver<NodeComponentDatas>
	{
		public NodeComponentDatasPreserver(string path, StringSerializer serializer, LocalDataAccesser localDataAccesser) : base(path, serializer, localDataAccesser)
		{
		}
	}
}