using SBaier.Persistence;
using SBaier.Serialization.String;

namespace SBaier.Datanet.Core
{
	public class NodeTypesPreserver : LocalDataPreserver<NodeTypes>
	{
		public NodeTypesPreserver(string path, StringSerializer serializer, LocalDataAccesser localDataAccesser) : base(path, serializer, localDataAccesser)
		{
		}
	}
}